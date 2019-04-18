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
                <asp:DropDownList ID="dd_unidades" runat="server" class="table tm-table-small tm-product-table">
                    <asp:ListItem Text ="01 - Hi Tamarineira" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="05 - Hi Espinheiro" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="06 - Hi Bv2" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="10 - Hi Bv3" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="31 - Hi Encruzilhada" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="501 - Grupo Hi" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="08 - Hix Espinheiro" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="09 - Hix Piedade" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="11 - Hix Olinda" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="12 - Hix Setubal" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="13 - Hix Imbiribeira" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="19 - Hix Ipsep" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="24 - Hix Arruda" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="502 - Grupo Hix" class="tm-product-name"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="dd_destinatario" runat="server" class="table tm-table-small tm-product-table">
                    <asp:ListItem Text ="ALUNO" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="VISITANTE" class="tm-product-name"></asp:ListItem>
                    <asp:ListItem Text ="AMBOS" class="tm-product-name"></asp:ListItem>
                </asp:DropDownList>
            </div>
                  <div class="tm-product-table-container">
                      
                      <asp:Label ID="lbl_data_inicio" runat="server" Text="Data Inicial" ></asp:Label>
                      <br />
                      <asp:TextBox ID="txt_data_inicial" runat="server" TextMode="Date"></asp:TextBox>
                  </div>
                <div class="tm-product-table-container">
                  <asp:Label ID="lbl_data_final" runat="server" Text="Data Final"></asp:Label>
                    <br />
                  <asp:TextBox ID="txt_data_final" runat="server" TextMode="Date"></asp:TextBox>
                </div>
            <!-- table container -->
              <asp:Button ID="btn_testar" class="btn btn-primary btn-block text-uppercase mb-3" runat="server" Text="Adicionar Filtro" enabled="false"/>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
