using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NETCoreFood.Services;
using NETCoreFood.Models;
namespace NETCoreFood.Pages.Resturants
{
    public class ResturantsModel : PageModel
    {
        private IResturantData _resturantdata;

        [BindProperty]
        public NETCoreFood.Models.Resturant  resturant { get; set; }

        public ResturantsModel(IResturantData resturantData )
        {
            _resturantdata = resturantData;
        }
        public IActionResult OnGet(int id)
        {
            resturant= _resturantdata.GetResturant(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
             resturant= _resturantdata.UpdateResturant(resturant);
                return RedirectToAction("Details", "Home", new { id = resturant.Id });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}