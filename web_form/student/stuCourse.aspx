<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="stuCourse.aspx.cs" Inherits="vclass_clone.web_form.student.stuCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="content-wrapper">
            <div class="row mb-4">
                <!-- Header and Add Course Button -->
                <div class="col-md-12 d-flex justify-content-between align-items-center">
                    <h1 class="mb-0">Your Enrolled Courses</h1>
                    <asp:LinkButton runat="server" ID="btnAddCourse" CssClass="btn btn-success " OnClick="btnAddCourse_Click">
                        <i class="typcn typcn-plus"></i>Add Course</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <asp:Repeater ID="rptEnrolledCourses" runat="server" OnItemCommand="rptEnrolledCourses_ItemCommand">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card">
                                <div class="card-header">
                                    <h5 class="card-title"><%# Eval("Name") %> (<%# Eval("Code") %>)</h5>
                                </div>
                                <img src='<%# Eval("ImagePath") %>' class="card-img-top" alt="Course Image">
                                <div class="card-body">
                                    <p class="card-text"><%# Eval("Description") %></p>
                                    <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-primary" CommandName="ViewCourse" CommandArgument='<%# Eval("Id") %>'>View</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <!-- Label to show when no courses are enrolled -->
                <asp:Label ID="Label1" runat="server" CssClass="alert alert-info" Text="You haven't enrolled in any courses." Visible="False" />

            </div>

        </div>
    </div>
</asp:Content>

