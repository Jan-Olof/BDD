namespace BDD.Tests.Models
{
    using BDD.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Feature: Calculator
    /// In order to avoid silly mistakes
    /// As a math idiot
    /// I want to be told the sum of two numbers
    /// </summary>
    [TestClass]
    public class CalculationModelTests
    {
        /// <summary>
        /// Scenario: Add two numbers
        /// Given I have entered 50 into the calculator
        /// And I have also entered 70 into the calculator
        /// When I call the add two values method
        /// Then the add method should return 120
        /// </summary>
        [TestMethod]
        public void TestShouldAdd50And70()
        {
            // Given
            var sut = CreateCalculationModel();

            const decimal Value1 = 50;
            const decimal Value2 = 70;

            // When
            var result = sut.AddTwoValues(Value1, Value2);

            // Then
            Assert.AreEqual(120, result);
        }

        /// <summary>
        /// Create calculation model.
        /// </summary>
        private static ICalculationModel CreateCalculationModel()
        {
            return new CalculationModel();
        }
    }
}