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
      <!-- Login 9 - Bootstrap Brain Component -->
<section class="bg-primary py-3 py-md-5 py-xl-8">
  <div class="container">
    <div class="row gy-4 align-items-center">
      <div class="col-12 col-md-6 col-xl-7">
        <div class="d-flex justify-content-center text-bg-primary">
          <div class="col-12 col-xl-9">
            <img class="img-fluid rounded mb-4" loading="lazy" src="./assets/img/bsb-logo-light.svg" width="245" height="80" alt="BootstrapBrain Logo">
            <hr class="border-primary-subtle mb-4">
            <h2 class="h1 mb-4">We make digital products that drive you to stand out.</h2>
            <p class="lead mb-5">We write words, take photos, make videos, and interact with artificial intelligence.</p>
            <div class="text-endx">
            </div>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 col-xl-5">
        <div class="card border-0 rounded-4">
          <div class="card-body p-3 p-md-4 p-xl-5">
            <div class="row">
              <div class="col-12">
                <div class="mb-4">
                  <h3>Sign in</h3>
                  <p>Don't have an account? <a href="#!">Sign up</a></p>
                </div>
              </div>
            </div>
            <asp:Label runat="server" ID="lblErrorMessage" CssClass="text-danger" Visible="false" />
            <div class="row gy-3 overflow-hidden">
              <div class="col-12">
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="name@example.com" required="required"></asp:TextBox>
                  <label for="txtEmail" class="form-label">Email</label>
                </div>
              </div>
              <div class="col-12">
                <div class="form-floating mb-3">
                  <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" required="required"></asp:TextBox>
                  <label for="txtPassword" class="form-label">Password</label>
                </div>
              </div>
              <div class="col-12">
                <div class="d-grid">
                  <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-primary btn-lg" Text="Log in now" OnClick="btnLogin_Click" />
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-12">
                <div class="d-flex gap-2 gap-md-4 flex-column flex-md-row justify-content-md-end mt-4">
                  <a href="#!">Forgot password</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

    </form>
</body>
</html>
