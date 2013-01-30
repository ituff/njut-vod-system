<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="main.aspx.cs" Inherits="main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        用户信息管理&gt; <span>用户信息查询</span></div>
    <div class="controlarea ">
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="UserID" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" GridLines="None" Width="80%">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="用户编号" ReadOnly="True" />
                <asp:BoundField DataField="UserName" HeaderText="用户姓名" />
                <asp:BoundField DataField="Email" HeaderText="电子邮箱" />
                <asp:BoundField DataField="Type" HeaderText="用户类型" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        </asp:GridView>
    </div>
</asp:Content>
