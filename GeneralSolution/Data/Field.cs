
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
        public int SpheresCounter { get; set; } = 0;

        //Basic constructor that doesn't fill the list of spheres, only initializes it.
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            SphereList = new List<Sphere>();
        }

        public int AddSphere()
        {
            Random rnd = new Random();
            int newValue = 5 + rnd.Next(15);
            SphereList.Add(new Sphere(SpheresCounter++));
            getSphere(SpheresCounter - 1).M = newValue / 2;
            getSphere(SpheresCounter - 1).R = newValue;
            return SpheresCounter - 1;
        }

        //Adding new object to the list.
        public void AddToList(Sphere s)
        {
            if (!(s is null))
            {
                SphereList.Add(s);
            }
        }

        //Removing object from the list.
        public void RemoveFromList(Sphere s)
        {
            if (!(s is null))
            {
                SphereList.Remove(s);
            }
        }

        public Sphere getSphere(int Id)
        {
            return SphereList[Id];
        }

    }
}
