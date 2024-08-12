<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="vclass_clone.web_form.facilitator.Course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <h1 class="mt-4">Courses</h1>
        <div class="row">
            <asp:Repeater ID="CoursesRepeater" runat="server" OnItemCommand="CoursesRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-6 mb-6">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                <p class="card-text"><%# Eval("Description") %></p>
                                <asp:Button
                                    ID="ManageButton"
                                    runat="server"
                                    CommandName="ManageCourse"
                                    CommandArgument='<%# Eval("Id") %>'
                                    CssClass="btn btn-primary"
                                    Text="Manage" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

