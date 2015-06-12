<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bekijk.aspx.cs" Inherits="GHMusic.Admin.Forum.Bekijk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Subforums</h3>
    <table class="auto-style1">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="auto-style3">
                        <p><%# Eval("FORUMID") %></p>
                    </td>
                    <td class="auto-style7">
                        <a href="Bekijk.aspx?forumID="<%# Eval("FORUMID") %>"> <%# Eval("NAAM") %></a>
                    </td>
                    <td>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>

    <h3>Topics</h3>
    <table class="auto-style1">
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="auto-style3">
                        <p><%# Eval("TOPICID") %></p>
                    </td>
                    <td class="auto-style7">
                        <a href="/Topic/Bekijk.aspx?topicID=<%# Eval("TOPICID") %>"> <%# Eval("TITEL") %></a>
                    </td>
                    <td>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
