<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Cus.WebForm.AddOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <strong>登打訂單資料</strong></div>
        <table id="tab01" style="width:600px">
            <td class="auto-style1">聯絡人代碼：</td>
                <td>
                    <asp:Label ID="labContactID" runat="server" Text=""></asp:Label>
                </td>
            <tr>
                <td class="auto-style1">聯絡人名稱：</td>
                <td>
                    <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">產品名稱：</td>
                <td>
                    <asp:DropDownList ID="ddlProducts" runat="server" Width="245px" AutoPostBack="True" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="labUnitPrice" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">產品接洽人員：</td>
                <td>
                    <asp:DropDownList ID="ddlEmployee" runat="server" Width="186px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">數量：</td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server">1</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">貨運名稱：</td>
                <td>
                    <asp:DropDownList ID="ddlShippers" runat="server" Width="245px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">貨運地址：</td>
                <td>
                    <asp:TextBox ID="txtShipAddress" runat="server" Width="340px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="btnAddOrder" runat="server" OnClick="btnAddOrder_Click" Text="確認訂購" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消訂購" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
