<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SampleCode001.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="row">
            <div class="col-md-12">
                <label class="col-md-1">账号：</label>
                <input type="text" class="col-md-3" id="Username" name="Username" value="" />
            </div>

            <br />
            <br />

            <div class="col-md-12">
                <label class="col-md-1">密码：</label>
                <input type="password" class="col-md-3" id="Password" name="Password" value="" />
            </div>

            <br />
            <br />

            <div class="col-md-12">
                <label class="col-md-1">记住我：</label>
                <input type="checkbox" class="col-md-1" id="Remember" name="Remember" checked="false" />
            </div>

            <br />

            <div class="col-md-12">
                <label class="col-md-1"></label>
                <input runat="server" type="submit" class="col-md-3" value="登录" onserverclick="Btn_Login" />
            </div>
        </div>
    </main>
</asp:Content>


