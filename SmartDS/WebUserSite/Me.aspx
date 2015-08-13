<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Me.aspx.cs" Inherits="WebUserSite.Me" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
     <link href="css/me.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
      <div class="headImgDiv"><img src="img/head.jpg" class="headimg"/></div>
     <div class="textdiv">用户名：<input id="LoginName" name="LoginName" type="text"  value=""/></div>
     <div class="textdiv">姓名：<input id="UserName" name="UserName" type="text"  value=""/></div>
      <div class="textdiv">性别：<input id="Sex" name="Sex" type="text"  value=""/></div>
      <div class="textdiv">国籍：<input id="Nation" name="Nation" type="text"  value=""/></div>
      <div class="textdiv">身份证：<input id="IDcard" name="IDcard" type="text"  value=""/></div>
      <div class="textdiv">最高学历：<input id="LastEdu" name="LastEdu" type="text"  value=""/></div>
      <div class="textdiv">手机号：<input id="Mobile" name="Mobile" type="text"  value=""/></div>
      <div class="textdiv">专业：<input id="Profesnal" name="Profesnal" type="text"  value=""/></div>
     <div class="textdiv"><input id=""  type="button"  value="提交"/></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>
