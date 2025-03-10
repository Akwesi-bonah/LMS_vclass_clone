﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="userList.aspx.cs" Inherits="vclass_clone.web_form.admin.userList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div>
                <div class="col-md-3">
                    <asp:Button runat="server" Text="Add New" ID="addBtn" CssClass="btn btn-success font-weight-bold" OnClick="addBtn_Click" Height="52px" />
                </div>
                <br />
                <asp:Label ID="lblError" runat="server" Visible="false" Text=""></asp:Label>
                <div class="col-lg-12 grid-margin stretch-card">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title">Admin List</h4>
                            <p class="card-description">
                                System Administrator
                            </p>
                            <div class="table-responsive">
                                <asp:GridView ID="adminList" CssClass="table table-striped" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="adminList_RowCommand" OnRowDeleting="adminList_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ReadOnly="True" Visible="False" />
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                                        <asp:BoundField DataField="User.Email" HeaderText="Email" SortExpression="User.Email" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' Text="Edit" CssClass="btn btn-primary" />
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="Delete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

