using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityManyToMany
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        EmployeeDbContext db = new EmployeeDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            wyswietl();
        }

        private void wyswietl()
        {
            GridView1.DataSource = (from Student in db.Students
                                    from Course in Student.Courses
                                    select new { stundentNames = Student.StudentName, CourseNames = Course.CourseName }).ToList();
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           Courses kurs = db.Courses.FirstOrDefault(x => x.CourseID == 4);
            db.Students.FirstOrDefault(x => x.StudentID == 1).Courses.Add(kurs);
            db.SaveChanges();
            wyswietl();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Courses kurs = db.Courses.FirstOrDefault(x => x.CourseID == 2);
            db.Students.FirstOrDefault(x => x.StudentID == 2).Courses.Remove(kurs);
            db.SaveChanges();
            wyswietl();
        }
    }
}