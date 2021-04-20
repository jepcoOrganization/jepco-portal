using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebSite6
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);

            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Ignore("Images/{*pathInfo}");

            //routes.MapPageRoute("Home","home","~/Default.aspx");
           routes.MapPageRoute("Home", "{Language}/home", "~/Default.aspx");
           // routes.MapPageRoute("Login", "Login", "~/LoginPage/Login.aspx");

            //routes.MapPageRoute(
            // "Home",
            // "home/{*RequestedPage}",
            // "~/Default.aspx",
            //  true,
            //  new System.Web.Routing.RouteValueDictionary { { "RequestedPage", "home" } });
            routes.MapPageRoute(
         "All Event Pages",
         "{Language}/EventPage/{Title}/{ID}",
         "~/DetailsPage/EventPage.aspx");

            routes.MapPageRoute(
         "All Core Pages",
         "{Language}/CoreValuePage/{Title}/{ID}",
         "~/DetailsPage/CoreValuePage.aspx");

            routes.MapPageRoute(
      "All Entity Pages",
      "{Language}/EntityPage/{Title}/{ID}",
      "~/DetailsPage/EntityPage.aspx");

            routes.MapPageRoute(
           "All Product Pages",
           "{Language}/ProductPage/{Title}/{ID}",
           "~/DetailsPage/ProductPage.aspx");

            routes.MapPageRoute(
            "All News Pages",
            "{Language}/NewsPage/{Title}/{ID}",
            "~/DetailsPage/NewsPage.aspx");


            routes.MapPageRoute(
           "All Annouce Pages",
           "{Language}/AnnoucePage/{Title}/{ID}",
           "~/DetailsPage/AnnoucePage.aspx");

            routes.MapPageRoute(
          "All Notification Pages",
          "{Language}/NotificationAndMessagePage/{Title}/{ID}",
          "~/DetailsPage/NotificationAndMessagePage.aspx");



            routes.MapPageRoute(
        "All Timeline Pages",
        "{Language}/TimelinePage/{Title}/{ID}",
        "~/DetailsPage/TimelinePage.aspx");

            routes.MapPageRoute(
            "All Photos Pages",
            "{Language}/PhotoGalleryDetail/{Title}/{ID}",
            "~/DetailsPage/PhotoGalleryDetail.aspx");

            routes.MapPageRoute(
           "All Video Pages",
           "{Language}/VideoGalleryDetail/{Title}/{ID}",
           "~/DetailsPage/VideoGalleryDetail.aspx");

            routes.MapPageRoute(
            "EnSearch",
            "en/SearchPage/{Title}",
            "~/DetailsPage/en/SearchPage.aspx",
            true,
            new System.Web.Routing.RouteValueDictionary { { "RequestedPage", "~/DetailsPage/en/SearchPage.aspx" } });

            routes.MapPageRoute(
           "ArSearch",
           "ar/SearchPage/{Title}",
           "~/DetailsPage/ar/SearchPage.aspx",
           true,
            new System.Web.Routing.RouteValueDictionary { { "RequestedPage", "~/DetailsPage/ar/SearchPage.aspx" } });


            routes.MapPageRoute(
          "All ServiceStepPage",
          "{Language}/Home/ServiceStepPage",
          "~/Pages/ServiceStepPage.aspx",
          true,
          new System.Web.Routing.RouteValueDictionary { { "RequestedPage", "ServiceStepPage" } });

            routes.MapPageRoute(
            "All Pages",
            "{Language}/Home/{*RequestedPage}",
            "~/Pages/Page.aspx",
            true,
            new System.Web.Routing.RouteValueDictionary { { "RequestedPage", "home" } });

            routes.MapPageRoute(
            "404",
            "{Language}/{*url}",
            "~/Default.aspx");

            
        }
    }
}