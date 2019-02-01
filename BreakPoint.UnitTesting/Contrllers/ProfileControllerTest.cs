using BreakPoint.App.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BreakPoint.UnitTesting.Contrllers
{
    [TestClass]
    public class ProfileControllerTest
    {
        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }
    }
}
