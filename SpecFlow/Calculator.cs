namespace SpecFlow
{
    /// <summary>
    /// The calculator.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Gets or sets the first number.
        /// </summary>
        public int FirstNumber { private get; set; }

        /// <summary>
        /// Gets or sets the second number.
        /// </summary>
        public int SecondNumber { private get; set; }

        /// <summary>
        /// The add.
        /// </summary>
        public int Add()
        {
            return this.FirstNumber + this.SecondNumber;
        }
    }
}