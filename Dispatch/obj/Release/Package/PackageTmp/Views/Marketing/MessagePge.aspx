<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessagePge.aspx.cs" Inherits="Dispatch.Views.Marketing.MessagePge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-xl-9 col-lg-10 col-md-12 col-sm-12 mx-auto">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Painel de Mensagens</h2>
              </div>
            </div>
            <div class="row tm-edit-product-row">
              <div class="col-xl-6 col-lg-6 col-md-12">
                <form action="" class="tm-edit-product-form">
                  <div class="form-group mb-3">
                      <asp:Label ID="lbl_title" runat="server" Text="Titulo" ForeColor="White"></asp:Label>
                      <asp:TextBox ID="txt_title" runat="server" class="form-control validate" required></asp:TextBox>
                  </div>
                  <div class="form-group mb-3">
                      <asp:Label ID="lbl_description" runat="server" Text="Descrição" ForeColor="White"></asp:Label>
                      <asp:TextBox ID="txt_description" runat="server" class="form-control validate" rows="3" required TextMode="MultiLine"></asp:TextBox>
                  </div>
                     <div class="form-group mb-3">
                      <asp:Label ID="lbl_img" runat="server" Text="Link da Imagem" ForeColor="White"></asp:Label>
                      <asp:TextBox ID="txt_img" runat="server" class="form-control validate" required></asp:TextBox>
                  </div>
                     <div class="form-group mb-3">
                      <asp:Label ID="lbl_link" runat="server" Text="Link Redirecionado(Campanha)" ForeColor="White"></asp:Label>
                      <asp:TextBox ID="txt_link" runat="server" class="form-control validate" required></asp:TextBox>
                  </div>
                  <div class="form-group mb-3">
                    <asp:Label ID="lbl_category" runat="server" Text="Categoria" ForeColor="White"></asp:Label>
                      <asp:DropDownList ID="dd_category" runat="server" class="custom-select tm-select-accounts">
                          <asp:ListItem Text="Selecione a Categoria"></asp:ListItem>
                          <asp:ListItem Text="Email"></asp:ListItem>
                          <asp:ListItem Text="WhatsApp"></asp:ListItem>
                          <asp:ListItem enabled="false" Text="Ambos"></asp:ListItem>
                      </asp:DropDownList>

                  </div>
                  <!--<div class="row">
                        <div class="form-group mb-3 col-xs-14 col-sm-8" >
                          <asp:Label ID="lbl_date" runat="server" Text="Data" ForeColor="White"></asp:Label>
                          <asp:TextBox ID="txt_date" runat="server" class="form-control validate" required TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3 col-xs-10 col-sm-4">
                          <asp:Label ID="lbl_amount" runat="server" Text="Quantidade" ForeColor="White"></asp:Label>
                      <asp:TextBox ID="txt_amount" runat="server" class="form-control validate" required></asp:TextBox>
                        </div>
                  </div> -->
                  </form>
              </div>
              <!--<div class="col-xl-6 col-lg-6 col-md-12 mx-auto mb-4">
                <div class="tm-product-img-dummy mx-auto">
                  <i
                    class="fas fa-cloud-upload-alt tm-upload-icon"
                    onclick="document.getElementById('fileInput').click();"
                  ></i>
                </div>
                <div class="custom-file mt-3 mb-3">
                  <input id="fileInput" type="file" style="display:none;" />
                  <input
                    type="button"
                    class="btn btn-primary btn-block mx-auto"
                    value="UPLOAD IMAGE"
                    onclick="document.getElementById('fileInput').click();"
                  />
                </div>
              </div> -->
              <div class="col-12">
                  <asp:Button ID="btn_enviar" runat="server" Text="Enviar" class="btn btn-primary btn-block text-uppercase" Onclick="btn_enviar_Click" />
                  <asp:Button ID="btn_visualizar" runat="server" Text="Visualizar" class="btn btn-primary btn-block text-uppercase mb-3"  OnClick="btn_visualizar_Click" Visible="false"/>
                  <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" class="btn btn-primary btn-block text-uppercase" Onclick="btn_cancelar_Click" />
              </div>
                <br />
                <asp:Label ID="lbl_erro" runat="server" Text="" CssClass="alert" ForeColor="#990000" Font-Bold="True"></asp:Label>
                
            </div>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
