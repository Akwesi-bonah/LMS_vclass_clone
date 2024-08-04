<%@ Page Title="" Language="C#" MasterPageFile="~/web_form/views/Admin.Master" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="vclass_clone.web_form.admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content-wrapper">
        <div class="row">
            <div class="col-xl-6 grid-margin stretch-card flex-column">
                <h5 class="mb-2 text-titlecase mb-4">Status statistics</h5>
                <div class="row">
                    <div class="col-md-6 grid-margin stretch-card">
                        <div class="card">
                            <div class="card-body d-flex flex-column justify-content-between">
                                <div class="d-flex justify-content-between align-items-center mb-2">
                                    <p class="mb-0 text-muted">Transactions</p>
                                    <p class="mb-0 text-muted">+1.37%</p>
                                </div>
                                <h4>1352</h4>
                                <canvas id="transactions-chart" class="mt-auto" height="65"></canvas>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 grid-margin stretch-card">
                        <div class="card">
                            <div class="card-body d-flex flex-column justify-content-between">
                                <div class="d-flex justify-content-between align-items-center mb-2">
                                    <div>
                                        <p class="mb-2 text-muted">Sales</p>
                                        <h6 class="mb-0">563</h6>
                                    </div>
                                    <div>
                                        <p class="mb-2 text-muted">Orders</p>
                                        <h6 class="mb-0">720</h6>
                                    </div>
                                    <div>
                                        <p class="mb-2 text-muted">Revenue</p>
                                        <h6 class="mb-0">5900</h6>
                                    </div>
                                </div>
                                <canvas id="sales-chart-a" class="mt-auto" height="65"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
