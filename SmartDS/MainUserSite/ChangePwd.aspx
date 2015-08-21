﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="MainUserSite.ChangePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
    <link href="css/me.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <%if (_user != null)
      { %>
    
       
    <div class="textdiv">旧密码：<input id="oldPwd" name="oldPwd" type="text" value="" />
        <input type="hidden" id="UserId" name="UserId" value="<%=_user.UserId %>" /></div>
    <div class="textdiv">新密码：<input id="newPwd" name="newPwd" type="text" value="" /></div>
    
    <div class="textdiv">
        <input id="modifyBtn" name="modifyBtn" type="button" value="提交" /></div>
    <div id="msg" class="textdiv"></div>
    <%}
      else
      { %>
    <div>请登录</div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
    <script type="text/javascript">
        var pageObject = {
            modifyUrl: "UserService.asmx/ModifyPwd",
            modifyBtn: $("#modifyBtn"),
            paramter: null,
            initPageObject: function () {
                this.modifyBtn.one("click", this.modify);
            },
            initParamter: function () {
                pageObject.paramter = {                   
                    userId: $("#UserId").val(),
                    oldPwd: $("#oldPwd").val(),
                    newPwd: $("#newPwd").val()
                };
            },
            modify: function () {
                pageObject.initParamter();
                pageJs.loadAjaxFun(pageObject.modifyUrl, pageObject.paramter, function (data) {
                    $("#msg").html(data.Msg);
                    pageObject.modifyBtn.one("click", pageObject.modify);
                }, function () {
                    pageObject.modifyBtn.one("click", pageObject.modify);
                });
            }
        }
        pageObject.initPageObject();
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>


