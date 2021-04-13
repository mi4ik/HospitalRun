using OpenQA.Selenium;
using System;
using System.Linq;

namespace HospitalRun.DOMs
{
    class NewRequest: PageBase<NewRequest>, IPage, IDisposable
    {
        private By patientInput = By.CssSelector("input[id|=patientTypeAhead]");
        private By medicationInput = By.CssSelector("[id|=inventoryItemTypeAhead]");
        private By prescription = By.CssSelector("[id|=prescription]");
        private By visit = By.CssSelector("[id|=visit]");
        private By visitOption = By.CssSelector("option");
        private By date = By.CssSelector("[id|=display_prescriptionDate]");
        private By quantity = By.CssSelector("[id|=quantity]");
        private By refills = By.CssSelector("[id|=refills]");

        private By patientTypeSet = By.CssSelector(".test-patient-input");
        private By medicationTypeSet = By.CssSelector(".test-medication-input");
        private By suggestion = By.CssSelector(".tt-suggestion");

        private By addButton = By.CssSelector(".panel-footer .btn-primary");

        public string Patient
        {
            get
            {
                return _(patientInput).Text;
            }
            set
            {
                _(patientInput).Type(value);
            }
        }

        public string Medication
        {
            get
            {
                return _(medicationInput).Text;
            }
            set
            {
                _(medicationInput).Type(value);
            }
        }

        public string Prescription
        {
            get
            {
                return _(prescription).Text;
            }
            set
            {
                _(prescription).SendKeys(value);
            }
        }

        public string Quantity
        {
            get
            {
                return _(quantity).Text;
            }
            set
            {
                _(quantity).SendKeys(value);
            }
        }

        public string Refills
        {
            get
            {
                return _(refills).Text;
            }
            set
            {
                _(refills).SendKeys(value);
            }
        }

        public void AddRequest()
        {
            _(addButton).Click();

        }

        public void SelectPatientType(string value)
        {
            var patientList = _(patientTypeSet).FindElements(suggestion).ToArray();

            patientList.First(x => x.Text.Contains(value)).Click();
        }

        public void SelectMedicationType(string value)
        {
            var medicationList = _(medicationTypeSet).FindElements(suggestion).ToArray();

            medicationList.First(x => x.Text.Contains(value)).Click();
        }

        public void SelectAvailableVisit(int value)
        {
            _(visit).Click();
            var visitList = _(visit).FindElements(visitOption);

            visitList[value].Click();
        }

        public void SetPerscriptionDate(DateTime value)
        {
            _(date).Clear();
            _(date).SendKeys(value.ToString("MM/dd/yyyy"));
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public NewRequest()
        {

        }
    }
}
