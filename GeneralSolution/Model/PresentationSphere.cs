using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{  
    //This class copes with visual representation of spheres.
    public class PresentationSphere: ISphere
    {
        //Meant for string representation of color we pick.
        public string Color { get; set; }
        //Here we go with diameter instead of radian, cause it works better with GUI.
        public double Diameter { get; }
        public int Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private double y;
        private double x;

        public double Y
        {
            get { return y; }
            set
            {
                if (y == value) return;
                y = value;
                RaisePropertyChanged();
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x == value) return;
                x = value;
                RaisePropertyChanged();
            }
        }

        //Constructor for visual representation of the sphere. Default color is 'red'.
        public PresentationSphere(int id, double top, double left, double radius, string c = "red")
        {
            this.Id = id;
            this.Color = c;
            this.y = top;
            this.x = left;
            this.Diameter = 2 * radius;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
