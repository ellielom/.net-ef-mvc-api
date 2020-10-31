using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using DBModel;
using System.Net;
using StudentManagementUI.Models;

namespace StudentManagementUI.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        [TestMethod()]
        public void IndexAction_Returns_IndexView()
        {
            // Arrange
            StudentsController controller = new StudentsController();
            string expectedViewName = "Index";


            // Act
            ViewResult actualView = controller.Index() as ViewResult;
            string actualViewName = actualView.ViewName;


            // Assert
            Assert.AreEqual(expectedViewName, actualViewName);

        }


        [TestMethod()]
        public void DetailsAction_Returns_StudentModel()
        {
            StudentsController controller = new StudentsController();
            Type expectedType = typeof(Student);

            ViewResult actualResult = controller.Details(1) as ViewResult;
            Type actualType = actualResult.Model.GetType();

            Assert.AreEqual(expectedType, actualType);                       
        }

        [TestMethod()]
        public void DetailsAction_Returns_StudentData()
        {
            StudentsController controller = new StudentsController();
            string expectedFirstName = "Gabby";

            ViewResult actualResult = controller.Details(1) as ViewResult;
            Student actualStudent = actualResult.Model as Student; // ok to typecast because our previous test confirms the result is of type student
            string actualFirstName = actualStudent.FirstName;


            Assert.AreEqual(expectedFirstName, actualFirstName);
        }

        [TestMethod()]
        public void DetailsAction_NullID_BadRequest()
        {
            StudentsController controller = new StudentsController();
            HttpStatusCodeResult httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            int expectedStatusCode = httpStatusCodeResult.StatusCode;


            HttpStatusCodeResult actualResult = controller.Details(null) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;



            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        [TestMethod()]
        public void DetailsAction_InvalidID_NotFound()
        {
            StudentsController controller = new StudentsController();
            HttpStatusCodeResult httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            int expectedStatusCode = httpStatusCodeResult.StatusCode;


            HttpStatusCodeResult actualResult = controller.Details(-1) as HttpStatusCodeResult;
            int actualStatusCode = actualResult.StatusCode;



            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }


        [TestMethod()]
        public void DetailsAction_LocalRepoReturns_StudentData()
        {
            StudentsController controller = new StudentsController(new StudentRepoJson());
            string expectedFirstName = "Hynda";

            ViewResult actualResult = controller.Details(1) as ViewResult;
            Student actualStudent = actualResult.Model as Student; // ok to typecast because our previous test confirms the result is of type student
            string actualFirstName = actualStudent.FirstName;


            Assert.AreEqual(expectedFirstName, actualFirstName);
        }


    }
}