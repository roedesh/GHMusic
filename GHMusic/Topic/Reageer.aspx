<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reageer.aspx.cs" Inherits="GHMusic.Topic.Reageer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bericht aanmaken in "<asp:Literal ID="lblTopicName" runat="server" />"</h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Bericht:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox id="tbBody" rows="5" TextMode="multiline" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbBody" ErrorMessage="Bericht is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Bericht aanmaken" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
