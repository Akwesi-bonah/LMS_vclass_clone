<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Facilitator.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="vclass_clone.web_form.facilitator.QuestionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content-wrapper">
    <div class="page-header">
        <h3 class="page-title">
            <asp:Label ID="lblCode" runat="server" Text=""></asp:Label> 
            (<asp:Label ID="lblSubj" runat="server" Text=""></asp:Label>)
        </h3>
        
    </div>

    <div class="card">
        <div class="card-body">
            <h4 class="card-title">
                <asp:Button runat="server" ID="btnAddQuestion" Text="Add Question" CssClass="btn btn-success" OnClick="btnAddQuestion_Click" />
            </h4>
            <div>
                <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
            </div>
            <div class="row">
                <div class="col-12">
                    <div class="table-responsive">
                        <table id="order-listing" class="table">
                            <thead>
                                <tr>
                                    <th>Question Text</th>
                                    <th>Answer</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="QuestionRepeater" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("QuestionText") %></td>
                                            <td><%# Eval("Answer") %></td>
                                            <td>
                                                <div>
                                                    <asp:Button runat="server" ID="btnEdit" Text="Edit"/>
                                                </div>
                                                <div>
                                                    <asp:Button runat="server" ID="btnDelete" Text=""/>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
