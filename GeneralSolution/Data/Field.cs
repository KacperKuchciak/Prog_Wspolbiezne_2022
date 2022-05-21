
using System;
using System.Collections.Generic;

namespace DataLayer
{
    //This class deals with operations we are going to perform with the field the spheres are moving within.
    public class Field
    {
        //Properties: width, height of the field, list of all spheres in it
        public List<Sphere> SphereList { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        //Special property for counting how many spheres the field contains.
        public int SpheresCounter { get; set; } = 0;

        //Basic constructor that doesn't fill the list of spheres, only initializes it.
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            SphereList = new List<Sphere>();
        }

        //Creating a sphere with random radian, mass based on it and identifier based on how many spheres are already in.
        public int AddSphere()
        {
            Random rnd = new Random();
            int newValue = 5 + rnd.Next(5);
            SphereList.Add(new Sphere(SpheresCounter++));
            GetSphere(SpheresCounter - 1).M = newValue / 2;
            GetSphere(SpheresCounter - 1).R = newValue;
            return SpheresCounter - 1;
        }

        //Simple getter for spheres that DataAPI can use.
        public Sphere GetSphere(int Id)
        {
            return SphereList[Id];
        }

    }
}
