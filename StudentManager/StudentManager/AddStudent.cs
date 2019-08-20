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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.code = txtCode.Text;
            student.name = txtName.Text;
            student.birthday = dtpBirthDay.Value;
            student.hometown = txtHomeTown.Text;

            OOPCSEntities db = new OOPCSEntities();
            db.Students.Add(student);
            db.SaveChanges();
            this.Close();

        }
    }
}
