namespace BDD.Models
{
    /// <summary>
    /// The calculation interface.
    /// </summary>
    public interface ICalculationModel
    {
        /// <summary>
        /// Add two decimal values.
        /// </summary>
        decimal AddTwoValues(decimal value1, decimal value2);
    }
}