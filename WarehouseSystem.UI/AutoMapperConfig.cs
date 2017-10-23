using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using WarehouseSystem.DataAccess;
using WarehouseSystem.Repository;
using WarehouseSystem.UI.Helpers;
using WarehouseSystem.UI.Models;

namespace WarehouseSystem.UI
{
    public class AutoMapperConfig
    {
        public static void Load()
        {
            Mapper.Initialize(cfg =>
            {
            });
        }
    }
}