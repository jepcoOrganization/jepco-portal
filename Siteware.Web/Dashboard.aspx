<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Siteware.Web.DashBoard" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="AppTheme/css/style.navyblue.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li>
                <asp:HyperLink runat="server" NavigateUrl="~/Dashboard.aspx"><i class="iconfa-home"></i></asp:HyperLink>
                <span class="separator"></span></li>
            <li>Dashboard</li>
        </ul>

        <div class="pageheader">
            <%--  <form class="searchbar">
                <asp:TextBox ID="txtSearch" runat="server" placeholder="To search type and hit enter..." Style="float: right;"></asp:TextBox>
            </form>--%>
            <div class="pageicon"><span class="iconfa-laptop"></span></div>
            <div class="pagetitle">
                <h5>All Features Summary</h5>
                <h1>Dashboard</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row" style="min-height: 400px;">
                    <div id="dashboard-left" class="col-md-8">

                        <h5 class="subtitle">Recently Viewed Pages</h5>
                        <ul class="shortcuts">
                            <li class="events" id="liManagePages" runat="server" style="display:none">
                                <a href="<%= ResolveUrl("~/")%>Pages/ManagePages.aspx">
                                    <span class="shortcuts-icon iconsi-event"></span>
                                    <span class="shortcuts-label">Pages</span>
                                </a>
                            </li>
                            <li class="products" id="liManageBanner" runat="server" style="display:none">
                                <a href="<%= ResolveUrl("~/")%>Plugins/Banners/ManageBanner.aspx">
                                    <span class="shortcuts-icon iconsi-cart"></span>
                                    <span class="shortcuts-label">Banners</span>
                                </a>
                            </li>
                            <li class="archive" id="liManageNewsTicker" runat="server" style="display:none">
                                <a href="<%= ResolveUrl("~/")%>Plugins/Marquee/ManageMarquee.aspx">
                                    <span class="shortcuts-icon iconsi-archive"></span>
                                    <span class="shortcuts-label">Marquee</span>
                                </a>
                            </li>
                            <li class="help" id="liManageNavigation" runat="server" style="display:none">
                                <a href="<%= ResolveUrl("~/")%>Navigation/ManageNavigation.aspx">
                                    <span class="shortcuts-icon iconsi-help"></span>
                                    <span class="shortcuts-label">Navigation</span>
                                </a>
                            </li>
                            <%--   <li class="last images">
                                <a href="">
                                    <span class="shortcuts-icon iconsi-images"></span>
                                    <span class="shortcuts-label">Slider</span>
                                </a>
                            </li>--%>
                        </ul>
                        <%--   <div class="form-group">
                            <div class="input-group">
                                <input class="form-control input-lg" id="modalField" type="text">
                                <span class="input-group-btn">
                                    <a class="btn btn-primary btn-lg" href="#FileBrowserModal" data-toggle="modal">Choose a file</a>
                                </span>
                            </div>
                        </div>
                        <div class="modal fade" id="FileBrowserModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                            aria-hidden="true">
                            <div class="modal-dialog modal-lg" style="width: 80%; height: 90%;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">
                                            <span aria-hidden="true">×</span><span
                                                class="sr-only">Close</span></button>
                                        <h4 class="modal-title" id="H1">File browser</h4>
                                    </div>
                                    <div class="modal-body">
                                        <iframe style="width: 100%; height: 90%;" id="FB_frame"></iframe>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <script>
                            /* Note.: jQuery SHOULD BE LOADED for the examples on this page are working properly */

                            function fileBrowserCallBack(fileurl) {
                                $('#modalField').val(fileurl);
                                $('#FileBrowserModal').modal('hide');
                            }

                            // Loading of iframe content is postposed to not slow down page loading
                            $(function () {
                                $(window).on('load', function () {
                                    $('#FB_frame').attr('src', '/siteware/FileBrowser/NewBros.aspx?caller=parent&fn=fileBrowserCallBack&langCode=en');
                                });
                            })
                        </script>--%>



                        <%--    <div class="form-group">
                            <div class="input-group">
                                <input class="form-control input-lg" id="newWinField" type="text">
                                <span class="input-group-btn">
                                    <button class="btn btn-primary btn-lg" type="button" id="newWinBtn">Choose a file</button>
                                </span>
                            </div>
                        </div>--%>

                        <%--         <script>
                            /* Note.: jQuery SHOULD BE LOADED for the examples on this page are working properly */

                            //CallBack function
                            function newWinFn(fileurl) {
                                $('#newWinField').val(fileurl);
                            }
                            $(function () {
                                // Button click event
                                $('#newWinBtn').on('click', function (e) {
                                    e.preventDefault();
                                    var top = window.screenTop + 50;
                                    var left = window.screenLeft + 50;
                                    window.open('/siteware/FileBrowser/NewBros.aspx?caller=opener&fn=newWinFn&langCode=en', 'fileBrowser', 'top=' + top + ',left=' + left + ',menubar=0,scrollbars=0,toolbar=0,height=550,width=700');
                                })
                            });
                        </script>--%>



                        <%--<h5 class="subtitle">Daily Statistics</h5><br />
                        <div id="chartplace" style="height:300px;"></div>
                        
                        <div class="divider30"></div>
                        
                        <table class="table table-bordered responsive">
                            <thead>
                                <tr>
                                    <th class="head1">Rendering engine</th>
                                    <th class="head0">Browser</th>
                                    <th class="head1">Platform(s)</th>
                                    <th class="head0">Engine version</th>
                                    <th class="head1">CSS grade</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Trident</td>
                                    <td>Internet  Explorer 5.5</td>
                                    <td>Win 95+</td>
                                    <td class="center">5.5</td>
                                    <td class="center">A</td>
                                </tr>
                                <tr>
                                    <td>Trident</td>
                                    <td>Internet Explorer 6</td>
                                    <td>Win 98+</td>
                                    <td class="center">6</td>
                                    <td class="center">A</td>
                                </tr>
                                <tr>
                                    <td>Trident</td>
                                    <td>Internet Explorer 7</td>
                                    <td>Win XP SP2+</td>
                                    <td class="center">7</td>
                                    <td class="center">A</td>
                                </tr>
                            </tbody>
                        </table>
                        
                        <br />
                        
                        <h4 class="widgettitle"><span class="glyphicon glyphicon-comment glyphicon-white"></span> Recent Comments</h4>
                        <div class="widgetcontent nopadding">
                            <ul class="commentlist">
                                <li>
                                    <img src="AppTheme/images/photos/thumb2.png" alt="" class="pull-left" />
                                    <div class="comment-info">
                                        <h4><a href="">Sed ut perspiciatis unde omnis iste natus error sit voluptatem</a></h4>
                                        <h5>in <a href="">Sit Voluptatem</a></h5>
                                        <p>Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. </p>
                                        <p>
                                            <a href="" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-thumbs-up glyphicon-white"></span> Approve</a>
                                            <a href="" class="btn btn-default btn-sm"><span class="glyphicon glyphicon-thumbs-down"></span> Reject</a>
                                        </p>
                                    </div>
                                </li>
                                <li>
                                    <img src="AppTheme/images/photos/thumb1.png" alt="" class="pull-left" />
                                    <div class="comment-info">
                                        <h4><a href="">But I must explain to you how all this mistaken</a></h4>
                                        <h5>in <a href="">At vero eos et accusamus et iusto odio dignissimos</a></h5>
                                        <p>Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae.</p>
                                        <p>
                                            <a href="" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-thumbs-up glyphicon-white"></span> Approve</a>
                                            <a href="" class="btn btn-default btn-sm"><span class="glyphicon glyphicon-thumbs-down"></span> Reject</a>
                                        </p>
                                    </div>
                                </li>
                                <li>
                                    <img src="AppTheme/images/photos/thumb10.png" alt="" class="pull-left" />
                                    <div class="comment-info">
                                        <h4><a href="">On the other hand, we denounce with righteous indignation</a></h4>
                                        <h5>in <a href="">These cases are perfectly simple and easy to distinguish</a></h5>
                                        <p>Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia.</p>
                                        <p>
                                            <a href="" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-thumbs-up glyphicon-white"></span> Approve</a>
                                            <a href="" class="btn btn-default btn-sm"><span class="glyphicon glyphicon-thumbs-down"></span> Reject</a>
                                        </p>
                                    </div>
                                </li>
                                <li><a href="">View More Comments</a></li>
                            </ul>
                        </div>
                        
                        <br />--%>
                    </div>
                    <!--col-md-8-->

                    <div id="dashboard-right" class="col-md-4">

                        <%--                        <h5 class="subtitle">Announcements</h5>

                        <div class="divider15"></div>

                        <div class="alert alert-block">
                            <button data-dismiss="alert" class="close" type="button">&times;</button>
                            <h4>Warning!</h4>
                            <p style="margin: 8px 0">Best check yo self, you're not looking too good. Nulla vitae elit libero, a pharetra augue. Praesent commodo cursus magna.</p>
                        </div>
                        <!--alert-->

                        <br />--%>

                        <%--<h5 class="subtitle">Summaries</h5>
                            
                        <div class="divider15"></div>
                        
                        <div class="widgetbox">                        
                        <div class="headtitle">
                            <div class="btn-group">
                                <button data-toggle="dropdown" class="btn dropdown-toggle">Action <span class="caret"></span></button>
                                <ul class="dropdown-menu">
                                  <li><a href="#">Action</a></li>
                                  <li><a href="#">Another action</a></li>
                                  <li><a href="#">Something else here</a></li>
                                  <li class="divider"></li>
                                  <li><a href="#">Separated link</a></li>
                                </ul>
                            </div>
                            <h4 class="widgettitle">Widget Box</h4>
                        </div>
                        <div class="widgetcontent">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                        </div><!--widgetcontent-->
                        </div><!--widgetbox-->
                        
                        <h4 class="widgettitle">Event Calendar</h4>
                        <div class="widgetcontent nopadding">
                            <div id="datepicker"></div>
                        </div>
                        
                        <div class="tabbedwidget tab-primary">
                            <ul>
                                <li><a href="#tabs-1"><span class="iconfa-user"></span></a></li>
                                <li><a href="#tabs-2"><span class="iconfa-star"></span></a></li>
                                <li><a href="#tabs-3"><span class="iconfa-comments"></span></a></li>
                            </ul>
                            <div id="tabs-1" class="nopadding">
                                <h5 class="tabtitle">Last Logged In Users</h5>
                                <ul class="userlist">
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb1.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Draniem Daamul</h5>
                                                <span class="pos">Software Engineer</span>
                                                <span>Last Logged In: 04/20/2013 8:40PM</span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb2.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Therineka Chonpe</h5>
                                                <span class="pos">Regional Manager</span>
                                                <span>Last Logged In: 04/20/2013 3:30PM</span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb3.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Zaham Sindilmaca</h5>
                                                <span class="pos">Chief Technical Officer</span>
                                                <span>Last Logged In: 04/19/2013 1:30AM</span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb4.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Annie Cerona</h5>
                                                <span class="pos">Engineering Manager</span>
                                                <span>Last Logged In: 04/19/2013 11:30AM</span>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb5.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Delher Carasbong</h5>
                                                <span class="pos">Software Engineer</span>
                                                <span>Last Logged In: 04/19/2013 11:00AM</span>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div id="tabs-2" class="nopadding">
                                <h5 class="tabtitle">Favorites</h5>
                                <ul class="userlist userlist-favorites">
                                                                        <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb3.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Zaham Sindilmaca</h5>
                                                <p class="link">
                                                    <a href=""><i class="iconfa-envelope"></i> Message</a>
                                                    <a href=""><i class="iconfa-phone"></i> Call</a>
                                                </p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb4.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Annie Cerona</h5>
                                                <p class="link">
                                                    <a href=""><i class="iconfa-envelope"></i> Message</a>
                                                    <a href=""><i class="iconfa-phone"></i> Call</a>
                                                </p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb5.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Delher Carasbong</h5>
                                                <p class="link">
                                                    <a href=""><i class="iconfa-envelope"></i> Message</a>
                                                    <a href=""><i class="iconfa-phone"></i> Call</a>
                                                </p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb1.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Draniem Daamul</h5>
                                                <p class="link">
                                                    <a href=""><i class="iconfa-envelope"></i> Message</a>
                                                    <a href=""><i class="iconfa-phone"></i> Call</a>
                                                </p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb2.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Therineka Chonpe</h5>
                                                <p class="link">
                                                    <a href=""><i class="iconfa-envelope"></i> Message</a>
                                                    <a href=""><i class="iconfa-phone"></i> Call</a>
                                                </p>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div id="tabs-3" class="nopadding">
                                <h5 class="tabtitle">Top Comments</h5>
                                <ul class="userlist">
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb4.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Annie Cerona</h5>
                                                <p class="par">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididun</p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb5.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Delher Carasbong</h5>
                                                <p class="par">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididun</p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb1.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Draniem Daamul</h5>
                                                <p class="par">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididun</p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb2.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Therineka Chonpe</h5>
                                                <p class="par">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididun</p>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <div>
                                            <img src="AppTheme/images/photos/thumb3.png" alt="" class="pull-left" />
                                            <div class="uinfo">
                                                <h5>Zaham Sindilmaca</h5>
                                                <p class="par">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididun</p>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div><!--tabbedwidget-->
                        
                        <br />--%>
                    </div>
                    <!-- col-md-4 -->
                </div>
                <!--row-->

                <div class="footer">
                    <div class="footer-left">
                        <span>&copy; 2015. Auratechs Solutions. All Rights Reserved.</span>
                    </div>
                    <div class="footer-right" style="height: 26px;">
                        <asp:HyperLink ID="lnkFooter" runat="server" NavigateUrl="http://www.aura-techs.com" Target="_blank">
                            <asp:Image ID="imglogo" runat="server" ImageUrl="AppTheme/Images/auratechs-logo.png" Style="height: 35px; width: 100%; margin-top: -5px;" />
                        </asp:HyperLink>
                    </div>
                </div>

            </div>
            <!--maincontentinner-->
        </div>
        <!--maincontent-->

    </div>
</asp:Content>
