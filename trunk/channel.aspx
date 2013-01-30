<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="channel.aspx.cs" Inherits="channel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        频道管理&gt; <span>频道信息查询</span></div>
    <div class="controlarea ">
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            DataKeyNames="ChannelID" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            ForeColor="Black" GridLines="None" Width="80%">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ChannelID" HeaderText="频道编号" ReadOnly="True" />
                <asp:HyperLinkField DataNavigateUrlFields="ChannelID" 
                    DataNavigateUrlFormatString="channelView.aspx?id={0}" 
                    DataTextField="ChannelName" HeaderText="频道名称" />
                <asp:BoundField DataField="ChannelMMS" HeaderText="频道地址" />
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
