<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Resumes.aspx.cs" Inherits="MainUserSite.Resumes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <div class="searchContainer">
        <div class="search">
            <input type="text" id="searchKey" name="searchKey" placeholder="搜索简历" class="searchText" value="" /><span class="searcBtn"><a id="searchBtn" href="javascript:void(0);">搜索</a></span>
        </div>
    </div>
    <div id="resumeList">
        <ul id="listWrap" class="resumeul">
            
        </ul>
    </div>
    <div id="moreBtn" style="text-align:center;margin-left:auto;margin-right:auto;width:120px;height:30px;">MORE</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
    <script type="text/javascript">
        var pageObject = {
            pagerUrl: "UserService.asmx/GetPagers",
            searchUrl: "UserService.asmx/SearchGetPagers",
            currentPage: 1,
            pageSize: 24,
            isSearch: false,
            moreBtn: $("#moreBtn"),
            searchBtn: $("#searchBtn"),
            listWrap: $("#listWrap"),
            listTmpl: "<li><a href=\"ResumeDetail.aspx?id={UserId}\"><img src=\"{ImgUrl}\" class=\"resumeHeadImg\" /></a><p><a href=\"ResumeDetail.aspx?id={UserId}\">{UserName}</a></li>",
            initPageObject: function () {
                this.moreBtn.on("click", this.loadMore);
                this.searchBtn.on("click", function () {
                    pageObject.listWrap.html("");
                    pageObject.searchList();
                });
                this.pagerList();
            },
            loadMore: function () {
                pageObject.currentPage = pageObject.currentPage + 1;
                if (pageObject.isSearch) {
                    pageObject.searchList();
                } else {
                    pageObject.pagerList();
                }
            },
            pagerList: function () {
                pageJs.loadAjaxFun(pageObject.pagerUrl, { currentPage: pageObject.currentPage, pageSize: pageObject.pageSize }, function (data) {
                    if (data.ActionResult) {
                        if (data.Data.length > 0) {
                            for (var i = 0; i < data.Data.length; i++) {
                                pageObject.listWrap.append(pageObject.listTmpl.replace("{ImgUrl}", data.Data[i].ImgUrl).replace("{UserId}", data.Data[i].UserId).replace("{UserId}", data.Data[i].UserId).replace("{UserName}", data.Data[i].UserName));
                            }
                        } else {
                            if (pageObject.currentPage > 1)
                            pageObject.currentPage = pageObject.currentPage - 1;
                        }
                    } else {
                        if (pageObject.currentPage > 1)
                        pageObject.currentPage = pageObject.currentPage - 1;
                       
                    }
                }, function () {

                });
            },
            searchList: function () {
                pageJs.loadAjaxFun(pageObject.searchUrl, { currentPage: pageObject.currentPage, pageSize: pageObject.pageSize, searchKey: $("#searchKey").val() }, function (data) {
                    if (data.ActionResult) {
                        if (data.Data.length > 0) {
                            for (var i = 0; i < data.Data.length; i++) {
                                pageObject.listWrap.append(pageObject.listTmpl.replace("{ImgUrl}", data.Data[i].ImgUrl).replace("{UserId}", data.Data[i].UserId).replace("{UserName}", data.Data[i].UserName));
                            }
                        } else {
                            if (pageObject.currentPage > 1)
                            pageObject.currentPage = pageObject.currentPage - 1;
                        }
                    } else {
                        if (pageObject.currentPage>1)
                        pageObject.currentPage = pageObject.currentPage - 1;
                        
                    }
                }, function () {

                });
            }
        };
        $(document).ready(function () {
            pageObject.initPageObject();
        });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>

