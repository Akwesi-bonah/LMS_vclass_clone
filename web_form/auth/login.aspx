<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="vclass_clone.web_form.auth.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/components/logins/login-9/assets/css/login-9.css">
</head>
<body>
  <form id="form1" runat="server">
    <section class="bg-light py-5" style="background-image: url('./assets/img/school-background.jpg'); background-size: cover; background-position: center; min-height: 100vh;">
        <div class="container h-100 d-flex flex-column justify-content-center align-items-center">
            <!-- School Logo at the top -->
            <div class="row justify-content-center text-center mb-4">
                <div class="col-12">
                    <img class="img-fluid rounded mb-3" loading="lazy" src="./assets/img/school-logo.svg" width="200" height="80" alt="School Logo">
                </div>
            </div>

            <!-- Welcome Note -->
            <div class="row justify-content-center text-center mb-4">
                <div class="col-12">
                    <h2 class="h1 text-dark">Welcome to ABC Learning Portal</h2>
                    <p class="lead text-dark">Please sign in to access your courses and materials.</p>
                </div>
            </div>

            <!-- Login Form -->
            <div class="col-12 col-md-8 col-lg-6 col-xl-4">
                <div class="card border-0 rounded-4 shadow-lg">
                    <div class="card-body p-4">
                        <div class="row mb-4">
                            <div class="col-12">
                                <h3 class="text-center"> Login</h3>
                                <p class="text-center">Firt time login, use your email for both <a href="#!">Sign up</a></p>
                            </div>
                        </div>

                        <!-- Error Message -->
                        <asp:Label runat="server" ID="lblErrorMessage" CssClass="text-danger text-center d-block mb-3" Visible="false" />

                        <!-- Email Input -->
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="name@example.com" required="required"></asp:TextBox>
                            <label for="txtEmail" class="form-label">Email Address</label>
                        </div>

                        <!-- Password Input -->
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" required="required"></asp:TextBox>
                            <label for="txtPassword" class="form-label">Password</label>
                        </div>

                        <!-- Login Button -->
                        <div class="d-grid mb-3">
                            <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary btn-lg" Text="Log in" OnClick="btnLogin_Click" />
                        </div>

                        <%--<!-- Forgot Password Link -->
                        <div class="text-center">
                            <a href="#!">Forgot your password?</a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
</form>

</body>
</html>
