﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favourite.aspx.cs" Inherits="POE_AdvancedWeatherForecastingSystem.Favourite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Favourite City</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="GeneralUser.aspx">Advanced Weather System</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="navbar-collapse" id="navbarContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="GeneralUser.aspx">Home<span class="sr-only">(current)</span></a>
                    </li>                    
                </ul>
                
                <a href="Home.aspx" class="btn btn-link" role="button" onclick="">Log out</a>
            </div>
        </nav>
        
        <div class="container overflow-auto">

            <h1 class="text-center">Weather Details</h1>
            <div class="form-group col-md-3" style="padding-left:0px">
                <select id="selectCities" runat="server" class="form-control">
                </select>
            </div>
            <asp:Button ID="btnAddToFav" CssClass="btn btn-warning form-control col-sm-2" Text="Add to favourite" runat="server" OnClick="btnAddToFav_Click" />
            <div class="row " style='position: center; overflow: auto'>
                <div class="col-sm-12">
                    <h3>Favourite Cities</h3>
                    <asp:GridView ID="dgvCity" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="City Name">
                                <ItemTemplate>                                    
                                    <asp:LinkButton ID="tbCityName"
                                        Text='<%# Eval("FavCity") %>'
                                        Font-Names="Verdana"
                                        Font-Size="14pt"
                                        OnClick="tbCityName_Click"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>              

                <div class="col-sm-12">
                    <h3>City Result(s)</h3>
                    <asp:GridView ID="dgvWeatherUpdate" runat="server" AutoGenerateColumns="false" Width="1400px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1">
                        <Columns>
                            <asp:TemplateField HeaderText="City Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCityName" runat="server" Text='<%# Eval("CityName") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbCityName" runat="server" Text='<%# Eval("CityName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbDate" ReadOnly="true" runat="server" Text='<%# Eval("Date") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Minimum Temperature">
                                <ItemTemplate>
                                    <asp:Label ID="lblMinimumTemperature" runat="server" Text='<%# Eval("MinimumTemperature") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbMinimumTemperature" runat="server" Text='<%# Eval("MinimumTemperature") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Maximum Temperature">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaximumTemperature" runat="server" Text='<%# Eval("MaximumTemperature") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbMaximumTemperature" runat="server" Text='<%# Eval("MaximumTemperature") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Percipation">
                                <ItemTemplate>
                                    <asp:Label ID="lblPercipation" runat="server" Text='<%# Eval("Percipitation") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbPercipation" runat="server" Text='<%# Eval("Percipitation") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Humidity">
                                <ItemTemplate>
                                    <asp:Label ID="lblHumidity" runat="server" Text='<%# Eval("Humidity") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbHumidity" runat="server" Text='<%# Eval("Humidity") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Wind Speed">
                                <ItemTemplate>
                                    <asp:Label ID="lblWindSpeed" runat="server" Text='<%# Eval("WindSpeed") %>' />
                                </ItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="tbWindSpeed" runat="server" Text='<%# Eval("WindSpeed") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
