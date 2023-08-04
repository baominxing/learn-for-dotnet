<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SampleCode003.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <asp:Login
            ID="Login1"
            runat="server"
            DestinationPageUrl="~/Default.aspx"
            PasswordRecoveryText="找回密码"
            PasswordRecoveryUrl="~/Account/PasswordRecovery.aspx"
            CreateUserText="创建用户"
            CreateUserUrl="~/Account/Register.aspx">
        </asp:Login>

        <asp:Label ></asp:Label>
    </main>
</asp:Content>


