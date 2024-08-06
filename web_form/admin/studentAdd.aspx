<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="studentAdd.aspx.cs" Inherits="vclass_clone.web_form.admin.studentAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">

            <div class="container vertical-center">
                <div class="row justify-content-left">
                    <div class="col-md-8">
                        <div class="card centered-form">
                            <div class="card-header badge-primary">
                                <h3>Add Student</h3>
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
                                        <label for="lblStNumber">Student Number</label>
                                        <asp:TextBox ID="txtStNumber" TextMode="Number" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="txtEmail">Email</label>
                                        <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label for="lbl_gender">Gender</label>
                                        <asp:DropDownList ID="dbgender" CssClass="form-select" runat="server">
                                            <asp:ListItem>select Gender</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="Sqlgroup" runat="server" ConnectionString="<%$ ConnectionStrings:LMSContext %>" SelectCommand="SELECT [Id], [Name] FROM [GroupDBs]"></asp:SqlDataSource>
                                    </div>

                                    <div class="col-md-6 form-group">
                                        <label for="lbl_level">Level</label>
                                        <asp:DropDownList ID="dpLevel" CssClass="form-select" runat="server">
                                            <asp:ListItem>Select Level</asp:ListItem>
                                            <asp:ListItem>100</asp:ListItem>
                                            <asp:ListItem>200</asp:ListItem>
                                            <asp:ListItem>300</asp:ListItem>
                                            <asp:ListItem>400</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="lblgroup">Group</label>
                                        <asp:DropDownList ID="dbgroup" CssClass="form-select" runat="server" DataSourceID="Sqlgroup" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>
                                    </div>



                                </div>
                                <div class="row">
                                    <div class="col-md-6 form-group">
                                        <label for="txtPwd">Password</label>
                                        <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" TextMode="Password" />
                                    </div>
                                    <div class="col-md-6 form-group">
                                        <label for="txtCpwd">Confirm Password</label>
                                        <asp:TextBox ID="txtCpwd" runat="server" CssClass="form-control" TextMode="Password" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAddStu" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnAddFac_Click" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
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
