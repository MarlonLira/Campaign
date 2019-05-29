<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailPge.aspx.cs" 
    Inherits="Dispatch.Views.Marketing.EmailPge" %>
<asp:Content ID="cttEmail" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container mt-5">
      <div class="row tm-content-row">
        <div class="col-sm-12 col-md-12 col-lg-8 col-xl-8 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-products">
              <h2 class="tm-block-title"> Tabela De Busca</h2>
              <!-- table container -->
                <div class="tm-product-table-container">
                    <asp:Table ID="tbl_control" runat="server" class="table table-hover tm-table-small tm-product-table">
                        <asp:TableHeaderRow  CssClass="bg-dark">
                            <asp:TableCell Text ="ALUNO"></asp:TableCell>
                            <asp:TableCell Text ="EMAIL"></asp:TableCell>
                            <asp:TableCell Text ="TELEFONE"></asp:TableCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
              <asp:Button ID="btn_enviar" runat="server" Text="Criar Mensagem" class="btn btn-primary btn-block text-uppercase mb-3"  OnClick="btn_enviar_Click"/>
              <asp:Button ID="btn_carregar" runat="server" Text="Carregar" class="btn btn-primary btn-block text-uppercase" OnClick="btn_carregar_Click" />
          </div>
        </div>
        <div class="col-sm-12 col-md-12 col-lg-4 col-xl-4 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-product-categories">
            <h2 class="tm-block-title"> Filtro De Busca</h2>
              <!-- table container -->
              <asp:Panel ID="pnl_control" runat="server">
                    <div class="tm-product-table-container">
                        <asp:DropDownList ID="dd_unidades" runat="server" class="custom-select tm-select-accounts">
                            <asp:ListItem Text ="01 - Hi Tamarineira" class="tm-product-name" Value="1"></asp:ListItem>
                            <asp:ListItem Text ="05 - Hi Espinheiro" class="tm-product-name" Value="5"></asp:ListItem>
                            <asp:ListItem Text ="06 - Hi Bv2" class="tm-product-name" Value="6"></asp:ListItem>
                            <asp:ListItem Text ="10 - Hi Bv3" class="tm-product-name" Value="10"></asp:ListItem>
                            <asp:ListItem Text ="31 - Hi Encruzilhada" class="tm-product-name" Value="31"></asp:ListItem>
                            <asp:ListItem Text ="501 - Grupo Hi" class="tm-product-name"></asp:ListItem>
                            <asp:ListItem Text ="08 - Hix Espinheiro" class="tm-product-name" Value="8"></asp:ListItem>
                            <asp:ListItem Text ="09 - Hix Piedade" class="tm-product-name" Value="9"></asp:ListItem>
                            <asp:ListItem Text ="11 - Hix Olinda" class="tm-product-name" Value="11"></asp:ListItem>
                            <asp:ListItem Text ="12 - Hix Setubal" class="tm-product-name" Value="12"></asp:ListItem>
                            <asp:ListItem Text ="13 - Hix Imbiribeira" class="tm-product-name" Value="13"></asp:ListItem>
                            <asp:ListItem Text ="19 - Hix Ipsep" class="tm-product-name" Value="19"></asp:ListItem>
                            <asp:ListItem Text ="24 - Hix Arruda" class="tm-product-name" Value="24"></asp:ListItem>
                            <asp:ListItem Text ="502 - Grupo Hix" class="tm-product-name"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>
                </asp:Panel>
              <!-- table container -->
              <div class="tm-product-table-container">
                <asp:DropDownList ID="dd_destinatario" runat="server" class="custom-select tm-select-accounts">
                    <asp:ListItem Text ="ALUNO" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="VISITANTE" class="tm-product-name"></asp:ListItem>
                </asp:DropDownList>
            </div>
              <h5 style="color:white;" class="col-auto"> Data Inicial</h5>
                  <div class="tm-product-table-container">
                      <asp:TextBox ID="txt_data_inicial" runat="server" TextMode="Date" class="form-control validate"></asp:TextBox>
                  </div>
              <h5 style="color:white" class="col-auto"> Data Final</h5>
                <div class="tm-product-table-container">
                  <asp:TextBox ID="txt_data_final" runat="server" TextMode="Date" class="form-control validate"></asp:TextBox>
                </div>
              <asp:Button ID="btn_testar" class="btn btn-primary btn-block text-uppercase mb-3" runat="server" Text="Adicionar Filtro" visible="false"/>
          </div>
        </div>
      </div>
    </div>
    
</asp:Content>
