using Microsoft.AspNet.Identity;
using POS_Demo.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Demo.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
        
        //public POSEntities _db => new POSEntities();

        public DateTime GetDate => DateTime.Now;

        public int GetUserId => User.Identity.GetUserId<int>();


    }
}