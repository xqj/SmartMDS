
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
var pageJs = {
    requestId: '',
    wpAjaxFun: function (url, paramters, successFun, errFun, loadHiddenFun) {
        if (paramters) paramters.requestId = this.requestId;//增加请求时序标识
        else {
            paramters = { "requestId": this.requestId };
        };
        $.ajax({
            url: url,
            data: JSON.stringify(paramters),
            type: 'post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                successFun(data.d)
                if (typeof (loadHiddenFun) == "function")//判断是否需要关闭加载状态
                    loadHiddenFun();
            },
            error: errFun ? errFun : function (XMLHttpRequest, textStatus, errorThrown) {
                if (typeof (loadHiddenFun) == "function")
                    loadHiddenFun();
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
                alert(textStatus);
            },
            complete: function (XMLHttpRequest, textStatus) {

            }
        });
    },
    loadAjaxFun: function (url, paramters, successFun, errFun) {
        if (typeof (loadSign) == "undefined") {
            loadSign = ".loading";
        }
        $(loadSign).show();
        this.wpAjaxFun(url, paramters, successFun, errFun, function () {
            $(loadSign).hide();
        });
    },
    showDialog: function (contentId, closeFun) {
        $.fancybox.open({
            href: "#" + contentId
        }, {
            closeBtn: false,
            closeClick: false,
            beforeClose: closeFun,
            helpers: {
                overlay: {
                    closeClick: false
                }
            }
        })
    },
    closeDialog: function (closeFun) {
        if (typeof (closeFun) == "fucntion")
            closeFun();
        $.fancybox.close();
    },
    initDropdownList: function (sourceUrl, paramters, wrapId) {
        this.wpAjaxFun(sourceUrl, paramters, function (data) {
            if (data.ActionResult) {
                $("#" + wrapId).html("");
                for (var i = 0; i < data.Data.length; i++) {
                    $("#" + wrapId).append('<option value="' + data.Data[i].SelectVal + '" title="' + data.Data[i].Remark + '"">' + data.Data[i].SelectName + '</option>');
                };
            } else { }
        });
    },
    ConvertJsonDate: function (jsondate) {
        var date = new Date(parseInt(jsondate.replace("/Date(", "").replace(")/", ""), 10));
        return date.Format("yyyy-MM-dd");
    }
}
