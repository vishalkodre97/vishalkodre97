﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult index()
        {
            return View();
        }

        public ViewResult aboutus()
        {
            return View();
        }


        public ViewResult contactus()
        {
            return View();
        }
    }
}
