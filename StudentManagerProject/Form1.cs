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
        public Form1()
        {
            InitializeComponent();
            initialDataTable();
        }

        private void initialDataTable()
        {
            SqlConnection con = DBUtils.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_students");
            data = DBUtils.ExecuteQuery(cmd,con);  
        }

        private void loadData()
        {
            try
            {
                dataGridView1.DataSource = data;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data " + e.Message);
                dataGridView1.DataSource = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            string studentID= this.textBox1.Text;
            string firstname = this.textBox2.Text;
            string lastname = this.textBox3.Text;
            DateTime birthdate = DateTime.Parse(this.textBox4.Text);
            bool sex = false;
            if (this.radioButton1.Checked)
            {
                sex = true;
            }
            string majorID = this.textBox5.Text;
            TblStudents.TblStudentsDAO dao = new TblStudents.TblStudentsDAO();
            bool result= dao.Add(studentID, firstname, lastname, birthdate, sex, majorID);
            if (result)
            {
                MessageBox.Show("Add Successfully");
            }
            else
            {
                MessageBox.Show("Failed Action");
            }
        }
    }
}
