<%@ Page Title="" Language="C#" MasterPageFile="~/metro.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <div class="row-fluid">
            <div class="metro span12">
                <div class="metro-sections">
                    <div id="section1" class="metro-section tile-span-4">

                        <h2 style="font-family: 'Microsoft YaHei';">互联网直播</h2>

                        <%=liveChannelStr %>
                    </div>

                    <div id="section2" class="metro-section tile-span-4">

                        <h2 style="font-family: 'Microsoft YaHei';">精彩点播</h2>

                        <%=programStr %>
                    </div>

                    <div id="section3" class="metro-section tile-span-4">
                        <h2 style="font-family: 'Microsoft YaHei';">实时直播</h2>
                        <%=mobileLiveStr %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

