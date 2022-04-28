using System;
using Logic;
using System.Collections.Generic;
using System.Threading;


namespace Model
{
    public abstract class ModelAPI
    {
        internal Logic.LogicAPI logicLayer;
        public List<PresentationSphere> PresentedSpheres;
        public int Width { get; set; }
        public int Height { get; set; }
        public int R { get; set; }
        public static ModelAPI CreateApi()
        {
            return new ModelLayer();
        }

        public abstract void AddSpheres(int howMany);
        public abstract void RemoveSpheres();
        public abstract void MoveSpheres();
        public abstract void PickRandomPositions(int width, int height);
        public abstract bool ChangeSpeed(bool b);
    }

    internal class ModelLayer : ModelAPI
    {
        //We start with construction of the whole ModelAPI.
        public ModelLayer()
        {
            //How big will the spheres be.
            R = 5;
            //If null, then we go with default option (for object it's null).
            logicLayer = logicLayer ?? Logic.LogicAPI.CreateLayer();
            //We copy width and height from logic.
            Width = logicLayer.Field.Width;
            Height = logicLayer.Field.Height;
            //Initializing empty list for spheres stored in logical layer.
            PresentedSpheres = new List<PresentationSphere>();
            //We create presentation of spheres from data layer and place them in the list.
            for (int i = 0; i < logicLayer.GetAll().Count; i++)
            {
                PresentedSpheres.Add(new PresentationSphere(logicLayer.GetAll()[i]));
            }
        }

        //Method for adding random amount of spheres to the presentation layer.
        public override void AddSpheres(int howMany)
        {
            Random rnd = new Random();
            for (int i = 0; i < howMany; i++)
            {
                Sphere s = new Sphere(10, 20, 5);
                logicLayer.AddObject(s);
                PresentedSpheres.Add(new PresentationSphere(s));
            }
        }

        //Removing all spheres from presentation and logic layer.
        public override void RemoveSpheres()
        {
            PresentedSpheres.Clear();
            logicLayer.RemoveAll();
        }
        //Changing speed
        public override bool ChangeSpeed(bool b)
        {
           return logicLayer.ChangeSpeed(b);
        }

        //Triggering movement in logical layer every 15ms.
        public override void MoveSpheres()
        {
            while (true)
            {
                logicLayer.MoveAll();
                Thread.Sleep(15);
            }
        }

        //Ordering logic layer to randomise all positions for spheres.
        public override void PickRandomPositions(int width, int height)
        {
            logicLayer.PickRandomPositions(width, height);
        }
    }
}
