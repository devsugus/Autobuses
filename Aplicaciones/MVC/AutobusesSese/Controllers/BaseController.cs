using AutobusesSese.Models;
using AutobusesSese.Models.repositorios;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutobusesSese.Controllers
{
    public class BaseController : Controller
    {
        public static Autofac.IContainer Container { get; set; }
        public IRepositorio db;

        public BaseController()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FakeRepositorio>().As<IRepositorio>();
            Container = builder.Build();

            using (var ambito = Container.BeginLifetimeScope())
            {
                db = ambito.Resolve<IRepositorio>();

            }

        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    //Log the error!!
        //    //_Logger.Error(filterContext.Exception);

        //    //Redirect or return a view, but not both.
        //    //filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        //    // OR 
            

        //filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/Shared/Error.cshtml"
        //    };
        //}
     
    }
}