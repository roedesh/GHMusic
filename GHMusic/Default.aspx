<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GHMusic.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;FORUM&quot;"></asp:SqlDataSource>
    <table class="auto-style1">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <tr>
                <td class="auto-style3">
                    <p><%# Eval("FORUMID") %></p>
                </td>
                <td class="auto-style7">
                    <a href="Forum/Bekijk.aspx?forumID=<%# Eval("FORUMID") %>"><%# Eval("NAAM") %></a>
                </td>
                <td>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
        </table>
    
    
    
</asp:Content>
