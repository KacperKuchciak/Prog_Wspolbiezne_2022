
using Logic;

namespace Model
{  
    //This class copes with visual representation of spheres.
    public class PresentationSphere
    {
        //We need logics of sphere from logic layer in order to present that sphere.
        private readonly Logic.Sphere Sphere;

        //Meant for string representation of color we pick.
        public string Color { get; set; }

        //We take Radius times 2 from logic.
        public int Radius { get { return Sphere.R * 2; } }
        //And Speed (probably will be removed in finall build)
        public double Speed { get { return Sphere.Speed; } }

        //Getters hand over some info about position of the sphere in logical spectrum. No setting in presentation layer, of course.
        public double Position_X { get { return Sphere.X; } }
        public double Position_Y { get { return Sphere.Y; } }

        //The same for direction the ball moves towards.
        public double Direction_X { get { return Sphere.Direction_X; } }
        public double Direction_Y { get { return Sphere.Direction_Y; } }



        //Constructor for visual representation of the sphere. Default color is 'red'.
        public PresentationSphere(Sphere s, string c = "red")
        {
            this.Color = c;
            this.Sphere = s;
        }
    }
}
