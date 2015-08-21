<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Resumes.aspx.cs" Inherits="MainUserSite.Resumes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <div class="searchContainer">
        <div class="search">
            <input type="text" id="searchText" name="seracheText" placeholder="搜索简历" class="searchText" value=""/><span class="searcBtn"><a href="javascript:void(0);">搜索</a></span>
        </div>
    </div>
    <div id="resumeList">
        <ul class="resumeul">
            <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                 <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
            <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                 <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
             <li>
                <img src="img/head.jpg" class="resumeHeadImg" />
                <p><a href="ResumeDetail.aspx">姓名 </a></p>
                  <p>交流时间:东八区--8:00 至 21:00</p>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>

