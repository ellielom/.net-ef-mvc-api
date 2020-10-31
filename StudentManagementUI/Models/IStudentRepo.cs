using System;
using System.Collections.Generic;
using DBModel;

namespace StudentManagementUI.Models
{
    public interface IStudentRepo : IDisposable

    {
        void Add(Student std);
        void Delete(int id);
        void Edit(Student std);
        Student GetStudent(int id);
        List<Student> GetStudents();
    }
}