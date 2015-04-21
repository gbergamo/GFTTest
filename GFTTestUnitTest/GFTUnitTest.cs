using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFTTest;

namespace GFTTestUnitTest
{
    /// <summary>
    /// Summary description for GFTUnitTest
    /// </summary>
    [TestClass]
    public class GFTUnitTest
    {
        public GFTUnitTest()
        {}

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TimeOfDayIsMorningOrNight()
        {
            const bool valueExpected = false;
            const string command = "Afternoon, 1, 2, 3";

            IBusiness biz = new Business();
            List<string> list = Utils.GetWordTypedList(command);
            bool valueActual = biz.ValidateTimeOfDay(list.First());

            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void TheFoodMustFollowTheOrder()
        {
            const string valueExpected = "eggs, toast, coffee";
            const string command = "morning, 2, 3, 1";

            IBusiness biz = new Business();
            List<string> list = Utils.GetWordTypedList(command);
            string valueActual = biz.ApplyRules(list);

            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void WhenItsMorningAndInput_Dessert_ReturnError()
        {
            const bool valueExpected = false;
            const string command = "morning, 4";

            IBusiness biz = new Business();
            List<string> list = Utils.GetWordTypedList(command);
            bool valueActual = biz.ValidateOrder(list);

            Assert.AreEqual(valueExpected, valueActual);
        }        

        [TestMethod]
        public void InputIsNotCaseSensitive()
        {
            const string valueExpected = "eggs";
            const string command = "MoRnInG, 1";

            IBusiness biz = new Business();
            List<string> list = Utils.GetWordTypedList(command);
            string valueActual = biz.ApplyRules(list);

            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void InTheMorningOrderMultipleCoffees()
        {
            const string valueExpected = "coffee(x3)";
            const string command = "morning, 3, 3, 3";

            IBusiness biz = new Business();
            List<string> list = Utils.GetWordTypedList(command);
            string valueActual = biz.ApplyRules(list);

            Assert.AreEqual(valueExpected, valueActual);
        }

        [TestMethod]
        public void InTheNightOrderMultiplePotatoes()
        {
            const string valueExpected = "potato(x3)";
            const string command = "night, 2, 2, 2";

            IBusiness biz = new Business();
            List<string> list = Utils.GetWordTypedList(command);
            string valueActual = biz.ApplyRules(list);

            Assert.AreEqual(valueExpected, valueActual);
        }
    }
}
