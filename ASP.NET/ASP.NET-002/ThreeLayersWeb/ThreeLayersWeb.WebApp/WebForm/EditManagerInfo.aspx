<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditManagerInfo.aspx.cs"
    Inherits="ThreeLayersWeb.WebApp.WebForm.EditManagerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%-- 你要切记表单属性 runat="server"，那没submit按钮提交时请求的页面就还是本页面--%>
    <form id="form1" runat="server">
    <div>
        用户名：<input type="text" name="txtName" value="<%=managerInfo.MName %>" /><br />
        密码：<input type="text" name="txtPwd" value="<%=managerInfo.MPwd %>" /><br />
        类型：<input type="text" name="txtType" value="<%=managerInfo.MType %>" /><br />
        <input type="hidden" name="txtId" value="<%=managerInfo.MId %>" />
        <input type="submit" value="编辑用户" />
    </div>
    </form>
</body>
</html>
