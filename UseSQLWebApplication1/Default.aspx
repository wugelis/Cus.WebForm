<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cus.WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        客戶連絡名稱：<asp:DropDownList ID="ddlCusContacts" runat="server" Width="169px">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnFindOrderByCus" runat="server" Text="查詢客戶訂單" OnClick="btnFindOrderByCus_Click" />
        <asp:Button ID="btnAddOrder" runat="server" OnClick="btnAddOrder_Click" Text="新增訂單" />
        <br />
        <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="客戶編號" />
                <asp:BoundField DataField="CompanyName" HeaderText="公司名稱" />
                <asp:BoundField DataField="ContactName" HeaderText="聯絡人名稱" />
                <asp:BoundField DataField="City" HeaderText="城市" />
                <asp:BoundField DataField="OrderID" HeaderText="訂單編號" />
                <asp:BoundField DataField="UnitPrice" HeaderText="單價" />
                <asp:BoundField DataField="ProductID" HeaderText="產品編號" />
                <asp:BoundField DataField="ProductName" HeaderText="產品名稱" />
                <asp:BoundField DataField="OrderDate" HeaderText="訂貨日期" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
</body>
</html>
