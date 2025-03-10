﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="userAdd.aspx.cs" Inherits="vclass_clone.web_form.admin.userAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div class="mb-4">
                <asp:Button runat="server" Text="Go Back" ID="goBack" CssClass="btn btn-success font-weight-bold" OnClick="goBack_Click" Height="49px" Width="141px" />
            </div>

            <div class="d-flex justify-content-center vertical-center">
                <div class="row justify-content-center">
                    <div class="col-md-12">
                        <div class="card centered-form">
                            <div class="card-header badge-primary">
                                <h3>Add Administrator</h3>
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
                                    <div class="col-md-12 form-group">
                                        <label for="txtAddress">Address</label>
                                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control" />
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAddAdmin" runat="server" Text="Save" CssClass="btn btn-primary" Width="140px" OnClick="btnAddAdmin_Click" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" Width="140px" OnClick="btnClear_Click" />
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
