using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCoreFood.Models;
using NETCoreFood.Services;
using NETCoreFood.ViewModels;

namespace NETCoreFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IResturantData _resturantData;
        private IGreeter _greeter;
        private readonly IHomeIndexViewModel _homeIndexViewModel;

        public HomeController(IResturantData resturantData,
                                IGreeter greeter,
                                IHomeIndexViewModel   homeIndexViewModel)
        {
            _resturantData = resturantData;
            _greeter = greeter;
            this._homeIndexViewModel = homeIndexViewModel;
        }
        public IActionResult Index()
        {

            // this will return the JSON result based on the request content type 
            //var res = new Resturant
            //{
            //    Id = 1,
            //    Name = "Bhargava"
            //};
            //return new ObjectResult(res);

            //var res = new Resturant
            //{
            //    Id = 1,
            //    Name = "Bhargava"
            //};

            _homeIndexViewModel.Resturants = _resturantData.GetAll();
            _homeIndexViewModel.CurrentMessage = _greeter.GetMessageOfDay();



            return View(_homeIndexViewModel);

        }


        public IActionResult Details(int id)
        {
            var model = _resturantData.GetResturant(id);

            if(model == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
           
        }
        [HttpGet]
        [Authorize]
        public  IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(ResturantEditViewModel resturant)
        {
            if (ModelState.IsValid)
            {
                var _resturant = new Resturant()
                {
                    Name = resturant.Name,
                    CusineType = resturant.cusineType
                };

                var resturantResult = _resturantData.AddResturant(_resturant);

                // instead of directly returning the view which might cause issue if the user refresh's page
                // because the URL is still /home/create and will re-save the same data again.
                //Instead, we can send / route the user to a different page using RedirectToAction()
                //return View("Details", resturantResult);

                return RedirectToAction(nameof(Details), new { id = resturantResult.Id });
            }
            else
            {
                return View();
            }
        }

    }
}