using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonelProject.ToDo.WebUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.WebUI.CustomFilters
{
    public class AdOlamaz : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionaryGelen = context.ActionArguments.Where(I=>I.Key=="model" ).FirstOrDefault();
            var model = (KullaniciKayitViewModel)dictionaryGelen.Value;


            if (model.Ad.ToLower() == "onur")
            {
                context.Result = new RedirectResult("\\Home\\Error");
            }
            base.OnActionExecuting(context);
        }
    }
}
