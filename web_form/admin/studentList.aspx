﻿<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="studentList.aspx.cs" Inherits="vclass_clone.web_form.admin.studentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="content-wrapper">
        <div class="row">
            <div>
                <div class="col-1">
                    <asp:Button runat="server" Text="Add New" ID="addBtn" CssClass="btn btn-success font-weight-bold" OnClick="addBtn_Click" Height="51px" />

                </div>
                <br />
                <div class="col-lg-12 grid-margin stretch-card">
                    <asp:Label ID="lblError" runat="server" Visible="false" Text=""></asp:Label>

                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title">Student  List </h4>
                            <p class="card-description">
                                 Registered Student
                            </p>
                            <div class="table-responsive">

                                <asp:GridView ID="StuList" CssClass="table  datatable  table-striped" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnRowCommand="StuList_RowCommand" OnRowDeleting="StuList_RowDeleting" >
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False" />
                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                                        <asp:BoundField DataField="StudentNumber" HeaderText="StudentNumber" SortExpression="StudentNumber" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                                        <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                                        <asp:BoundField DataField="Group.Name" HeaderText="Group" SortExpression="Level" />

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
