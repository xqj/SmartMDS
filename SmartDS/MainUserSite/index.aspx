<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MainUserSite.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <div class="login">
        
            <div id="lg" class="loginWrapleft loginwrap">
                <input type="text" id="loginName" name="loginName" class="loginInput" placeholder="登录名" value="" />
                <input type="password" id="Pwd" name="Pwd" class="loginInput" placeholder="密码" value="" />
                <a id="loginEnBtn" href="javascript:void(0)" class="loginBtn enBtn">登陆</a>
                <a id="regDisBtn" href="javascript:void(0)" class="loginBtn disBtn">注册</a>
            </div>
        
            <div id="rg" class="loginWrapleft loginwrap" style="display: none">
                <input type="text" id="regLoginName" name="regLoginName" class="loginInput" placeholder="登录名" value="" />
                <input type="password" id="regPwd" name="regPwd" class="loginInput" placeholder="密码" value="" />
                <input type="text" id="Email" name="Email" class="loginInput" placeholder="邮箱" value="" />
                <a id="regEnBtn" href="javascript:void(0)" class="loginBtn enBtn">注册</a>
                <a id="loginDisBtn" href="javascript:void(0)" class="loginBtn disBtn">登陆</a>
            </div>
        <div id="errMsg"></div>
        <div id="msg"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="dialogContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jsContent" runat="server">
    <script type="text/javascript">
        var pageObject = {
            loginUrl: 'UserService.asmx/Login',
            regUrl: 'UserService.asmx/Reg',
            loginBtn: $("#loginEnBtn"),
            regBtn: $("#regEnBtn"),
            vaild: null,
            initPageObject: function () {
                this.loginBtn.on("click", this.login);

                this.regBtn.on("click", this.reg);
                this.initCheck();
                $("#regDisBtn").on("click", function () {
                    $("#lg").hide();
                    $("#rg").show();
                    pageObject.vaild.resetForm();
                });
                $("#loginDisBtn").on("click", function () {
                    $("#rg").hide();
                    $("#lg").show();
                    pageObject.vaild.resetForm();
                });
            },
            initCheck: function () {
                pageObject.vaild = $("#form1").validate({
                    errorLabelContainer: "#errMsg",
                    rules: {},
                    messages: {}
                });
            },
            login: function () {
                pageObject.loginCheck();
                if (!$("#form1").valid()) {
                    return;
                }
                pageJs.loadAjaxFun(pageObject.loginUrl, { loginName: $("#loginName").val(), pwd: $("#Pwd").val() }, function (data) {
                    if (data.ActionResult) {
                        window.location = 'Resumes.aspx';
                    } else {
                        $("#msg").html(data.Message);
                    }
                }, function () {

                });
            },
            loginCheck: function () {
                $("#regLoginName").rules("remove");
                $("#regPwd").rules("remove");
                $("#Email").rules("remove");

                $("#loginName").rules("add", {
                    required: true,
                    minlength: 2,
                    maxlength: 20,
                    messages: {
                        required: "用户名必填",
                        minlength: "至少2个字符",
                        maxlength: "不能多于20个字符"
                    }
                });
                $("#Pwd").rules("add", {
                    required: true,
                    minlength: 6,
                    maxlength: 20,
                    messages: {
                        required: "密码必填",
                        minlength: "至少6个字符",
                        maxlength: "不能多于20个字符"
                    }
                });
            },
            reg: function () {
                pageObject.regCheck();
                if (!$("#form1").valid()) {
                    return;
                }
                pageJs.loadAjaxFun(pageObject.regUrl, { loginName: $("#regLoginName").val(), pwd: $("#regPwd").val(), email: $("#Email").val() }, function (data) {
                    if (data.ActionResult) {
                        window.location = 'Resumes.aspx';
                    } else {
                        $("#msg").html(data.Message);
                    }
                }, function () { });
            },
            regCheck: function () {
                $("#loginName").rules("remove");
                $("#Pwd").rules("remove");

                $("#regLoginName").rules("add", {
                    required: true,
                    minlength: 2,
                    maxlength: 20,
                    messages: {
                        required: "用户名必填",
                        minlength: "至少2个字符",
                        maxlength: "不能多于20个字符"
                    }
                });
                $("#regPwd").rules("add", {
                    required: true,
                    minlength: 6,
                    maxlength: 20,
                    messages: {
                        required: "密码必填",
                        minlength: "至少6个字符",
                        maxlength: "不能多于20个字符"
                    }
                });
                $("#Email").rules("add", {
                    required: true,
                    email: true,
                    messages: {
                        required: "邮箱必填",
                        email: "格式错误"
                    }
                });
            }

        };
        $.ready(function () {
            pageObject.initPageObject();
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="jsPlus" runat="server">
</asp:Content>
