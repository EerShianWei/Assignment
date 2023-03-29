<%@ Page Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="AdminCandidate.aspx.cs" Inherits="Assignment.AdminCandidate" %>

<asp:Content ID="Title" ContentPlaceHolderID="title" runat="server">Candidate</asp:Content>

<asp:Content ID="siteName" ContentPlaceHolderID="siteName" runat="server">Candidate</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DDLCandidate" runat="server" style="float: right">
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="GridCandidate" runat="server" AllowSorting="true" OnSorting="Candidate_Sorting" AllowPaging="true" OnPageIndexChanging="Candidate_PageIndexChanged" PageSize="5" AutoGenerateEditButton="True" AutoGenerateSelectButton="True">
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
    </asp:GridView>
</asp:Content>
