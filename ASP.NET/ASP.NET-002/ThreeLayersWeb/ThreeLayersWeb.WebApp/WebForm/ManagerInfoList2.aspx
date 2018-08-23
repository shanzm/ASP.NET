<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerInfoList2.aspx.cs"
    Inherits="ThreeLayersWeb.WebApp.ManagerInfoList2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            <%--上面这些就是表的第一列--%>
            <%--下面的才是表的数据
            使用 = 就相当于response.write()
            --%>

            <%=strTable %>

        </table>
        <a href="../CRUD/AddManagerInfo.html">添加新数据</a>
    </div>
    </form>
</body>
</html>
