using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    // Route isteğin hangi yolla geleceğini ifade eder.
    // buradaki controller , products 'tır.
    [Route("api/[controller]")]
    // ATTRIBUTE (JAVA'DA ANNOTATION)
    // Attribute, bir class la ilgili bilgi vermektir.
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled = Gevşek bağlılık, yani baplılığı var ama soyuta bağlı
        //naming convention
        //IoC Container = Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //Dependency chain 

            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
