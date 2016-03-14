namespace BDD.Models
{
    /// <summary>
    /// The calculation model.
    /// </summary>
    public class CalculationModel : ICalculationModel
    {
        /// <summary>
        /// Add two decimal values.
        /// </summary>
        public decimal AddTwoValues(decimal value1, decimal value2)
        {
            return value1 + value2;
        }
    }
}