<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FocusAreaList.ascx.cs" Inherits="Controls_FocusAreaList" %>

<div class="row">
    <div class="col-12">
        <ul class="list-unstyled focus_area_list">
            <asp:ListView runat="server" ID="lstFocusArea" OnItemDataBound="lstFocusArea_ItemDataBound">
                <ItemTemplate>
                    <li>
                        <asp:HiddenField runat="server" ID="hdnColor" Value='<%# Bind("Color") %>' />
                        <div class="icondiv" runat="server" id="divfocus">
                            <asp:Image runat="server" ID="imgFocusArea" ImageUrl='<%#Bind("Image") %>' />
                            <%--<img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-1.png" alt="">--%>
                        </div>
                        <div class="focus_contant">
                            <h3 runat="server" id="h3FocusTitle">
                                <asp:Literal runat="server" ID="lblFocusTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                            </h3>
                            <p>
                                <asp:Literal runat="server" ID="lblFocusSummary" Text='<%# Bind("Summary") %>'></asp:Literal>
                            </p>
                        </div>
                        <div class="clearfix"></div>
                    </li>
                </ItemTemplate>
            </asp:ListView>
            <%--<li class="dark_blue">
                <div class="icondiv">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-1.png" alt="">
                </div>
                <div class="focus_contant">
                    <h3>Education</h3>
                    <p>
                        The Jubilee Institute provides opportunities for public and private school teachers, scholarship students and their
                                    families from diverse backgrounds, access to state-of-art education, training and curriculum development.
                    </p>
                </div>
                <div class="clearfix"></div>
            </li>
            <li class="light_blue">
                <div class="icondiv">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-2.png" alt="">
                </div>
                <div class="focus_contant">
                    <h3>Socio Economic Empowerment</h3>
                    <p>
                        The Community Development Program, Tamweelcom and Ethmar for Islamic Micro Finance provide access to work opportunities,
                                    loans, equity investments, and enterprise development for women, youth, and the marginalized.
                    </p>
                </div>
                <div class="clearfix"></div>
            </li>
            <li class="green">
                <div class="icondiv">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-3.png" alt="">
                </div>
                <div class="focus_contant">
                    <h3>Comprehensive Family Healthcare</h3>
                    <p>
                        The Institute for Family Health provides services and training on healthcare, child protection, and psychosocial support
                                    for survivors of conflict, gender-based violence and trauma.
                    </p>
                </div>
                <div class="clearfix"></div>
            </li>
            <li class="khakhi">
                <div class="icondiv">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-4.png" alt="">
                </div>
                <div class="focus_contant">
                    <h3>Research &Policy Development</h3>
                    <p>
                        The Information and Research Center promotes effective and sustainable socioeconomic development through research and
                                    recommendations for policymakers and development advocates.
                    </p>
                </div>
                <div class="clearfix"></div>
            </li>
            <li class="marun">
                <div class="icondiv">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-5.png" alt="">
                </div>
                <div class="focus_contant">
                    <h3>Culture</h3>
                    <p>
                        The National Music Conservatory and the National Center for Culture and Arts promote arts appreciation and education, as
                                    well as the use of performing arts as a medium to promote awareness on critical social and cultural issues.
                    </p>
                </div>
                <div class="clearfix"></div>
            </li>
            <li class="yellow">
                <div class="icondiv">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/focus-6.png" alt="">
                </div>
                <div class="focus_contant">
                    <h3>Capacity Building</h3>
                    <p>
                        Sharing over 35 years of our best practice models in economic empowerment, education, family healthcare, and
                                    cross-cultural understanding with countries throughout the MENA and West Asian regions
                    </p>
                </div>
                <div class="clearfix"></div>
            </li>--%>
        </ul>
    </div>
</div>
