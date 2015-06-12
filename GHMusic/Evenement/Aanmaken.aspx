<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aanmaken.aspx.cs" Inherits="GHMusic.Evenement.Aanmaken" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblFormHandler" runat="server" Text=""></asp:Label>
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblUsername" runat="server" Text="Naam evenement:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbEventName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbEventName" ErrorMessage="Evenement naam is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Organisatie:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddOrganisationID" runat="server" DataSourceID="orclSrcOrganisationID" DataTextField="NAAM" DataValueField="ORGANISATIEID">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddOrganisationID" ErrorMessage="Organisatie is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label2" runat="server" Text="Locatie:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddLocationID" runat="server" DataSourceID="orclSrcLocation" DataTextField="NAAM" DataValueField="LOCATIEID">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddLocationID" ErrorMessage="Locatie is verplicht!"></asp:RequiredFieldValidator>
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
            <td class="auto-style4">
                <asp:Label ID="Label5" runat="server" Text="Tijd:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbTime" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbTime" ErrorMessage="Tijd in uren is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label6" runat="server" Text="Dagen:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbDays" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbDays" ErrorMessage="Aantal dagen is verplicht!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label7" runat="server" Text="Website:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="tbWebsite" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbWebsite" ErrorMessage="Website is verplicht!"></asp:RequiredFieldValidator>
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
    <asp:SqlDataSource ID="orclSrcOrganisationID" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;ORGANISATIE&quot;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="orclSrcLocation" runat="server" ConnectionString="<%$ ConnectionStrings:OracleConnectionString %>" ProviderName="<%$ ConnectionStrings:OracleConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;LOCATIE&quot;"></asp:SqlDataSource>
</asp:Content>
