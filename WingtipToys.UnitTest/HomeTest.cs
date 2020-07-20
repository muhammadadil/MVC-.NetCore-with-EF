using BusinessAccessLayer;
using BusinessAccessLayer.Services;
using DataAccessLayer;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using WingtipToys.Controllers;
using AutoMapper;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using WingtipToys.Models;
namespace Tests
{
    public class Tests
    {
        public  ICategoryServices _categoryServices;
        public  IProductsServices _productsServices;
        public  ILogger<HomeController> _logger;

        private  WingtiptoysContext _wingtiptoysContext;


        [SetUp]
        public void Setup()
        {
            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<CartItems, CartItemsDto>().ReverseMap();
                mapper.CreateMap<Categories, CategoriesDto>().ReverseMap();
                mapper.CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
                mapper.CreateMap<Orders, OrdersDto>().ReverseMap();
                mapper.CreateMap<Products, ProductsDto>().ReverseMap();

            });
            _wingtiptoysContext = new WingtiptoysContext();
             _categoryServices = new CategoryServices(_wingtiptoysContext);
            _productsServices = new ProductsServices(_wingtiptoysContext);
            
        }

        [Test]
        public void IndexTest()
        {           
            HomeController home = new HomeController(_logger, _categoryServices, _productsServices);            
            var result = home.Index();
            Assert.NotNull(result);
            
        }

        [Test]
        public void SearhTest()
        {
            HomeController home = new HomeController(_logger, _categoryServices, _productsServices);
            var result = home.Search("name_desc", "car", "car");
            Assert.NotNull(result);

        }
    }
}