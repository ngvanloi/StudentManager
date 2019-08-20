using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class ListStudent : Form
    {
        public ListStudent()
        {
            InitializeComponent();
            this.Load += ListStudent_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(this.grdStudents.SelectedRows.Count== 1)
            {
                DataGridViewRow row = grdStudents.SelectedRows[0];
                Student item = (Student)row.DataBoundItem;
                try
                {
                    OOPCSEntities db = new OOPCSEntities();
                    Student student = db.Students.Find(item.id);
                    db.Students.Remove(student);
                    db.SaveChanges();
                    this.ListStudent_Load(null, null);
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.ShowDialog();
            this.ListStudent_Load(null, null);
        }

        void ListStudent_Load(object sender, EventArgs e)
        {
            OOPCSEntities db = new OOPCSEntities();
            List<Student> item = db.Students.ToList();
            this.grdStudents.DataSource = item;

        }
    }
}
