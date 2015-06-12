<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aanmaken.aspx.cs" Inherits="GHMusic.Locatie.Aanmaken" %>
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
                <asp:TextBox ID="tbLocationName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbLocationName" ErrorMessage="Locatienaam is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Land:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddLandID" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAAM" DataValueField="LANDID">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddLandID" ErrorMessage="Land is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Locatie aanmaken" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;LAND&quot;" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
</asp:Content>
