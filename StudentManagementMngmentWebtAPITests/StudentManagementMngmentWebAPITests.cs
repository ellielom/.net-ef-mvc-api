using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DBModel;
using StudentManagementAPI.Controllers;
using System.Web;

namespace StudentManagementMngmentWebtAPITests
{
    [TestClass]
    public class StudentManagementMngmentWebAPITests
    {
        [TestMethod]
        public void GetStudentTest()
        {
            StudentsController controller = new StudentsController();
            string expectedFirstName = "Gabby";

            //var result = controller.GetStudent(1);


        }
    }
}
