<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="WebUserSite.Reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <div class="centerContainer">
        <div>用户名:<input type="text" id="userName" name="userName" value="" /></div>
        <div>手机号：<input type="text" id="mobile" name="mobile" value="" /></div>
        <div>密码：<input type="password" id="pwd" name="pwd" value="" /></div>
        <div><span><a href="javascript:void(0);">注册</a></span></div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>
