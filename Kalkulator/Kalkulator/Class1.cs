namespace Kalkulator
{
    public abstract class Calculator
    {

        public Calculator()
        {
        }

        private int counter = 0;
        public int Add(int x, int y)
        {
            counter++;
            return x + y;
        }
        
        public int Subtract(int x, int y)
        {
            counter++;
            return x - y;
        }
        
        public int Multiply(int x, int y)
        {
            counter++;
            return x * y; 
        }
        
        public double Divide(int x, int y)
        {
            counter++;
            return x / y;
        }
    }
}