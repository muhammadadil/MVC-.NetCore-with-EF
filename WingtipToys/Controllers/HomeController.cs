using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessAccessLayer;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingtipToys.Models;

namespace WingtipToys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryServices _categoryServices;        
        private readonly IProductsServices _productsServices;
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger,ICategoryServices categoryServices, IProductsServices productsServices)
        {          
            _categoryServices = categoryServices;           
            _productsServices = productsServices;
            _logger = logger;
        }        

        public IActionResult Index()
        {
            try
            {
                string name = "Cars";                  

                Categories category = _categoryServices.GetByName(name);
                CategoriesDto categoryResult = Mapper.Map<CategoriesDto>(category);

                return View(categoryResult.Products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }
        
        public async Task<IActionResult> Search(string sortOrder,string currentFilter,string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["UnitPriceSortParm"] = sortOrder == "Price" ? "Price_desc" : "Price";
           
            if (searchString != null)
            {
                if (searchString.Length < 2)
                {
                    ViewData["CurrentFilterError"] = "Min character Limt 2.";
                    return View();
                }              
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<Products> products = _productsServices.GetAll().ToList();
            List<ProductsDto> productsResult = Mapper.Map<List<ProductsDto>>(products);

            if (!String.IsNullOrEmpty(searchString))
            {
                productsResult = productsResult.Where(s => s.ProductName.Contains(searchString.Trim())
                                       || s.Description.Contains(searchString.Trim())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    productsResult = productsResult.OrderByDescending(s => s.ProductName).ToList();
                    break;
                case "Price":
                    productsResult = productsResult.OrderBy(s => s.UnitPrice).ToList();
                    break;
                case "Price_desc":
                    productsResult = productsResult.OrderByDescending(s => s.UnitPrice).ToList();
                    break;
                default:
                    productsResult = productsResult.OrderBy(s => s.ProductName).ToList();
                    break;
            }
            return View(productsResult);
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
