using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AssistWith.Controllers
{
    public class TemplateController : System.Web.Mvc.Controller
    { 
        public System.Web.Mvc.JsonResult Hello()
        {
            List<string> list = new List<string>();
            list.Add("Hello");
            list.Add("World");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
