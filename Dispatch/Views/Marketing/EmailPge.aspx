<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailPge.aspx.cs" 
    Inherits="Dispatch.Views.Marketing.EmailPge" %>
<asp:Content ID="cttEmail" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container mt-5">
        
      <div class="row tm-content-row">
         
        <div class="col-sm-12 col-md-12 col-lg-8 col-xl-8 tm-block-col">
             
          <div class="tm-bg-primary-dark tm-block tm-block-products">
              <h2 class="tm-block-title"> Tabela De Busca</h2>
                <div class="tm-product-table-container">
                    <asp:Table ID="tbl_control" runat="server" class="table table-hover tm-table-small tm-product-table">
                        <asp:TableHeaderRow  CssClass="bg-dark">
                            <asp:TableCell Text ="ALUNO"></asp:TableCell>
                            <asp:TableCell Text ="EMAIL"></asp:TableCell>
                            <asp:TableCell Text ="TELEFONE"></asp:TableCell>
                            <asp:TableCell Text ="DATA" TYPE="DATE"></asp:TableCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            <!-- table container -->
              <asp:Button ID="btn_enviar" runat="server" Text="Enviar Emails" class="btn btn-primary btn-block text-uppercase mb-3"  OnClick="btn_enviar_Click"/>
              <asp:Button ID="btn_carregar" runat="server" Text="Carregar" class="btn btn-primary btn-block text-uppercase" OnClick="btn_carregar_Click" />
          </div>
        </div>
        <div class="col-sm-12 col-md-12 col-lg-4 col-xl-4 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-product-categories">
            <h2 class="tm-block-title"> Filtro De Busca</h2>
            <div class="tm-product-table-container">
                <asp:Table ID="tbl_empresa" runat="server" class="table tm-table-small tm-product-table">
                    <asp:TableHeaderRow ID="thr_control" >
                        <asp:TableCell Text="01 - Hi Tamarineira"  class="tm-product-name" ></asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
              
            <!-- table container -->
            <button class="btn btn-primary btn-block text-uppercase mb-3">
              Adicionar Filtro
            </button>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
