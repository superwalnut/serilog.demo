using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace serilog.web.Controllers
{
    using Serilog;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILogger _logger;
        public ValuesController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("get1")]
        public ActionResult Get1()
        {
            string value1 = "peter";
            int value2 = 3;
            bool value3 = false;
            DateTime value4 = DateTime.Now;
            Guid value5 = Guid.NewGuid();

            _logger.Information("get the {value1} & {value2} & {value3} & {value4} & {value5}", value1, value2, value3, value4, value5);

            return Ok();
        }

        [HttpGet("get2")]
        public ActionResult Get2()
        {
            var val = new[] { "aaa", "bbb", "ccc" };

            _logger.Information("get the {val}", val);

            return Ok();
        }

        [HttpGet("get3")]
        public ActionResult Get3()
        {
            var val = new Person { FirstName = "Tom", LastName = "Peter" };

            _logger.Information("get the {@val}", val);

            return Ok();
        }

        [HttpGet("get4")]
        public ActionResult Get4()
        {
            var val = new Person { FirstName = "Tom", LastName = "Peter" };

            _logger.Information("get the {$val}", val);

            return Ok();
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
