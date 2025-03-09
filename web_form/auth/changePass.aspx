<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePass.aspx.cs" Inherits="vclass_clone.web_form.auth.changePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
  <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/components/logins/login-9/assets/css/login-9.css">
</head>
<body>
    <form id="form1" runat="server">
            <div class="row justify-content-center">
                <div class="col-md-6 col-lg-4">
                    <div class="card border-0 rounded-4 shadow-lg">
                        <div class="card-body p-4">
                            <h3 class="text-center">Change Your Password</h3>
                            <asp:Label runat="server" ID="lblErrorMessage" CssClass="text-danger text-center d-block mb-3" Visible="false" />
                            <asp:Label runat="server" ID="lblSuccessMessage" CssClass="text-success text-center d-block mb-3" Visible="false" />

                            

                            <!-- New Password Input -->
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="form-control" placeholder="New Password" required="required"></asp:TextBox>
                                <label for="txtNewPassword" class="form-label">New Password</label>
                            </div>

                            <!-- Confirm New Password Input -->
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm New Password" required="required"></asp:TextBox>
                                <label for="txtConfirmPassword" class="form-label">Confirm New Password</label>
                            </div>

                            <!-- Change Password Button -->
                            <div class="d-grid mb-3">
                                <asp:Button runat="server" ID="btnChangePassword" CssClass="btn btn-primary btn-lg" Text="Change Password" OnClick="btnChangePassword_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
