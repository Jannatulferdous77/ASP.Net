using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        public static bool Create(Student obj)
        {
            var db = new StudentContext();
            db.Students.Add(obj);
            return db.SaveChanges() > 0;
        }

        public static List<Student> GetAll()
        {
            var db = new StudentContext();
            var data = db.Students.ToList();
            return data;
        }
    }
}
