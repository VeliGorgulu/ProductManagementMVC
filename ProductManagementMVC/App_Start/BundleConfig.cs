﻿using System.Web;
using System.Web.Optimization;

namespace ProductManagementMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ProductManagementMVCApp")
               .IncludeDirectory("~/Scripts/Controllers", "*.js")
               .IncludeDirectory("~/Scripts/Factories", "*.js")
               .Include("~/Scripts/ProductManagementMVCApp.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
