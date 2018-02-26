namespace nDeath.WEB.Models
{
    public class PointsViewModel
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointsViewModel(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}