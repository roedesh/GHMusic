<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTopic.aspx.cs" Inherits="GHMusic.Topic.CreateTopic" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Topic aanmaken in "<asp:Literal ID="lblForumName" runat="server" />"</h1>
    <asp:Label ID="lblFormHandler" runat="server" Text=""></asp:Label>
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblTopicTitle" runat="server" Text="Topictitel:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbTopicTitle" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbTopicTitle" ErrorMessage="Topictitel is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Parent forum ID:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox id="tbBody" rows="5" TextMode="multiline" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbBody" ErrorMessage="Tekst is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Topic aanmaken" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
