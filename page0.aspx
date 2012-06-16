﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeBehind="page0.aspx.cs" Inherits="Injection.page0" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   
</asp:Content>

<asp:Content ID="PageInfo" runat="server" ContentPlaceHolderID="PageInfo">
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer sit amet magna viverra nisi suscipit fermentum quis vel metus. Proin volutpat nisl eu felis feugiat tempor. Sed quam orci, viverra in commodo at, gravida id velit. Ut et tellus ut enim pellentesque consectetur. Suspendisse ac tellus enim, non scelerisque dolor. Fusce pulvinar bibendum libero, quis ultricies nisi imperdiet a. Aenean tincidunt suscipit magna, sed convallis lorem sodales id. </p>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h1>Demo</h1>
        <label>Feature</label>
        <asp:DropDownList ID="cbxFeature" runat="server" />
        
        <label>State</label>
        <asp:DropDownList ID="cbxState" runat="server" />

        <label>County</label>
        <asp:DropDownList ID="cbxCounty" runat="server" />

        <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />

        <asp:Panel ID="pnlResults" runat="server" Visible="false">  
            <table>
                <tr>
                    <td>Name</td>
                    <td>Latitude</td>
                    <td>Longtitude</td>
                </tr>
                <asp:Repeater ID="rptResults" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td><a href='http://maps.google.com/maps?q=<%# DataBinder.Eval(Container.DataItem, "prim_lat_dec") %>,<%# DataBinder.Eval(Container.DataItem, "prim_long_dec") %>&hl=en&z=15'>
                            <%# DataBinder.Eval(Container.DataItem, "name") %></a></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "primary_lat_dms") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "prim_long_dms") %></td>
                    </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:Panel>
</asp:Content>




