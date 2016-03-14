using BDD.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BDD.Controllers
{
    /// <summary>
    /// The calculation controller.
    /// </summary>
    public class CalculationController : ApiController
    {
        private readonly ICalculationModel _calculationModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationController"/> class.
        /// </summary>
        public CalculationController(ICalculationModel calculationModel)
        {
            if (calculationModel == null)
            {
                throw new ArgumentNullException(nameof(calculationModel));
            }

            _calculationModel = calculationModel;
        }

        [HttpGet]
        [Route("api/Calculation/add/{value1}/{value2}")]
        public HttpResponseMessage Add(decimal value1, decimal value2)
        {
            try
            {
                decimal sum = _calculationModel.AddTwoValues(value1, value2);

                return Request.CreateResponse(HttpStatusCode.OK, sum);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}