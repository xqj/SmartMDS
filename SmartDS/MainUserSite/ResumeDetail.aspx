<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="ResumeDetail.aspx.cs" Inherits="MainUserSite.ResumeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/default.css" rel="stylesheet" />
     <link href="css/me.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <%if(_user!=null){ %>
      <div class="headImgDiv"><img src="<%=_user.ImgUrl %>" class="headimg"/></div>
     <div class="textdiv">用户名：<span id="LoginName" ><%=_user.ImgUrl %></span></div>
     <div class="textdiv">姓名：<span id="UserName" ><%=_user.ImgUrl %></span></div>
      <div class="textdiv">性别：<span id="Sex" ><%=_user.ImgUrl %></span></div>
      <div class="textdiv">国籍：<span id="Nation"><%=_user.ImgUrl %></span></div>
      <div class="textdiv">手机号：<span id="Mobile" ><%=_user.ImgUrl %></span></div>
     <div  class="textdiv">交流时间:东八区--8:00 至 21:00</div>
     <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>
