<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="AssigmentSubmission.aspx.cs" Inherits="vclass_clone.web_form.facilitator.AssigmentSubmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Submissions</h2>
        
        <asp:GridView ID="gvSubmissions" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Student.Name" HeaderText="Student" />
                <asp:BoundField DataField="Content" HeaderText="Submission Content" />
                <asp:BoundField DataField="SubmissionDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:TemplateField HeaderText="Files">
                    <ItemTemplate>
                        <asp:Repeater ID="rptFiles" runat="server">
                            <ItemTemplate>
                                <a href='<%# Eval("FilePath") %>' target="_blank"><%# Eval("FileName") %></a><br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-secondary mt-4" PostBackUrl="~/AssignmentList.aspx">Back to Assignments</asp:LinkButton>
    </div>
</asp:Content>
