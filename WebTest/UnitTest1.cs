using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index_Returns_Correct_View()
        {
            var controller = new HomeController();
        }
    }
}
