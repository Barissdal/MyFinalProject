using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // iş kodları

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır.");
            }

            _productDal.Add(product);
            //bunu yapabilmenin yöntemi bir tane Constructor eklemektir
            //return new Result(true,"Ürün eklendi.");

            //return new SuccessResult("Ürün eklendi.");

            return new SuccessResult();
        }

        public List<Product> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return _productDal.GetAll();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        List<Product> IProductService.GelAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }
    }
}
