<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GHMusic.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 208px;
        }
        .auto-style4 {
            width: 195px;
        }
        .auto-style5 {
            width: 195px;
            height: 24px;
        }
        .auto-style6 {
            width: 208px;
            height: 24px;
        }
        .auto-style7 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblUsername" runat="server" Text="Gebruikersnaam:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" ErrorMessage="Gebruikersnaam is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Wachtwoord:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" ErrorMessage="Wachtwoord is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Inloggen" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
