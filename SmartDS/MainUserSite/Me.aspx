<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Me.aspx.cs" Inherits="MainUserSite.Me" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
    <link href="css/me.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="badyContent" runat="server">
    <%if (_user != null)
      { %>
    <div class="headImgDiv"><input type="hidden" id="UserId" name="UserId" value="<%=_user.UserId %>" />
        <img src="<%=_user.ImgUrl %>" class="headimg" /><input type="hidden" id="ImgUrl" name="ImgUrl" value="<%=_user.ImgUrl %>" /></div>
    <div class="textdiv">用户名：<input id="LoginName" name="LoginName" type="text" value="<%=_user.LoginName %>" /></div>
    <div class="textdiv">姓名：<input id="UserName" name="UserName" type="text" value="<%=_user.UserName %>" /></div>
    <div class="textdiv">性别：<input name="Sex" type="radio" value="1" checked="<%=_user.Sex?"checked":"" %>" />男<input name="Sex" type="radio" value="0" checked="<%=_user.Sex?"checked":"" %>" />女</div>
    <div class="textdiv">国籍：<input id="Nationality" name="Nationality" type="text" value="<%=_user.Nationality %>" /></div>
    <div class="textdiv">身份证：<input id="IDcard" name="IDcard" type="text" value="<%=_user.IDCard %>" /></div>
    <div class="textdiv">手机号：<input id="Mobile" name="Mobile" type="text" value="<%=_user.Mobile %>" /></div>
    <div class="textdiv">Email：<input id="Email" name="Email" type="text" value="<%=_user.Email %>" /></div>
    <div class="textdiv">
        交流时间：<select>
            <option>时区选择</option>
        </select>起止时间<input id="start" name="start" type="datetime" value="" />---<input id="end" name="end" type="datetime" value="" />
    </div>
    <div class="textdiv">
        <input id="modifyBtn" name="modifyBtn" type="button" value="提交" /><a href="ChangePwd.aspx" target="_self">更改密码</a></div>
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
            modifyUrl: "UserService.asmx/ModifyUser",
            modifyBtn: $("#modifyBtn"),
            paramter:null,
            initPageObject: function () {
                this.modifyBtn.one("click", this.modify);
            },
            initParamter: function () {
                pageObject.paramter = {
                    userName: $("#UserName").val(),
                    imgUrl: $("#ImgUrl").val(),
                    mobile: $("#Mobile").val(),
                    IDCard: $("#IDCard").val(),
                    nationality: $("#Nationality").val(),
                    loginName: $("#LoginName").val(),
                    userId: $("#UserId").val(),
                    email: $("#Email").val(),
                    sex: ($("#Sex").val() == 1) ? true : false,
                    
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

