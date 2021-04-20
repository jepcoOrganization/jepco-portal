<%@ Application Language="C#" %>
<%@ Import Namespace="WebSite6" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        //string url_path = HttpContext.Current.Request.Path;
        //if (url_path.Contains("NewsPath1"))
        //{
        //    Context.RewritePath(url_path.Replace("/NewsPath1", "Pages/Page.aspx"));
        //}

    }
    //static void RegisterRoutes(RouteCollection routes)
    //{
    //    routes.MapPageRoute("EnSearch", "/en/SearchPage/{Title}", "~/DetailsPage/en/SearchPage.aspx");
    //}

</script>
