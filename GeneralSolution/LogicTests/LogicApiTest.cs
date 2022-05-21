using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTests
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            LogicAPI api = LogicAPI.CreateLayer();
            Assert.IsNotNull(api);
            Assert.AreEqual(api.CountSpheres(), 0);
        }

        [TestMethod]
        public void AddingSpheresTest()
        {
            LogicAPI api = LogicAPI.CreateLayer();
            api.AddObject();
            Assert.AreEqual(api.CountSpheres(), 1);
            api.AddObject();
            api.AddObject();
            Assert.AreEqual(api.CountSpheres(), 3);
        }

        [TestMethod]
        public void AddingSpheresRightIdentifierTest()
        {
            LogicAPI api = LogicAPI.CreateLayer();
            api.AddObject();
            Assert.IsNotNull(api.GetSphereRadius(0));
            api.AddObject();
            api.AddObject();
            Assert.IsNotNull(api.GetSphereRadius(1));
            Assert.IsNotNull(api.GetSphereRadius(2));
        }
    }
}
