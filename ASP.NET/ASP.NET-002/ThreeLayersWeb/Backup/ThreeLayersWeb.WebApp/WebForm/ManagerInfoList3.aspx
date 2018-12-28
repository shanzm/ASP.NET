<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerInfoList3.aspx.cs"
    Inherits="ThreeLayersWeb.WebApp.WebForm.ManagerInfoList3" %>

<%--导入命名空间--%>
<%@ Import Namespace="ThreeLayersWeb.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/tableStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        window.onload = function ()
        {
            var datas = document.getElementsByName("deteles");
            var datasLength = datas.length;
            for (var i = 0; i < datasLength; i++)
            {
                datas[i].onclick = function ()
                {
                    if (!confirm("确定要删除吗？"))
                    {
                        return false;
                    }
                };
            }

        };
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <th>
                    编号
                </th>
                <th>
                    用户名
                </th>
                <th>
                    密码
                </th>
                <th>
                    类型
                </th>
                <th>
                    删除
                </th>
                <th>
                    详细
                </th>
                <th>
                    编辑
                </th>
            </tr>
            <% foreach (ManagerInfo managerInfo in managerInfoList) %>
            <% { %>
            <tr>
                <td>
                    <%=managerInfo .MId%>
                </td>
                <td>
                    <%=managerInfo .MName%>
                </td>
                <td>
                    <%=managerInfo .MPwd %>
                </td>
                <td>
                    <%=managerInfo .MType %>
                </td>
                <td>
                    <a href="../CRUD/DeleteManagerInfo.ashx?id=<%=managerInfo.MId %>" name="deteles">删除</a>
                </td>
                <td>
                    <a href="../CRUD/DeleteManagerInfo.ashx?id=<%=managerInfo.MId %>" name="deteles">详细</a>
                </td>
                <td>
                    <a href="EditManagerInfo.aspx?id=<%=managerInfo.MId %>" >编辑</a>
                </td>
            </tr>
            <% } %>
        </table>
        <a href="AddManagerInfo3.aspx">添加新用户</a>
    </div>
    </form>
</body>
</html>
