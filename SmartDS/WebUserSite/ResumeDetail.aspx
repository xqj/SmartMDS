<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ResumeDetail.aspx.cs" Inherits="WebUserSite.ResumeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/default.css" rel="stylesheet" />
     <link href="css/me.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
      <div class="headImgDiv"><img src="img/head.jpg" class="headimg"/></div>
     <div class="textdiv">用户名：<span id="LoginName" >username</span></div>
     <div class="textdiv">姓名：<span id="UserName" >XXX</span></div>
      <div class="textdiv">性别：<span id="Sex" >男</span></div>
      <div class="textdiv">国籍：<span id="Nation">中国</span></div>
      <div class="textdiv">身份证：<span id="IDcard" >411xxxxxxxxxxxxxxx</span></div>
      <div class="textdiv">最高学历：<span id="LastEdu">学士</span></div>
      <div class="textdiv">手机号：<span id="Mobile" >13xxxxxxx</span></div>
      <div class="textdiv">专业：<span id="Profesnal" >xxxxx专业</span></div>
     <div>交流时间:东八区--8:00 至 21:00</div>
     <div class="textdiv"><input id="btn"  type="button"  value="下载"/></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>
