<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="facilitatorList.aspx.cs" Inherits="vclass_clone.web_form.admin.facilitatorList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <div class="row">
            <div>
                <div class="col-1">
                    <asp:Button runat="server" Text="Add New" ID="addBtn" CssClass="btn btn-success font-weight-bold" OnClick="addBtn_Click" Height="60px" />

                    <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <br />
                <div class="col-lg-12 grid-margin stretch-card">
                    <div class="card">
                        <div class="card-body">
                            <h4 class="card-title">Facilitator List </h4>
                            <p class="card-description">
                                Facilitators
                            </p>
                            <div class="table-responsive">

                                <asp:GridView ID="FacList" CssClass="table table-boarded" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="FacList_RowCommand"  OnRowDeleting="FacList_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False" />
                                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
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
