<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aanmaken.aspx.cs" Inherits="GHMusic.Land.Aanmaken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblFormHandler" runat="server" Text=""></asp:Label>
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblUsername" runat="server" Text="Naam:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbCountryName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbCountryName" ErrorMessage="Landnaam is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Landcode:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="tbCountryCode" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCountryCode" ErrorMessage="Landcode is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Land aanmaken" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
