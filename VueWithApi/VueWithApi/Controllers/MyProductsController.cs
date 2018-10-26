using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueWithApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VueWithApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyProductsController : ControllerBase
    {
        [HttpGet]
        [Authorize(nameof(Permission.ViewMyProducts))]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        [Authorize(nameof(Permission.ViewMyProducts))]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Authorize(nameof(Permission.CreateProduct))]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        [Authorize(nameof(Permission.UpdateSpecificProduct))]
        public void Put(int id, [FromBody] string value)
        {
            var product = new Product()
            {
                Id = 2,
                Name = "Example",
                Owner = "bob"
            };
            // more complex permission checks can be handled in code
            if (User.Can(Permission.ViewAnyProducts) || User.Can(Permission.UpdateSpecificProduct, product))
            {

            }
        }

        [HttpDelete("{id}")]
        [Authorize(nameof(Permission.DeleteMyProducts))]
        public void Delete(int id)
        {
        }
    }
}
