namespace DelegateDriver
{
    public class MyAdderInterface
    {
        private readonly IAdder _adder;

        public MyAdderInterface(IAdder adder)
        {
            _adder = adder;
        }

        public double Add(double l, double r)
        {
            return _adder.Add(l, r);
        }
    }
}
