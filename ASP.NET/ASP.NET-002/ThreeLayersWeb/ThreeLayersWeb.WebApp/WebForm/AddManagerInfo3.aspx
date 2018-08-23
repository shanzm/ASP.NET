<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddManagerInfo3.aspx.cs"
    Inherits="ThreeLayersWeb.WebApp.WebForm.AddManagerInfo3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--
注意你每次新建一个aspx页面的时候，都会自动生成一个表单，这个表单的method是post，action是自己本身这个页面
在这里就是action：AddManagerInfo3.aspx
但是我们是知道的本身这个AddManagerInfo3.aspx页面是由ManagerInfo3.aspx这个页面的“添加新用户”这个超链接，链接来的（注意这里是使用get请求方式）
但是呢，这里的action：AddManagerInfo3.aspx，则说明，这个表单的提交按钮也是链接到AddManagerInfo3.aspx
所以综上所述，这个AddManagerInfo3.aspx页面既要接受post请求，也要接受get请求

当使用get求情进入这个页面的时候，AddManagerInfo3.aspx.cs是拿不到隐藏域的值的,因为你不是使用submit按钮（post请求）
所以只有是使用submit按钮（也就是post请求方式）时，AddManagerInfo3.aspx.cs 才能获取到表单中的值，也就是包括了隐藏域的值

    --%>
    <%--  
  注意啊runat="server"表示运行在服务端
  你在浏览器中查看此页的源代码就会返现，服务器返回给浏览器的html代码中
  这个表单是自动生成一个隐藏域，这个隐藏域的名字是_ _VIEWSTATE
  这个隐藏域的值就是.net自带控件为了保持状态用的，你要是不想要要
  你就在表单属性中删除runat="server"，自己写method="post",action="AddManagerInfo3.aspx"
  同时你删除了runat="server"，工具箱中的所有控件就不能用了（当然我们开发时不使用，就是因为隐藏域的值太多了，控件会影响性能）
    --%>
    <form id="form1" runat="server">
    <div>
        用户名：<input type="text" name="txtName" /><br />
        密码：<input type="text" name="txtPwd" /><br />
        类型：<input type="text" name="txtType" /><br />
        <input type="hidden" name="isPost" value="1" />
        <input type="submit" value="添加用户" />
    </div>
    </form>
</body>
</html>
