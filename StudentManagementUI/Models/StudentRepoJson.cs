using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DBModel;
using Newtonsoft.Json;

namespace StudentManagementUI.Models
{
    public class StudentRepoJson : IStudentRepo
    {

        private List<Student> students;

        public StudentRepoJson()
        {
            string json = File.ReadAllText(@"C:\Data\StudentsList.json");
            students = JsonConvert.DeserializeObject<List<Student>>(json);

        }

        public void SaveChanges()
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/Models/StudentsList.json"), JsonConvert.SerializeObject(students));
        }


        public void Add(Student std)
        {
            std.Id = students.Max(s => s.Id) + 1;

            students.Add(std);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Student std = students.Find(s => s.Id == id);
            students.Remove(std);
            SaveChanges();
        }

        public void Dispose()
        {
            students = null;
        }

        public void Edit(Student std)
        {
            Student student = students.Find(s => s.Id == std.Id);
            student.FirstName = std.FirstName;
            student.LastName = std.LastName;
            SaveChanges();
        }

        public Student GetStudent(int id)
        {
            return students.Find(s => s.Id == id);
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}