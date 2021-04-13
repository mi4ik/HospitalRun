using HospitalRun.DOMs;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace HospitalRun
{
    [AllureNUnit]
    public class Tests : TestBase
    {

        [Test(Description = "User able to login with correct credentials.")]
        [Order(1)]
        public void UserLoginWithCorrectCredentials()
        {
            var _page =
                PageBase<HomePage>.Navigate("http://demo.hospitalrun.io/").
                Login("hr.doctor@hospitalrun.io", "HRt3st12");

            Assert.That(_page.getViewTitle, Is.EqualTo("Patient Listing"));
        }

        [Test(Description = "User cannot login with invalid credentials.")]
        [Order(2)]
        public void UserLoginWithInvalidCredentials()
        {
            var _page =
                PageBase<HomePage>.Navigate("http://demo.hospitalrun.io/").
                InputLogin("hr.cov@hospitalrun.io").
                InputPassword("19");

            _page.SubmitLogin();

            Assert.That(_page.getErrMessage().Displayed, Is.True);
            Assert.That(_page.getErrMessage().Text, Is.EqualTo("Username or password is incorrect."));
        }

        [Test]
        [Order(3)]
        public void UserIsAbleToLogOut()
        {
            var _page =
                PageBase<HomePage>.Navigate("http://demo.hospitalrun.io/").
                Login("hr.doctor@hospitalrun.io", "HRt3st12").
                LogOut();

            Assert.That(_page.SigninFormIsVisible, Is.True);
        }

        [Test]
        [Order(4)]
        public void UserIsAbleToRequestMedication()
        {
            var _page =
                PageBase<HomePage>.Navigate("http://demo.hospitalrun.io/").
                Login("hr.doctor@hospitalrun.io", "HRt3st12").
                SelectMenuItem("Medication");

            var _menuItems = _page.getMenuSubItems();

            Assert.True(_menuItems.Any(x => x.Text == "Requests"));
            Assert.True(_menuItems.Any(x => x.Text == "New Request"));
            Assert.True(_menuItems.Any(x => x.Text == "Completed"));
            Assert.True(_menuItems.Any(x => x.Text == "Return Medication"));

            _page.SelectMenuSubItem("New Request");

            var req = PageBase<NewRequest>.Go;
            var r = new Random();

            req.Patient = "test patient";
            req.SelectPatientType("Test Patient - P00201");

            req.Medication = "pramoxine";
            req.SelectMedicationType("Pramoxine");

            req.SelectAvailableVisit(1);
            req.Prescription = "Testing prescription";
            req.Quantity = r.Next(1, 5).ToString();
            req.Refills = r.Next(5, 10).ToString();
            req.SetPerscriptionDate(DateTime.Now.AddDays(-1));
            req.AddRequest();

            var dialog = req.PopupDialog;
            
            Assert.That(dialog.DialogHeader.Text, Is.EqualTo("Medication Request Saved"));                
            Assert.True(dialog.OkBtn.Displayed);
            Assert.True(dialog.CloseIcon.Displayed);

            dialog.OkBtn.Click();
            
            Assert.That(_page.getViewTitle, Is.EqualTo("New Medication Request"));
        }

    }
}