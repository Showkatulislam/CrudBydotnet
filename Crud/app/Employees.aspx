<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="app.Employees" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container-md">

            
            <div class="my-2">
                <asp:Label CssClass="form-label" runat="server">Department</asp:Label>
                <asp:DropDownList OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </div>


            <asp:GridView CssClass="table table-striped" AutoGenerateColumns="false" ID="gridData" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="EmployeeId" DataField="employee_id" SortExpression="employee_id" />
                    <asp:BoundField HeaderText="Employee Name" DataField="employee_name" SortExpression="employee_name" />
                    <asp:BoundField HeaderText="Department" DataField="department_name" SortExpression="department_name" />
                    <asp:BoundField HeaderText="Position" DataField="position" SortExpression="position" />
                    <asp:BoundField HeaderText="Salary" DataField="salary" SortExpression="salary" />
                    <asp:BoundField HeaderText="Start Date" DataField="start_data" SortExpression="start_data" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="LinkButton1" runat="server" OnClick="btn_click_edit" CssClass="btn btn-primary" CommandArgument='<%# Eval("employee_id") %>' Text="Edit" />
                            <asp:Button Text="Delete" OnClick="btn_click_delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("employee_id") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </main>

</asp:Content>
