<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="FacilitatorAdd.aspx.cs" Inherits="vclass_clone.web_form.admin.FacilitatorAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="content-wrapper">
        <div class="row">
            <div>
                <asp:Button runat="server" Text="Go Back" ID="goBack" CssClass="btn btn-success font-weight-bold" OnClick="goBack_Click"  />
            </div>
            <br />
                 <div class="container vertical-center">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card centered-form">
                        <div class="card-header badge-primary">
                            <h3>Add Facilitator</h3>
                        </div>
                        <div class="card-body">
                            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="False" />
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label for="txtFirstName">First Name</label>
                                    <asp:TextBox ID="txtFirstName" TextMode="SingleLine" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6 form-group">
                                    <label for="txtLastName">Last Name</label>
                                    <asp:TextBox ID="txtLastName" TextMode="SingleLine" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label for="txtPhone">Phone</label>
                                    <asp:TextBox ID="txtPhone" TextMode="Number" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-md-6 form-group">
                                    <label for="txtEmail">Email</label>
                                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label for="lbldepartment">Department</label>
                                    <asp:DropDownList ID="departmentList" CssClass="form-select" runat="server" DataSourceID="aqldepartment" DataTextField="Name" DataValueField="Id">
                                        <asp:ListItem>Test</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="aqldepartment" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [DepartmentDBs]"></asp:SqlDataSource>
                                </div>
                                <div class="col-md-6 form-group">
                                    <label for="txtAddress">Address</label>
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control" />
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label for="txtPwd">Password</label>
                                    <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" TextMode="Password" />
                                </div>
                                <div class="col-md-6 form-group">
                                    <label for="txtCpwd">Confirm Password</label>
                                    <asp:TextBox ID="txtCpwd"  runat="server" CssClass="form-control" TextMode="Password" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button  ID="btnAddFac" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAddFac_Click"    />
                                </div>
                                <div class="col-md-6 text-right">
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary"  OnClick="btnClear_Click"  />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
