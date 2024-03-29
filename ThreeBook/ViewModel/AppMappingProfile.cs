﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeBook.Models;
using ThreeBook.Models.mainTest;

namespace ThreeBook.ViewModel
{
    public class AppMappingProfile: Profile
    {
        public static MapperConfiguration config;
        public AppMappingProfile()
        {
            //CreateMap<Book, ViewBook>();
            //CreateMap<TypesBook, ViewTypeBook>();

            config = new MapperConfiguration(cfg =>
                cfg.CreateMap<TypesBook, ViewTypeBook>()
            );

        }
        
        //var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, ViewBook>());
    }
}