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


namespace StudentManagerProject
{
    public partial class Form1 : Form
    {
        public SqlDataAdapter adapter;
        public DataTable data;
        bool isAddItem = false;
        TblStudents.TblStudentsDAO dao;
        public Form1()
        {
            InitializeComponent();
            dao = new TblStudents.TblStudentsDAO();
        }

        private void initialDataTable()
        {
            SqlConnection con = DBUtils.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_students");
            data = DBUtils.ExecuteQuery(cmd,con);  
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
                MessageBox.Show("Cannot load data " + e.Message);
                dataGridStudent.DataSource = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            panelInput.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridStudent.CurrentCell.RowIndex;
            int studentId = Convert.ToInt32(dataGridStudent.Rows[currentIndex].Cells[0].Value.ToString());
            if (dao.DeleteStudent(studentId))
            {
                MessageBox.Show("Deleted Successfully");
            }
            else {
                MessageBox.Show("Deleted error ! Something occured");
            }
            loadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void clearTextBox()
        {
            this.txtStudentId.Text = "";
            this.txtFirstname.Text = "";
            this.txtLastname.Text = "";
            this.txtBirthdate.Text = "";
            this.radioButton1.Checked = true;
            this.txtMajorID.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelInput.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
            isAddItem = true;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridStudent.CurrentRow.Index;
            this.txtStudentId.Text = dataGridStudent.Rows[index].Cells[1].Value.ToString();
            this.txtFirstname.Text = dataGridStudent.Rows[index].Cells[2].Value.ToString();
            this.txtLastname.Text = dataGridStudent.Rows[index].Cells[3].Value.ToString();
            this.txtBirthdate.Text = dataGridStudent.Rows[index].Cells[4].Value.ToString();
            if (bool.Parse(dataGridStudent.Rows[index].Cells[5].Value.ToString())) 
            {
                this.radioButton1.Checked = true ;
            }
            else
            {
                this.radioButton2.Checked = true;
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
            DateTime birthdate = DateTime.Parse(this.txtBirthdate.Text);
            bool sex = false;
            if (this.radioButton1.Checked)
            {
                sex = true;
            }
            string majorID = this.txtMajorID.Text;

            bool result = dao.Update(Id,studentID, firstname, lastname, birthdate, sex, majorID);
            if (result)
            {
                MessageBox.Show("Updated Successfully");
            }
            else
            {
                MessageBox.Show("Updated failed");
            }
        }
        private void addNewStudent()
        {
            string studentID = this.txtStudentId.Text;
            string firstname = this.txtFirstname.Text;
            string lastname = this.txtLastname.Text;
            DateTime birthdate = DateTime.Parse(this.txtBirthdate.Text);
            bool sex = false;
            if (this.radioButton1.Checked)
            {
                sex = true;
            }
            string majorID = this.txtMajorID.Text;
            
            bool result = dao.Add(studentID, firstname, lastname, birthdate, sex, majorID);
            if (result)
            {
                MessageBox.Show("Added Successfully");
            }
            else
            {
                MessageBox.Show("Failed Action");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAddItem == true)
            {
                addNewStudent();
                loadData();
                panelInput.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
                btnSave.Enabled = false;
                isAddItem = false;
            }
            else
            {
                updateStudent();
                loadData();
                panelInput.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
                btnSave.Enabled = false;

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panelInput.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }
    }
}
