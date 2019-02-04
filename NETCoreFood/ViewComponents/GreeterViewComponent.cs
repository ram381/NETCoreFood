using Microsoft.AspNetCore.Mvc;
using NETCoreFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreFood.ViewComponents
{
    public class GreeterViewComponent: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter )
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfDay();
            return View("Default", model);
        }

    }
}
