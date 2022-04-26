
using System.Collections.Generic;

namespace Logic
{
    //This class deals with operations we are going to perform with the field the spheres are moving within.
    public class Field
    {
        //Properties: width, height of the field, list of all spheres in it
        public List<Sphere> SphereList { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        //Basic constructor that doesn't fill the list of spheres, only initializes it.
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            SphereList = new List<Sphere>();
        }

        //This constructor uses the basic one and creates required amount of spheres in fixed positions.
        public Field(int howMany, int width, int height) : this(width, height)
        {
            for (int i = 0; i < howMany; i++)
            {
                SphereList.Add(new Sphere(10, 20, 5));
            }
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

        public void RemoveAll() 
        {
            SphereList.Clear();
        }

        //We activate 'move' method for all spheres from the list.
        public void MoveAll()
        {
            for (int i = 0; i < SphereList.Count; i++)
            {
                SphereList[i].Move(this.Width, this.Height);
            }
        }
    }
}
