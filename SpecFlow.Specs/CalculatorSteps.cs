namespace SpecFlow.Specs
{
    using NUnit.Framework;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The calculator steps.
    /// </summary>
    [Binding]
    public class CalculatorSteps
    {
        /// <summary>
        /// The _calculator.
        /// </summary>
        private readonly Calculator calculator = new Calculator();

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        private int Result { get; set; }

        /// <summary>
        /// Given i have entered into the calculator.
        /// </summary>
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            this.calculator.FirstNumber = number;
        }

        /// <summary>
        /// Given i have also entered into the calculator.
        /// </summary>
        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            this.calculator.SecondNumber = number;
        }

        /// <summary>
        /// When i press add.
        /// </summary>
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            this.Result = this.calculator.Add();
        }

        /// <summary>
        /// Then the result should be on the screen.
        /// </summary>
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, this.Result);
        }
    }
}