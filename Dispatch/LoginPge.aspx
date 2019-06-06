<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPge.aspx.cs" Inherits="Dispatch.LoginPge" %>
<asp:Content ID="cttLogin" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-12 mx-auto tm-login-col">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12 text-center">
                <h2 class="tm-block-title mb-4">Bem vindo Ao Dispatch.</h2>
                  <h3 class="tm-block-title mb-4"> Faça o Login</h3>
              </div>
            </div>
            <div class="row mt-2">
              <div class="col-12">
                <form action="index.html" method="post" class="tm-login-form">
                  <div class="form-group">
                    <label for="username">Login</label>
                     <asp:TextBox ID="txt_user" runat="server" class="form-control validate" required></asp:TextBox>
                  </div>
                  <div class="form-group mt-3">
                    <label for="password">Senha</label>
                    <asp:TextBox ID="txt_pass" runat="server" class="form-control validate" required TextMode="Password"></asp:TextBox>
                  </div>
                  <div class="form-group mt-4">
                      <asp:Button ID="btn_confirmar" runat="server" Text="Confirmar" class="btn btn-primary btn-block text-uppercase" OnClick="btn_confirmar_Click" />
                  </div>
                  <button class="mt-5 btn btn-primary btn-block text-uppercase">
                    Esqueceu sua senha?
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

</asp:Content>
