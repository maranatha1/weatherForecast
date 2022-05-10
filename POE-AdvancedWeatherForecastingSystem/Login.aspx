<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="POE_AdvancedWeatherForecastingSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="Home.aspx">Advanced Weather System</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="navbar-collapse" id="navbarContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="Home.aspx">Home</a>
                    </li>              
                </ul>             
            </div>
        </nav>

        <div class="container">
            <h2 class="text-center">Login</h2>
            <div class="col-sm-10 col-sm-offset-1" style="margin-left: 290px">
                
                <label class="col-sm-6">Email</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="tbEmail" CssClass="form-control" placeholder="johnsmith@domain.com" runat="server" TextMode="Email"></asp:TextBox>
                </div>
                
                <label class="col-sm-6" style="margin-top: 10px">Password</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="tbPassword" CssClass="form-control" placeholder="password" runat="server" TextMode="Password"></asp:TextBox>
                </div>

                <div style="margin-top:20px; margin-left:15px">
                    <asp:Button ID="btnLogin" CssClass="btn btn-warning form-control col-sm-2" Text="Login" runat="server" OnClick="btnLogin_Click" />
                    <a href="Register.aspx">Do not have an acount?</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
