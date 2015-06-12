<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateForum.aspx.cs" Inherits="GHMusic.Admin.CreateForum" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblFormHandler" runat="server" Text=""></asp:Label>
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblUsername" runat="server" Text="Forumnaam:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbForumName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbForumName" ErrorMessage="Forumnaam is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Parent forum:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddParentForumID" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAAM" DataValueField="FORUMID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Forum aanmaken" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT &quot;FORUMID&quot;, &quot;NAAM&quot; FROM &quot;FORUM&quot;"></asp:SqlDataSource>
</asp:Content>
