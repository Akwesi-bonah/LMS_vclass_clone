<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="courseEnrollList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.courseEnrollList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div class="content-wrapper">
    <div class="row">
        <!-- Course Details Card -->
        <div class="card mb-4">
            <div class="card-body">
                <asp:Label ID="lblCourseTitle" runat="server"  Text="Title" CssClass="display-4"></asp:Label>
                <asp:Label ID="lblCourseDescription" runat="server" Text="description"  CssClass="text-muted"></asp:Label>
            </div>
        </div>

        <!-- Error Label -->
        
            <asp:Label ID="lblError" CssClass="alert alert-dange"  runat="server"></asp:Label>
       

        <!-- Enrolled Students Card -->
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Enrolled Students</h4>
            </div>
            <div class="card-body">
                <asp:GridView ID="StudentsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="StudentsGridView_RowCommand" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="StudentNumber" HeaderText="Student Number" />
                        <asp:BoundField DataField="Level" HeaderText="Level" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnViewDetails" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("StudentId") %>' CssClass="btn btn-info btn-sm">
                                    View Details
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>

</asp:Content>
