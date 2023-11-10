using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using odev1.Models;

namespace odev1.Controllers
{
    public class YazokuluController : Controller
    {       
        public IActionResult Course(){
            return View("Course",Repository.Yazokuls);
        }
        public IActionResult Details(int? id){

            if(id == null){
                return Redirect("/yazokul/course");
            }
            var kurs = Repository.GetById(id);
            return View(kurs);
        }
    }
}