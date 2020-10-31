using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBModel;
using System.Web; 

namespace StudentManagementAPI.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        [TestMethod()]
        public void GetStudentTest()
        {
            StudentsController controller = new StudentsController();
            string expectedFirstName = "Gabby";


            //Student actualStudent = controller.GetStudent(1) as Student; 



        }
    }
}