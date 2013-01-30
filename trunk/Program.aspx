<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="Program.aspx.cs" Inherits="Program" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        节目管理&gt; <span>节目信息查询</span></div>
    <div class="controlarea ">
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="ProgramID" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" GridLines="None" Width="80%">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ProgramID" HeaderText="节目编号" ReadOnly="True" />
                <asp:HyperLinkField DataNavigateUrlFields="ProgramID" DataNavigateUrlFormatString="programView.aspx?id={0}"
                    DataTextField="ProgramName" HeaderText="节目名称" />
                <asp:BoundField DataField="ProgramUrl" HeaderText="节目地址" />
                <asp:HyperLinkField DataNavigateUrlFields="ChannelID" DataNavigateUrlFormatString="channelView.aspx?id={0}"
                    DataTextField="ChannelID" HeaderText="所属频道" />
                <asp:BoundField DataField="BeginTime" HeaderText="开始时间" />
                <asp:BoundField DataField="EndTime" HeaderText="结束时间" />
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
