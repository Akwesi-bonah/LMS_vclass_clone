<%--<%--<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Student.Master" AutoEventWireup="true" CodeBehind="assignment.aspx.cs" Inherits="vclass_clone.web_form.facilitator.assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <div class="content-wrapper">
        <div class="page-header">
            <h3 class="page-title">
                <%--<asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label> - <asp:Label ID="lblSubj" runat="server" Text="Label"></asp:Label>--%>
                <asp:Label ID="lblCode" runat="server" Text=" Upload Assignment"></asp:Label>
            </h3>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <%--<div class="card-header">
                        Add Contents
                    </div>--%>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">File</label>
                                    <div class="col-sm-9">
                                        <asp:FileUpload accept=".pdf, .docx, .txt,  .zip" CssClass="dropify" ID="fu1" runat="server"></asp:FileUpload>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">File Name</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtFilename" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">File Name</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDeadline" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-3 col-form-label">Description</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtDescription" TextMode="Multiline" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <asp:Button ID="btnAdd" CssClass="btn btn-primary mb-2" runat="server" Text="Submit" OnClick="btnAdd_Click" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <asp:Panel ID="panel_index_warning" runat="server" Visible="false">
                                        <div class="card-footer">
                                            <br />
                                            <div class="alert alert-danger text-center">
                                                <asp:Label ID="lbl_indexwarning" runat="server" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">All Assignments
                        </h4>
                        <div class="row">
                            <div class="col-12">
                                <div class="table-responsive">
                                    <table class="table table-hover" id="order-listing">
                                        <thead>
                                            <tr>
                                                <th>Date Uploaded</th>
                                                <th>File Name</th>
                                                <th>Description</th>
                                                <th>Download</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%
                                                foreach (var item in listclients)
                                                { %>
                                                    <tr>
                                                        <td><%= item.filename %></td>
                                                        <td><%= item.deadline %></td>
                                                        <%--<td><%= item.username %></td>--%>
                                                        <td></td>
                                                        <td>
                                                            <a href="../<%= item.filelocation %>" class="ad-st-view" download><i class="fa fa-download"></i></a>&nbsp&nbsp&nbsp
                                                        <a href="submittedassignments.aspx?assignmentid=<%= item.id %>&subjectid=<%= subjectid %>" class="ad-st-view"><i class="fa fa-folder-open"></i></a>
                                                        </td>
                                                        <td>
                                                            <a href="deleteAssign.aspx?id=<%= item.id %>&subjectid=<%= subjectid %>" class="ad-st-view red"><i class="fa fa-eraser"></i></a>
                                                        </td>
                                                    </tr>
                                            <% } %>
                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>--%>--%>
