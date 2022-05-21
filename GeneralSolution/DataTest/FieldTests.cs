using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;

namespace LogicTests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Field f = new Field(100, 110);
            Assert.AreEqual(f.Height, 110);
            Assert.AreEqual(f.Width, 100);
            Assert.AreEqual(f.SphereList.Count, 0);
        }

        [TestMethod]
        public void AddSphereTest()
        {
            Field f = new Field(100, 110);
            f.AddSphere();
            Assert.AreEqual(1, f.SphereList.Count);
        }

        [TestMethod]
        public void AddSphereProperIdTest()
        {
            Field f = new Field(100, 110);

            f.AddSphere();
            Assert.AreEqual(f.GetSphere(0), f.SphereList[0]);

            f.AddSphere();
            Assert.AreEqual(f.GetSphere(1), f.SphereList[1]);

            f.AddSphere();
            Assert.AreEqual(f.GetSphere(2), f.SphereList[2]);
        }

        [TestMethod]
        public void MovementWorkingTest()
        {
            Sphere s1 = new Sphere(1, 10, 10, 1);
            s1.Speed = 1;
            s1.Direction_X = 1;
            s1.Direction_Y = 1;
            s1.Move();
            Assert.AreEqual(11, s1.X);
            Assert.AreEqual(11, s1.Y);
            s1.Move();
            Assert.AreEqual(12, s1.X);
            Assert.AreEqual(12, s1.Y);
        }

    }
}
