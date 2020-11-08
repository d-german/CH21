namespace DelegateDriver
{
   public class Adder : IAdder
    {
        public double Add(double l, double r)
        {
            return l + r;
        }
    }
}
