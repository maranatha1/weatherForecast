<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="POE_AdvancedWeatherForecastingSystem.Weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Weather Update</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="AdminHome.aspx">Advanced Weather System</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="navbar-collapse" id="navbarContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="AdminHome.aspx">Home</a>
                    </li></ul>
                <a href="Home.aspx" class="btn btn-link" role="button" onclick="">Log out</a>
            </div>
        </nav>
        <div class="container">
            <h3 class="text-center">Weather Update</h3>
            <div class="col-sm-10 col-sm-offset-1" style="margin-left: 295px">
                <label class="col-sm-6">City Name</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbCityName" runat="server" CssClass="form-control" placeholder="Enter City Name"></asp:TextBox>
                     </div>
                 <label class="col-sm-6">Date</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbDate" runat="server" CssClass="form-control" placeholder="dd-mm-yyyy"></asp:TextBox>
                     </div>
                 <label class="col-sm-6">Minimum Temperature</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbMinTemp" runat="server" CssClass="form-control" placeholder="0"></asp:TextBox>
                     </div>
                 <label class="col-sm-6">Maximum Temperature</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbMaxTemp" runat="server" CssClass="form-control" placeholder="0"></asp:TextBox>
                     </div>
                 <label class="col-sm-6">Percipation</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbPercipation" runat="server" CssClass="form-control" placeholder="percipation"></asp:TextBox>
                     </div>
                 <label class="col-sm-6">Humidity</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbHumidity" runat="server" CssClass="form-control" placeholder="Humidity"></asp:TextBox>
                     </div>
                 <label class="col-sm-6">Wind Speed</label>
                     <div class="col-sm-6">
                          <asp:TextBox ID="tbWindSpeed" runat="server" CssClass="form-control" placeholder="Wind Speed"></asp:TextBox>
                     </div>
                <div style="margin-top: 20px; margin-left: 15px">
                    <asp:Button ID="btnAddWeather" CssClass="btn btn-warning col-sm-3 form-control" Text="Add Weather Details" runat="server" OnClick="btnAddWeather_Click" />
                </div>               
            </div>
             <br />

            <h3 class="text-center" >Weather Details</h3>
                <div class="row" style='position: center; overflow: auto'>
                    <asp:GridView ID="dgvWeatherUpdate" runat="server" AutoGenerateColumns="false" OnRowCancelingEdit="dgvWeatherUpdate_RowCancelingEdit" OnRowEditing="dgvWeatherUpdate_RowEditing" Width="1400px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="1" OnRowCommand="dgvWeatherUpdate_RowCommand" OnRowDeleting="dgvWeatherUpdate_RowDeleting" OnRowUpdating="dgvWeatherUpdate_RowUpdating">
                     <Columns>
                         <asp:TemplateField HeaderText="Action">
                             <ItemTemplate>
                                 <asp:ImageButton ImageUrl="~/images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                                 
                             </ItemTemplate>
                             <EditItemTemplate>
                                 <asp:ImageButton ImageUrl="~/images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                                 <asp:ImageButton ImageUrl="~/images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                             </EditItemTemplate>
                             <FooterTemplate>
                                 <asp:ImageButton ImageUrl="~/images/add.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                             </FooterTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="City Name">
                             <ItemTemplate>
                                 <asp:Label ID="lblCityName" runat="server" Text='<%# Eval("CityName") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbCityName" runat="server" Text='<%# Eval("CityName") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Date">
                             <ItemTemplate>
                                 <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbDate" runat="server" Text='<%# Eval("Date") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Minimum Temperature">
                             <ItemTemplate>
                                 <asp:Label ID="lblMinimumTemperature" runat="server" Text='<%# Eval("MinimumTemperature") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbMinimumTemperature" runat="server" Text='<%# Eval("MinimumTemperature") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Maximum Temperature">
                             <ItemTemplate>
                                 <asp:Label ID="lblMaximumTemperature" runat="server" Text='<%# Eval("MaximumTemperature") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbMaximumTemperature" runat="server" Text='<%# Eval("MaximumTemperature") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Percipation">
                             <ItemTemplate>
                                 <asp:Label ID="lblPercipation" runat="server" Text='<%# Eval("Percipitation") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbPercipation" runat="server" Text='<%# Eval("Percipitation") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Humidity">
                             <ItemTemplate>
                                 <asp:Label ID="lblHumidity" runat="server" Text='<%# Eval("Humidity") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbHumidity" runat="server" Text='<%# Eval("Humidity") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>
                     <asp:TemplateField HeaderText="Wind Speed">
                             <ItemTemplate>
                                 <asp:Label ID="lblWindSpeed" runat="server" Text='<%# Eval("WindSpeed") %>' />
                             </ItemTemplate> 
                             <ItemTemplate>
                                 <asp:TextBox ID="tbWindSpeed" runat="server" Text='<%# Eval("WindSpeed") %>' />
                             </ItemTemplate> 
                         </asp:TemplateField>                         
                     </Columns>
                 </asp:GridView>
                </div>                 
                <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
