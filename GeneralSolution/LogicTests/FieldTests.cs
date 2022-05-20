using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
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
        public void AddToListTest()
        {
            Field f = new Field(100, 110);
            Sphere s = new Sphere(10, 10, 1);
            f.AddToList(s);
            Assert.AreEqual(1, f.SphereList.Count);
            Assert.AreEqual(s, f.SphereList[0]);
        }

        [TestMethod]
        public void AddToListNullObjectTest()
        {
            Field f = new Field(100, 110);
            f.AddToList(null);
            Assert.AreEqual(0, f.SphereList.Count);
        }

        [TestMethod]
        public void RemoveFromListTest()
        {
            Field f = new Field(100, 110);
            Sphere s = new Sphere(10, 10, 1);
            f.AddToList(s);
            Assert.AreEqual(1, f.SphereList.Count);
            Assert.AreEqual(s, f.SphereList[0]);
            f.RemoveFromList(s);
            Assert.AreEqual(0, f.SphereList.Count);
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

        //[TestMethod]
        //public void ChangeSpeedAllowedTest()
        //{
        //    Sphere s1 = new Sphere(1, 10, 10, 1);
        //    s1.Speed = 19;
        //    LogicAPI api = Logic.LogicAPI.CreateLayer();
        //    api.AddObject(s1);
        //    api.ChangeSpeed(true);
        //    Assert.AreEqual(20, api.GetSphere(0).Speed);
        //    api.ChangeSpeed(false);
        //    api.ChangeSpeed(false);
        //    Assert.AreEqual(18, api.GetSphere(0).Speed);
        //}

        //[TestMethod]
        //public void ChangeSpeedNotAllowedTest()
        //{
        //    Sphere s1 = new Sphere(10, 10, 1);
        //    s1.Speed = 1;
        //    LogicAPI api = Logic.LogicAPI.CreateLayer();
        //    api.AddObject(s1);
        //    api.ChangeSpeed(false);
        //    Assert.AreEqual(1, api.GetSphere(0).Speed);
        //}

        //[TestMethod]
        //public void MoveAllTest()
        //{
        //    Field f = new Field(100, 110);
        //    Sphere s1 = new Sphere(0, 10, 10, 1);
        //    Sphere s2 = new Sphere(1, 20, 20, 1);
        //    Sphere s3 = new Sphere(2, 30, 30, 1);
        //    s1.Direction_X = 0.1;
        //    s1.Direction_Y = 0.1;
        //    s2.Direction_X = 0.1;
        //    s2.Direction_Y = 0.1;
        //    s3.Direction_X = -0.1;
        //    s3.Direction_Y = -0.1;
        //    s1.Speed = 1;
        //    s2.Speed = 2;
        //    s3.Speed = 3;
        //    f.AddToList(s1);
        //    f.AddToList(s2);
        //    f.AddToList(s3);
        //    f.MoveAll();
        //    Assert.AreEqual(f.SphereList[0].X, 10.1);
        //    Assert.AreEqual(f.SphereList[0].Y, 10.1);
        //    Assert.AreEqual(f.SphereList[1].X, 20.2);
        //    Assert.AreEqual(f.SphereList[1].Y, 20.2);
        //    Assert.AreEqual(f.SphereList[2].X, 29.7);
        //    Assert.AreEqual(f.SphereList[2].Y, 29.7);

        //}

    }
}
