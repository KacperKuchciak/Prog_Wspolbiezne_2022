namespace Kalkulator
{
    public class Calculator
    {
        private int counter = 0;

        public Calculator()
        {
        }

        public int GetCounter() 
        {
            return counter;
        }

        public double Add(double x, double y)
        {
            counter++;
            return x + y;
        }
        
        public double Subtract(double x, double y)
        {
            counter++;
            return x - y;
        }
        
        public double Multiply(double x, double y)
        {
            counter++;
            return x * y; 
        }
        
        public double Divide(double x, double y)
        {
            counter++;
            return x / y;
        }
    }
}