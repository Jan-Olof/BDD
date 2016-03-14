using BDD.Controllers;
using BDD.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BDD.Tests.Controllers
{
    /// <summary>
    /// Feature: Calculator
    ///
    /// In order to avoid silly mistakes
    /// As a math idiot
    /// I want to be told the sum of two numbers
    /// </summary>
    [TestClass]
    public class CalculationControllerTests
    {
        private ICalculationModel _calculationModel;

        /// <summary>
        /// The set up.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _calculationModel = Substitute.For<ICalculationModel>();
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        [TestCleanup]
        public void TearDown()
        {
        }

        /// <summary>
        /// Scenario: Add two numbers
        /// Given I have entered 50 into the calculator
        /// And I have also entered 70 into the calculator
        /// When I call the add method
        /// Then the add method should return OK and the result 120
        /// </summary>
        [TestMethod]
        public void TestShouldAdd50And70()
        {
            // Given
            var sut = CreateRegistrationController();

            const decimal value1 = 50;
            const decimal value2 = 70;

            // When
            var result = sut.Add(value1, value2);

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var jsonString = result.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<decimal>(jsonString);

            Assert.AreEqual(120, content);
        }

        /// <summary>
        /// Scenario: Add two numbers
        /// Given I have entered 50 into the calculator
        /// And I have also entered 70 into the calculator
        /// When I call the add method
        /// Then the add method should return OK and the result 120
        /// </summary>
        [TestMethod]
        public void TestShouldAdd50And70WithStub()
        {
            // Given
            _calculationModel.AddTwoValues(50, 70).Returns(120);

            var sut = CreateRegistrationControllerWithStub();

            const decimal value1 = 50;
            const decimal value2 = 70;

            // When
            var result = sut.Add(value1, value2);

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var jsonString = result.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<decimal>(jsonString);

            Assert.AreEqual(120, content);
        }

        private static CalculationController CreateRegistrationController()
        {
            var controller = new CalculationController(new CalculationModel());

            controller.Request = new HttpRequestMessage();
            controller.Request.Properties["MS_HttpConfiguration"] = new HttpConfiguration();
            controller.Request.RequestUri = new Uri("http://localhost:9041/api/");

            return controller;
        }

        private CalculationController CreateRegistrationControllerWithStub()
        {
            var controller = new CalculationController(_calculationModel);

            controller.Request = new HttpRequestMessage();
            controller.Request.Properties["MS_HttpConfiguration"] = new HttpConfiguration();
            controller.Request.RequestUri = new Uri("http://localhost:9041/api/");

            return controller;
        }
    }
}