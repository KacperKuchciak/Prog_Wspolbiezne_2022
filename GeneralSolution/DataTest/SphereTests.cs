using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;

namespace LogicTests
{
    [TestClass]
    public class SphereTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Sphere s = new Sphere(0,10, 12, 7);
            Assert.AreEqual(s.X, 10);
            Assert.AreEqual(s.Y, 12);
            Assert.AreEqual(s.R, 7);
            Assert.AreEqual(s.Id, 0);
        }

        [TestMethod]
        public void ConstructorDefaultParametersTest()
        {
            //Default is 10, 10, 5
            Sphere s = new Sphere(0);
            Assert.AreEqual(s.X, 10);
            Assert.AreEqual(s.Y, 10);
            Assert.AreEqual(s.R, 5);
            Assert.AreEqual(s.Id, 0);
        }

        [TestMethod]
        public void PickingRandomPositionsTest()
        {
            //Default is 10, 10, 5
            Sphere s = new Sphere(0);
            //Performed 100 times there is a high chance we will find an error, if there is any.
            for (int i = 0; i < 100; i++)
            {
                s.PickRandomPosition(100, 100);
                Assert.IsTrue(s.X >= 20 && s.X <= 80);
                Assert.IsTrue(s.Y >= 20 && s.Y <= 80);
            }
         }

        [TestMethod]
        public void PickingRandomPositionsIsDifferentTest()
        {
            Sphere s = new Sphere(0);
            double x;
            double y;
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                x = s.X; y = s.Y;
                s.PickRandomPosition(100, 100);
                if (s.X != x && s.Y != y)
                {
                    count++;
                }
            }
            Assert.IsTrue(count >= 70);
        }

        public void PickingRandomDirectionsTest()
        {
            //Default is 10, 10, 5
            Sphere s = new Sphere(0);
            //Performed 100 times there is a high chance we will find an error, if there is any.
            for (int i = 0; i < 100; i++)
            {
                s.PickRandomDirection();
                Assert.IsTrue(s.Direction_X >= 0.0001 && s.Direction_X <= 1);
                Assert.IsTrue(s.Direction_Y >= 0.0001 && s.Direction_Y <= 1);
            }
        }

        [TestMethod]
        public void PickingRandomDirectionsIsDifferentTest()
        {
            Sphere s = new Sphere(0);
            double d_x;
            double d_y;
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                d_x = s.Direction_X; d_y = s.Direction_Y;
                s.PickRandomPosition(100, 100);
                if (s.X != d_x && s.Y != d_y)
                {
                    count++;
                }
            }
            Assert.IsTrue(count >= 70);
        }

        //[TestMethod]
        //public void MoveWhenNotOnTheEdgeTest()
        //{
        //    //It starts with X and Y equal 10, so we are going to have a lot of space to move. Especially with speed 1.
        //    Sphere s = new Sphere(50, 50, 10);
        //    s.PickRandomDirection();
        //    double d_x = s.Direction_X;
        //    double d_y = s.Direction_Y;
        //    double x;
        //    double y;
        //    x = s.X; y = s.Y;
        //    s.Move(100, 100);
        //    Assert.AreEqual(x, s.X - s.Direction_X * s.Speed);
        //    Assert.AreEqual(y, s.Y - s.Direction_Y * s.Speed);
        //}

        //[TestMethod]
        //public void MoveWhenEdgeColissionAssuredTest()
        //{
        //    //It starts with X and Y equal 10, so we are going to have a lot of space to move. Especially with speed 1.
        //    Sphere s = new Sphere(0, 97, 97, 1);
        //    s.Direction_X = 3.001;
        //    s.Direction_Y = 0.001;
        //    s.Speed = 1;
        //    s.Move(100, 100);
        //    Assert.AreEqual(s.X,93.999 );
        //    Assert.AreEqual(s.Y, 97.001);
        //}
    }
}