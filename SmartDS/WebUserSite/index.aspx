<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebUserSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <div class="login">
        <div class="loginWrapleft loginwrap">
            <input type="text" id="loginName" name="loginName" class="loginInput" placeholder="登录名" value=""/>
            <input type="password" id="pwd" name="pwd" class="loginInput" placeholder="密码" value=""/>
              <input type="text" id="mobile" name="mobile" class="loginInput" style="display:none" placeholder="手机号" value=""/>
             <input type="text" id="verifyCode" name="verifyCode" class="loginInputSmall" style="display:none" placeholder="验证码" value=""/>
            <a href="javscrpt:void(0)" class="loginBtn enBtn">登陆</a>
            <a href="javscrpt:void(0)" class="loginBtn disBtn">注册</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>
