namespace DelegateDriver
{
    public class MyAdderDelegate
    {
        private readonly AdderDelegate _adderDelegate;

        public MyAdderDelegate(AdderDelegate adderDelegate)
        {
            _adderDelegate = adderDelegate;
        }

        public double Add(double l, double r)
        {
            return _adderDelegate(l, r);
        }
    }
}
