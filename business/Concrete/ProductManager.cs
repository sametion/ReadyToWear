﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //business codes
            _productDal.Add(product);
            return new Result(true,"product has added");
        }

        public List<Product> GetAll()
        {
                 return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(c=>c.CategoryId==id);
        }

        public Product GetById(int productId)
        {
               return _productDal.Get(p=>p.ProductId==productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=> p.UnitPrice<max && p.UnitPrice>min);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
