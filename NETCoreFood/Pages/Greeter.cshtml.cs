using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NETCoreFood.Services;

namespace NETCoreFood.Pages
{
    public class GreeterModel : PageModel
    {
        private IGreeter _greeter;

        public string Message { get; set; }
        public GreeterModel(IGreeter greeter )
        {
            _greeter = greeter;
        }
        public void OnGet(string name)
        {
            Message = $"{name}: ${_greeter.GetMessageOfDay()}";
        }
    }
}