using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using UdemyMVCCourse.DTOs;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MovieDto, Movie>();
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<MembershipTypeDto, MembershipType>();
                cfg.CreateMap<Genre, GenreDto>();
                cfg.CreateMap<GenreDto, Genre>();
                //cfg.CreateMap<Rental, RentalDto>();
                //cfg.CreateMap<RentalDto, Rental>();
            });
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
