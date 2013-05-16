<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="channelView.aspx.cs" Inherits="channelView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jwplayer.js">
       
    </script>
    <script type="text/javascript" src="js/vlcPlayer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right01">
        <img src="images/04.gif" />
        频道管理&gt; <span>频道查看</span>
    </div>
    <div class="controlarea ">
        <br />
        <p>
            频道名称：<asp:TextBox ID="ChannelNameTB" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
        </p>
        <p>
            频道地址：<asp:TextBox ID="ChannelMMSTB" runat="server" Width="350px" MaxLength="200"></asp:TextBox>
        </p>
        <p>移动直播：<asp:CheckBox ID="IsMobileLiveCB" runat="server" /></p>
        <p>是否广播：<asp:CheckBox ID="IsBroadCastCB" runat="server" /></p>
        <p>是否记录：<asp:CheckBox ID="IsRecordCB" runat="server" /></p>
        <br />
        <asp:Panel ID="ieStramPlayerPannel" runat="server" Visible="false">
            <object id="player" height='320' width='480' style="margin-left: auto; margin-right: auto;"
                classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                <param name="AutoStart" value="1" />
                <param name="EnableContextMenu" value="1" />
                <param name="url" value="<%=ChannelMMSStr %>" />
            </object>
        </asp:Panel>
        <asp:Panel ID="otherBrowserStramPlayerPannel" runat="server" Visible="false">
            <object id="Object1" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6" height="460" width="530">
                <param name="URL" value="<%=ChannelMMSStr %>"/>
                <param name="rate" value="1"/>
                <param name="balance" value="0"/>
                <param name="defaultFrame" value=""/>
                <param name="playCount" value="1"/>
                <param name="autoStart" value="1"/>
                <param name="currentMarker" value="0"/>
                <param name="invokeURLs" value="-1"/>
                <param name="baseURL" value=""/>
                <param name="volume" value="50"/>
                <param name="mute" value="0"/>
                <param name="stretchToFit" value="1"/>
                <param name="windowlessVideo" value="0"/>
                <param name="enabled" value="-1"/>
                <param name="enableContextMenu" value="0"/>
                <param name="fullScreen" value="0"/>
                <param name="SAMIStyle" value=""/>
                <param name="SAMILang" value=""/>
                <param name="SAMIFilename" value=""/>
                <param name="captioningID" value=""/>
                <embed src="<%=ChannelMMSStr %>" autostart="1" type="video/x-ms-wmv" width="480" height="320"/>
            </object>
        </asp:Panel>
        <asp:Panel ID="mobileLiveStramPlaybackPannel" runat="server" Visible="false">
            <div id="VLCPlayerWindows">
                <div style="margin: auto auto; width: 650px">
                    <object classid="clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921" id="vlc"
                        codebase="http://download.videolan.org/pub/videolan/vlc/0.8.6c/win32/axvlc.cab"
                        width="640" height="480" id="vlc" events="True">
                        <param name="MRL" value="" />
                        <param name="ShowDisplay" value="True" />
                        <param name="AutoLoop" value="False" />
                        <param name="AutoPlay" value="False" />
                        <param name="Time" value="True" />
                        <embed pluginspage="http://www.videolan.org"
                            type="application/x-vlc-plugin"
                            version="VideoLAN.VLCPlugin.2"
                            width="640"
                            height="480"
                            text="Waiting for video"
                            name="vlc"></embed>
                    </object>
                </div>
                <div style="text-align: center;">
                    <input type="button" id="btn_play" value="播放 " title="rtsp://<%=ChannelMMSStr %>?h264&amr" onclick='doPlay(this.title); return false;'/>
                    <input type="button" id="btn_stop" value="停止" onclick='doStop();' disabled="True"/>
                    <input type="button" value="静音切换" onclick='getVLC("vlc").audio.togglemute();'/>
                    <input type="button" value="减小音量" onclick='updateVolume(-10);'/>
                    <input type="button" value="增加音量" onclick='updateVolume(+10);'/>
                </div>
            </div>
        </asp:Panel>
        <br />
        <p>
            <asp:Button ID="updateChannelBtn" runat="server" Text="更新频道" OnClick="updateChannelBtn_Click" />&nbsp;
            <input type="button" value="返回" onclick="javascript: history.back(1)" />
        </p>
    </div>
</asp:Content>
