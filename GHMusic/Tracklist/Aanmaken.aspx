<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aanmaken.aspx.cs" Inherits="GHMusic.Tracklist.Aanmaken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblFormHandler" runat="server" Text=""></asp:Label>
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblUsername" runat="server" Text="Naam tracklist:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbEventName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbEventName" ErrorMessage="Tracklist naam is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Artiest:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddArtistID" runat="server" DataSourceID="orclSrcArtistID" DataTextField="NAAM" DataValueField="ARTIESTID">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddArtistID" ErrorMessage="Artiest is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label2" runat="server" Text="Evenement:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddEventID" runat="server" DataSourceID="orclSrcEventID" DataTextField="NAAM" DataValueField="LOCATIEID">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddEventID" ErrorMessage="Evenement is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label4" runat="server" Text="Datum:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Calendar ID="dtpDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Forum aanmaken" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="orclSrcEventID" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;EVENEMENT&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="orclSrcArtistID" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;ARTIEST&quot;"></asp:SqlDataSource>
</asp:Content>
