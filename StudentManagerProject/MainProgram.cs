using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace StudentManagerProject
{
    public partial class StudentManageForm : Form
    {
        public DataTable data;
        bool isAddItem = false;
        TblStudents.TblStudentsDAO dao;
        public StudentManageForm()
        {
            InitializeComponent();
            dataGridStudent.DefaultCellStyle.SelectionBackColor = dataGridStudent.DefaultCellStyle.BackColor;
            dataGridStudent.DefaultCellStyle.SelectionForeColor = dataGridStudent.DefaultCellStyle.ForeColor;
            dao = new TblStudents.TblStudentsDAO();
            this.radMale.Checked = true;
        }

        private void initialDataTable()
        {
            SqlConnection con = DBUtils.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_students");
            data = DBUtils.ExecuteQuery(cmd, con);
        }

        private void loadData()
        {

            initialDataTable();
            try
            {
                dataGridStudent.DataSource = data;
            }
            catch (Exception e)
            {
                MessageBox.Show("Data can't be loaded! " + e.Message, "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridStudent.DataSource = null;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();
            this.btnSave.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnClear.Enabled = false;
            this.errorStudentProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.disableInput();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridStudent.CurrentCell.RowIndex;
            int studentId = Convert.ToInt32(dataGridStudent.Rows[currentIndex].Cells[0].Value.ToString());
            string studentCode = dataGridStudent.Rows[currentIndex].Cells[1].Value.ToString();
            if (MessageBox.Show("Are you sure to remove " + studentCode + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (dao.DeleteStudent(studentId))
                    {
                        MessageBox.Show("Removed Successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Removed failed " + ex.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }

        }


        public void clearTextBox()
        {
            this.txtStudentId.Text = "";
            this.txtFirstname.Text = "";
            this.txtLastname.Text = "";
            this.radMale.Checked = true;
            this.txtMajorID.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //panelInput.Enabled = true;
            this.enableInput();
            this.btnSave.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            btnRemove.Enabled = false;
            this.btnClear.Enabled = true;
            dataGridStudent.Enabled = false;
            isAddItem = true;
            clearTextBox();
        }

        private void dataGridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridStudent.CurrentRow.Index;
            this.dataGridStudent.DefaultCellStyle.SelectionBackColor=Color.LightSteelBlue;
            this.txtStudentId.Text = dataGridStudent.Rows[index].Cells[1].Value.ToString();
            this.txtFirstname.Text = dataGridStudent.Rows[index].Cells[2].Value.ToString();
            this.txtLastname.Text = dataGridStudent.Rows[index].Cells[3].Value.ToString();
            this.birthdatePicker.Value = DateTime.Parse(dataGridStudent.Rows[index].Cells[4].Value.ToString());
            if (bool.Parse(dataGridStudent.Rows[index].Cells[5].Value.ToString()))
            {
                this.radMale.Checked = true;
            }
            else
            {
                this.radFemale.Checked = true;
            }
            this.txtMajorID.Text = dataGridStudent.Rows[index].Cells[6].Value.ToString();
            btnEdit.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to quit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void updateStudent()
        {
            int currentIndex = dataGridStudent.CurrentCell.RowIndex;
            int Id = Convert.ToInt32(dataGridStudent.Rows[currentIndex].Cells[0].Value.ToString());
            string studentID = this.txtStudentId.Text;
            string firstname = this.txtFirstname.Text;
            string lastname = this.txtLastname.Text;
            DateTime birthdate = DateTime.Parse(this.birthdatePicker.Value.ToString());
            bool sex = false;
            if (this.radMale.Checked)
            {
                sex = true;
            }
            string majorID = this.txtMajorID.Text;
            try
            {
                bool result = dao.Update(Id, studentID, firstname, lastname, birthdate, sex, majorID);
                if (result)
                {
                    MessageBox.Show("Updated Successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Updated failed " + e.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void addNewStudent()
        {
            string studentID = this.txtStudentId.Text;
            string firstname = this.txtFirstname.Text;
            string lastname = this.txtLastname.Text;
            DateTime birthdate = DateTime.Parse(this.birthdatePicker.Value.ToString());
            bool sex = false;
            if (this.radMale.Checked)
            {
                sex = true;
            }
            string majorID = this.txtMajorID.Text;

            try
            {
                bool result = dao.Add(studentID, firstname, lastname, birthdate, sex, majorID);
                if (result)
                {
                    MessageBox.Show("Added Successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed Action", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Added failed " + e.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validateForm()
        {

            this.errorStudentProvider.Clear();
            bool isInvalidInput = false;
            if (String.IsNullOrEmpty(txtStudentId.Text.ToString()))
            {
                errorStudentProvider.SetError(txtStudentId, "Please fill in StudentID");
                isInvalidInput = true;
            }
            else
            {
                //REGEX STUDENT ID
                try
                {
                    Regex studentIdExpressionPattern = new Regex("^[A-Z]{2}[0-9]{5,7}$");
                    Match result = studentIdExpressionPattern.Match(txtStudentId.Text.ToString());
                    if (!result.Success)
                    {
                        errorStudentProvider.SetError(this.txtStudentId, "Wrong format of StudentID ([majorID][5-7numbers]) \n Ex: SE12345");
                        isInvalidInput = true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    errorStudentProvider.SetError(txtStudentId, "Error: " + e.Message);
                    isInvalidInput = true;
                }
            }
            //REGEX NAME
            Regex nameExpressionPattern = new Regex("^[A-Za-z\\s]{1,100}$");

            if (String.IsNullOrEmpty(txtFirstname.Text.ToString()))
            {
                errorStudentProvider.SetError(txtFirstname, "Please fill in First Name");
                isInvalidInput = true;
            }
            else
            {
                try
                {
                    Match result = nameExpressionPattern.Match(this.txtFirstname.Text.ToString());
                    if (!result.Success)
                    {
                        errorStudentProvider.SetError(this.txtFirstname, "Name contains up to 100 alphabet letter");
                        isInvalidInput = true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isInvalidInput = true;
                }
            }
            if (String.IsNullOrEmpty(txtLastname.Text.ToString()))
            {
                errorStudentProvider.SetError(txtLastname, "Please fill in Last Name");
                isInvalidInput = true;
            }
            else
            {
                try
                {
                    Match result = nameExpressionPattern.Match(this.txtLastname.Text.ToString());
                    if (!result.Success)
                    {
                        errorStudentProvider.SetError(this.txtLastname, "Name contains up to 100 alphabet letter only");
                        isInvalidInput = true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isInvalidInput = true;
                }
            }
            if (String.IsNullOrEmpty(txtMajorID.Text.ToString()))
            {
                errorStudentProvider.SetError(txtMajorID, "Please fill in MajorID");
                isInvalidInput = true;
            }
            else
            {
                //REGEX MAJOR ID
                try
                {
                    Regex majorIdExpressionPattern = new Regex("^[A-Z]{2,4}$");
                    Match result = majorIdExpressionPattern.Match(this.txtMajorID.Text.ToString());
                    if (!result.Success)
                    {
                        errorStudentProvider.SetError(this.txtMajorID, "Wrong format of MajorID (2-4 Uppercase letters) \n Ex: SE");
                        isInvalidInput = true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isInvalidInput = true;
                }
            }

            return isInvalidInput;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                return;
            }
            else
            {
                errorStudentProvider.Dispose();
            }
            if (isAddItem == true)
            {
                string studentID = this.txtStudentId.Text;
                if (dao.checkDuplicateStudentCode(studentID))
                {
                    MessageBox.Show("\" " + studentID + "\" is already existed", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                addNewStudent();
                loadData();
                this.disableInput();
                this.btnAdd.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnRemove.Enabled = true;
                this.btnSave.Enabled = false;
                isAddItem = false;
                dataGridStudent.Enabled = true;
            }
            else
            {
                updateStudent();
                loadData();
                this.disableInput();
                this.btnAdd.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnRemove.Enabled = true;
                this.btnSave.Enabled = false;
                dataGridStudent.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.enableInput();
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnRemove.Enabled = false;
            this.btnClear.Enabled = true;
            this.btnSave.Enabled = true;
            dataGridStudent.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void disableInput()
        {
            this.txtStudentId.ReadOnly = true;
            this.txtMajorID.ReadOnly = true;
            this.txtLastname.ReadOnly = true;
            this.txtFirstname.ReadOnly = true;
            this.birthdatePicker.Enabled = false;
            this.radMale.Enabled = false;
            this.radFemale.Enabled = false;
        }

        private void enableInput()
        {
            this.txtStudentId.ReadOnly = false;
            this.txtMajorID.ReadOnly = false;
            this.txtLastname.ReadOnly = false;
            this.txtFirstname.ReadOnly = false;
            this.birthdatePicker.Enabled = true;
            this.radMale.Enabled = true;
            this.radFemale.Enabled = true;
        }

    }
}
