<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="searchCourse.aspx.cs" Inherits="vclass_clone.web_form.student.searchCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="content-wrapper">
            <div class="row mb-4">
                <!-- Header and Search Form -->
                <div class="col-md-12">
                    <h1 class="mb-0">Search for Courses</h1>
                    <div class="row mt-4">
                        <div class="col-md-8">
                            <asp:TextBox ID="txtSearchQuery" runat="server" CssClass="form-control" Placeholder="Enter course name or code"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <!-- Repeater for Displaying Search Results -->
                <asp:Repeater ID="rptSearchResults" runat="server" OnItemCommand="rptSearchResults_ItemCommand1">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card">
                                <div class="card-header">
                                    <h5 class="card-title"><%# Eval("Name") %> (<%# Eval("Code") %>)</h5>
                                </div>
                                <img src='<%# Eval("ImagePath") %>' class="card-img-top" alt="Course Image">
                                <div class="card-body">
                                    <p class="card-text"><%# Eval("Description") %></p>
                                    <asp:LinkButton ID="btnEnroll" runat="server" CssClass="btn btn-success" CommandName="Enroll" CommandArgument='<%# Eval("Id") %>'>Enroll</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- No Results Message -->
                <asp:Label ID="lblNoResults" runat="server" CssClass="alert alert-info d-none" Text="No courses found matching your search." />
            </div>
        </div>
    </div>
</asp:Content>

