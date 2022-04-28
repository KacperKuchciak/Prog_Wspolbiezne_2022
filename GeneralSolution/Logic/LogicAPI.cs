using Data;
using System.Collections.Generic;

namespace Logic
{
        public abstract class LogicAPI
        {
            //Abstract methods of our API.
            public Field Field { get; set; }
            public abstract void MoveAll();
            public abstract void AddObject(Sphere ball);
            public abstract void RemoveObject(Sphere ball);
            public abstract void RemoveAll();
            public abstract bool ChangeSpeed(bool change);
            public abstract List<Sphere> GetAll();
            public abstract void PickRandomPositions(int width, int height);

            //We create bussiness logic.
            public static LogicAPI CreateLayer(DataAPI data = default)
            {
                //If null, then we go with default option (for object it's null).
                return new BusinessLogic(data ?? DataAPI.CreateDataLayer());
            }

            //This class implements our abstract API.
            private class BusinessLogic : LogicAPI
            {
                private readonly DataAPI DataLayer;

                //Constructor creates a field object and requiers DataAPI object or NULL(defauklt, when Data layer is not used).
                public BusinessLogic(DataAPI api)
                {
                    DataLayer = api;
                    Field = new Field(350, 350);
                }
                //Allows us to change speed while making sure that we don't slow it down to zero
                public override bool ChangeSpeed(bool b)
                {
                    bool inc = true;
                    bool dec = true;
                    for (int i = 0; i < Field.SphereList.Count; i++)
                    {
                        if (Field.SphereList[i].Speed <= 1)
                            dec = false;
                        if (Field.SphereList[i].Speed >= 20)
                            inc = false;
                    }
                    if ((b && !inc) || (!b && !dec))
                    {
                        return false;
                    }
                    for (int j = 0; j < Field.SphereList.Count; j++)
                    {
                        if (b && inc)
                        {
                            Field.SphereList[j].Speed = (Field.SphereList[j].Speed + 1);
                        }
                        else if (dec)
                        {
                            Field.SphereList[j].Speed = (Field.SphereList[j].Speed - 1);
                        } 
                    }
                    return true;
                }
            //Move all spheres using method from field.
            public override void MoveAll()
                {
                    Field.MoveAll();
                }

                //Adding new sphere to our field.
                public override void AddObject(Sphere s)
                {
                    Field.AddToList(s);
                }

                //Removing a sphere from the field.
                public override void RemoveObject(Sphere s)
                {
                    Field.RemoveFromList(s);
                }

                //Getting a list of all spheres present in the field.
                public override List<Sphere> GetAll()
                {
                    return Field.SphereList;
                }

                //Uses method from sphere class to randomise position of every sphere in the field.
                public override void PickRandomPositions(int width, int height)
                {
                    for (int i = 0; i < Field.SphereList.Count; i++)
                    {
                        Field.SphereList[i].PickRandomPosition(Field.Width, Field.Height);
                    }
                }

                //Cleares the field of all spheres using it's method.
                public override void RemoveAll()
                {
                    Field.RemoveAll();
                }
        }
    }
}
