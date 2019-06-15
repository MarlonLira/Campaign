<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactLeadsPge.aspx.cs" Inherits="Dispatch.Views.Marketing.ContactLeadsPge" %>
<%@ Import Namespace="System.Web.Optimization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <!-- row -->
        <div class="row tm-content-row">
        <asp:Panel ID="pnl_img_control" runat="server" class="tm-block-col tm-col-avatar">
          <!--<div class="tm-block-col tm-col-avatar">-->
            <div class="tm-bg-primary-dark tm-block tm-block-avatar">
              <h2 class="tm-block-title">Aluno</h2>
              <div class="tm-avatar-container">
                <img
                  src="../../img/img_avatar.png"
                  alt="Avatar"
                  class="tm-avatar img-fluid mb-4"
                />
                
              </div>
              <div class="form-group col-lg-16">
                <label for="name">Nome</label>
                <asp:TextBox  ID="txt_nome" runat="server" class="form-control validate" Text="Maria Bianca da Silva" readonly="true" BackColor="#54657d"></asp:TextBox>
             </div>
            </div>
          <!--</div>-->
        </asp:Panel>
          <div class="tm-block-col tm-col-account-settings">
            <div class="tm-bg-primary-dark tm-block tm-block-settings">
              <h2 class="tm-block-title">Informações</h2>
              <div class="tm-signup-form row">
                <div class="form-group col-lg-6">
                    <label for="name">Matricula</label>
                    <asp:TextBox ID="txt_matricula" runat="server" class="form-control validate" Text="005226688" readonly="true" BackColor="#54657d"></asp:TextBox>
                </div>

                <div class="form-group col-lg-6">
                    <label for="email">Email</label>
                    <asp:TextBox ID="txt_email" runat="server" class="form-control validate" Text="bianca@gmail.com" readonly="true" BackColor="#54657d"></asp:TextBox>
                </div>
                  
                <div class="form-group col-lg-6">
                    <label for="password2">Ultimo Contato</label>
                    <asp:TextBox ID="txt_data_ult_contato" runat="server" class="form-control validate" Text="01/06/2019" readonly="true" BackColor="#54657d"></asp:TextBox>
                </div>

                <div class="form-group col-lg-6">
                    <label for="password2">Vigencia Final</label>
                    <asp:TextBox ID="txt_data" runat="server" class="form-control validate" Text="30/06/2019" readonly="true" BackColor="#54657d"></asp:TextBox>
                </div>

                <div class="form-group col-lg-6">
                    <label for="password">Telefone</label>
                    <asp:TextBox ID="txt_telefone" runat="server" class="form-control validate" Text="(81) 9 8555-6969" readonly="true" BackColor="#54657d"></asp:TextBox>
                </div>

                <div class="form-group col-lg-6">
                    <label for="phone">Whats App Link</label>
                    <a style='color: white;' target='_blank' href="http://www.bit.ly/2WpqTmq">
                        <asp:TextBox ID="txt_link" runat="server" class="form-control validate" readonly="true" BackColor="#54657d">www.bit.ly/2WpqTmq</asp:TextBox>
                    </a>
                </div>
                
                <div class="col-12">
                    <asp:Button ID="btn_prox_lead" runat="server" Text="Proximo Lead" class="btn btn-primary btn-block text-uppercase"/>
                </div>
              </div>
            </div>
          </div>
        </div>

        <asp:Panel ID="pnl_observacao" runat="server">
            
            <div class="row tm-content-row">
                <div class="tm-block-col tm-col-avatar">
                    <div class="tm-bg-primary-dark tm-block tm-block-avatar">
                    <h2 class="tm-block-title">Observações</h2>                    
                        
                            <asp:TextBox  ID="txt_observacao" runat="server" class="form-control validate" Text="Vai fechar o plano de 12x 110" Rows="3" TextMode="MultiLine"></asp:TextBox>
                        
                    </div>
                </div>

                <div class="tm-block-col tm-col-account-settings">
                    <div class="tm-bg-primary-dark tm-block tm-block-settings">
                      <h2 class="tm-block-title">Mensagem Email/SMS</h2>
                        <asp:TextBox  ID="txt_texto" runat="server" class="form-control validate" Text="Bom dia, tentamos entrar em contado mas não conseguimos, temos uma otima promoção para você na Hi academia" Rows="3" TextMode="MultiLine"></asp:TextBox>
                          
                      <div class="tm-signup-form row">
                          
                        <div class="col-6">
                            <br>
                            <asp:Button ID="btn_email" runat="server" Text="Enviar Email" class="btn btn-primary btn-block text-uppercase"/>
                            <br>
                        </div>
                 
                        <div class="col-6">
                            <br>
                            <asp:Button ID="btn_sms" runat="server" Text="Enviar Sms" class="btn btn-primary btn-block text-uppercase"/>
                            <br>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
            
        </asp:Panel>

</div>
    
   
</asp:Content>


