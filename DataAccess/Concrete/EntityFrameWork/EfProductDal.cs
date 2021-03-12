using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFrameWork
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             CategoryName = c.CategoryName,
                             UnitsInStock = p.UnitsInStock};

                // result çünkü IQuaryable oyüzden list olarak döndürmeliyiz.
                return result.ToList();

            }
        }
    }
}
