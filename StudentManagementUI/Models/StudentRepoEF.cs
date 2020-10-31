using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModel;


namespace StudentManagementUI.Models
{
    public class StudentRepoEF : IStudentRepo
    {
        private StudentDBModelContainer db = new StudentDBModelContainer();

        public void Add(Student std)
        {
            db.Students.Add(std);
            db.SaveChanges();
        }

        public void Edit(Student std)
        {
            db.Entry(std).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student s = db.Students.Find(id);
            db.Students.Remove(s);
            db.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}