using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneApiApp.Models;
using OneApiApp.Models.Interface;

namespace OneApiApp.Controllers
{

    [Route("")]
    public class FibonacciController : Controller
    {
        private readonly ILogger<FibonacciController> _logger;
        private readonly IFibonacciModel _fibonacciModel;

        public FibonacciController(ILogger<FibonacciController> logger, IFibonacciModel fibonacciModel)
        {
            _logger = logger;
            _fibonacciModel = fibonacciModel;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("{number}")]
        public IActionResult Get(int number)
        {
            _logger.LogInformation(1, $"Getting Fibomacci");
            try
            {
                if (number ==  0)
                {
                    var query = HttpContext.Request.Query.First();
                    number = Convert.ToInt32(query.Value);

                }
                var result = _fibonacciModel.GetNextFibonacciNumber(number);
                ViewBag.Result = result;
            }
            catch (Exception ex)
            {
                ViewBag.Result = $"Wrong Input Provided. {ex.Message}";
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
