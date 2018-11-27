using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Test initialize");                      
        }

        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = CodePassword.getCodPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual, "Expected is NOT equal with Actual");
            Debug.WriteLine("Assert test success");
        }

        [TestMethod]
        public void getPassword_bcd_abc()
        {
            // arrange
            string strIn = "bcd";
            string strExpected = "abc";

            // act
            string strActual = CodePassword.getPassword(strIn);

            // assert
            Assert.AreEqual(strExpected, strActual, "Expected is NOT equal with Actual" );
            Debug.WriteLine("Assert test success");
        }

        [TestMethod]
        public void getPassword_bcd_FAIL()
        {
            // arrange
            string strIn = "bcd";
            string strExpected = "abcd";

            // act
            string strActual = CodePassword.getPassword(strIn);

            // assert
            Assert.AreEqual(strExpected, strActual, "Expected is NOT equal with Actual");            
            Debug.WriteLine("Assert test success");
        }

        [TestMethod]
        public void getCodPassword_StringAssert_abc_bcd()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = CodePassword.getCodPassword(strIn);

            //assert
            StringAssert.Contains(strExpected, strActual, "Expected is NOT equal with Actual");
            Debug.WriteLine("StringAssert test success");
        }

        [TestMethod]
        public void getPassword_StringAssert_bcd_abc()
        {
            // arrange
            string strIn = "bcd";
            string strExpected = "abc";

            // act
            string strActual = CodePassword.getPassword(strIn);

            // assert
            StringAssert.Contains(strExpected, strActual, "Expected is NOT equal with Actual");
            Debug.WriteLine("StringAssert test success");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("Test cleanup");
        }
    }
}
