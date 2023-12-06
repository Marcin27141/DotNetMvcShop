namespace DotnetList5Task2.Models
{
    public class ToolViewModel
    {
        public int NumberOfResults { get; set; }
        public double LowerResult { get; set; } = 0;
        public double HigherResult { get; set; } = 0;
        public int aCoefficient { get; set; }

        public char bCoefficientSign { get; set; }
        public int bCoefficientAbsolute { get; set; }

        public char cCoefficientSign { get; set; }
        public int cCoefficientAbsolute { get; set; }
    }
}
