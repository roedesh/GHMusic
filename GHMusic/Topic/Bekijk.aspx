<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bekijk.aspx.cs" Inherits="GHMusic.Topic.Bekijk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Berichten in "<asp:Literal ID="lblTopicTitle" runat="server" />"</h3>
    <table class="auto-style1">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="auto-style3">
                        <p>
                            <%# Eval("ACCOUNTID") %>
                        </p>
                    </td>
                    <td>
                        <%# Eval("TEKST") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
