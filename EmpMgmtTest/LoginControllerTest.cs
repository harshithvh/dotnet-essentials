using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMgmtTest
{
    [TestFixture]
    public class LoginControllerTest
    {
        EmpMgmtUI.Controllers.LoginController loginCtrl;
        EmpMgmtUI.Models.LoginData loginData;

        [SetUp]
        public void Init()
        {
            loginCtrl = new EmpMgmtUI.Controllers.LoginController();
            loginData = new EmpMgmtUI.Models.LoginData();
            loginData.UserName = "user";
            loginData.Password = "aspmvc";
        }
        // while testing if one method executes successfully the other has to fail due to the if-else in Login.cs
        [Test]
        public void Login_Index_Valid_Input_Redirects_Home_Index()
        {
            //act
            // "RedirectToActionResult" object is assigned to the "rtr" variable which is used to store the url returned by index method while testing
            RedirectToActionResult rtr = loginCtrl.Index(loginData) as RedirectToActionResult;

            //assert
            // The "RedirectToActionResult" class has several properties "ActionName" and "ControllerName" 
            string actaction = rtr.ActionName;
            string expaction = "Index";

            string actctrlname = rtr.ControllerName;
            string expctrlname = "Home";

            Assert.AreEqual(actaction, expaction);
            Assert.AreEqual(actctrlname, expctrlname);
        }

        [Test]
        public void Login_Index_InValid_Input_Set_ViewBag_InvalidLogin()
        {
            //act
            ViewResult vr = loginCtrl.Index(loginData) as ViewResult;

            Assert.AreEqual(true, loginCtrl.ViewBag.InvalidLogin);
        }
    }

}
