﻿using System.Web;
using System.Web.Mvc;

namespace ASPProject11072015
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}