<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container-fluid">
            <h1 class="text-center">Add an Employee</h1>
            <div class="w-50 mx-auto shadow-lg p-5 bg-body rounded">


                <div class="row py-1 mt-2">
                    <asp:Label CssClass="form-label" runat="server">Name</asp:Label>
                    <asp:TextBox runat="server" ID="name" CssClass="form-control"></asp:TextBox>
                </div>


                <div class="row py-1 mt-2">
                    <asp:Label CssClass="form-label" runat="server">Department</asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </div>


                <div class="row py-1 mt-2">
                    <asp:Label CssClass="form-label" runat="server">Position</asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                        <asp:ListItem Value="">Please Select</asp:ListItem>
                        <asp:ListItem Value="junior developer">Junior developer </asp:ListItem>
                        <asp:ListItem Value="senior developer">Senior developer</asp:ListItem>
                    </asp:DropDownList>
                </div>


                <div class="row py-1 mt-2">
                    <asp:Label CssClass="form-label" runat="server">Salary</asp:Label>
                    <asp:TextBox ID="salary" runat="server" CssClass="form-control"></asp:TextBox>
                </div>


                <div class="row py-1 mt-2">
                    <asp:Label CssClass="form-label" runat="server">Start date</asp:Label>
                    <asp:TextBox ID="start_date" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="row mt-3">
                    <asp:Button runat="server" ID="btn" OnClick="btn_Click" CssClass="btn btn-info w-100" Text="add" />
                </div>


            </div>
        </div>
    </main>

</asp:Content>

