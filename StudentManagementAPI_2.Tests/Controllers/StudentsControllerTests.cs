using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementAPI_2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBModel;
using System.Web.Http.Results;


namespace StudentManagementAPI_2.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        [TestMethod()]
        public void GetStudentTest()
        {
            StudentsController controller = new StudentsController();
            string expectedFirstName = "Gabby";


            var result = controller.GetStudent(1) as OkNegotiatedContentResult<Student>;
            string actualFirstName = result.Content.FirstName;

            Assert.AreEqual(expectedFirstName, actualFirstName);
        }

        [TestMethod()]
        public void AddStudentTest()
        {
            StudentsController controller = new StudentsController();
            string expectedFirstName = "Ellie";
            Student student = new Student() { FirstName = expectedFirstName, LastName = "Lom" };


            var result = controller.PostStudent(student) as CreatedAtRouteNegotiatedContentResult<Student>;
            string actualFirstName = result.Content.FirstName;

            Assert.AreEqual(expectedFirstName, actualFirstName);
        }


        [TestMethod()]
        public void DeleteStudentTest()
        {
            StudentsController controller = new StudentsController();
            string expectedLastName = "Lom";


            var result = controller.DeleteStudent(4) as OkNegotiatedContentResult<Student>;
            string actualLastName = result.Content.LastName;

            Assert.AreEqual(expectedLastName, actualLastName);
        }



    }
}