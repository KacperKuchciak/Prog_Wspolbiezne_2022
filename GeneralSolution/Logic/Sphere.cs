using System;

namespace Logic
{
    //This class defines all the properties of spheres, that we are going to use and some methods connected to them.
    public class Sphere
    {
        //Properties:
        private Random randomiser = new Random();
        public int R { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Direction_X { get; set; }
        public double Direction_Y { get; set; }
        public double Speed { get; set; }

        //Constructor assigning to a sphere it's position in 2D and radius (how big it is).
        public Sphere(double x = 10, double y = 10, int r = 5)
        {
            R = r;
            X = x;
            Y = y;
            PickRandomDirection();
        }

        //Function that allows us to pick random starting positions for the spheres.
        public void PickRandomPosition(int width, int height)
        {
            //We use max width and hight - R*4, beacuse we want the balls to start with some distance from the edge of our window.
            this.X = this.R * 4 + randomiser.Next(width - this.R * 8);
            this.Y = this.R * 4 + randomiser.Next(height - this.R * 8);
        }

        public void PickRandomDirection()
        {
            //Changes speed.
            this.Speed = 1 + randomiser.Next(10);

            //We pick randomly either -1 or 1.
            int X_axis = randomiser.Next(2) == 1 ? 1 : -1;
            int Y_axis = randomiser.Next(2) == 1 ? 1 : -1;

            //Finally we randomise where we are moving to.
            this.Direction_X = (double)(0.0001 * X_axis * (1 + randomiser.Next(10000)));
            this.Direction_Y = (double)(0.0001 * Y_axis * (1 + randomiser.Next(10000)));
        }

        //This method makes a single sphere change it's position towards the direction.
        public void Move(int width, int height)
        {
            //If the ball is about to hit the edge of the screen, we alternate the direction (hight, width - upper boudries, 0 - lower boundries).
            if (X + R * 2 + Direction_X * Speed > width || X + Direction_X * Speed < 0)
                AlternateDirection('x');
            if (Y + R * 2 + Direction_Y * Speed > height || Y + Direction_Y * Speed < 0)
                AlternateDirection('y');

            //We move some distance that is increased by given speed.
            X += Direction_X * Speed;
            Y += Direction_Y * Speed;

        }

        //Here we change direction of one axis if the sphere reaches the screen's edge.
        public void AlternateDirection(char whichDirection)
        {
            if (whichDirection == 'x')
                this.Direction_X = -this.Direction_X;
            else if (whichDirection == 'y')
                this.Direction_Y = -this.Direction_Y;
        }
    }
}