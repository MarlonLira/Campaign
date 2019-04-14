<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailPge.aspx.cs" 
    Inherits="Dispatch.Views.Marketing.EmailPge" %>
<asp:Content ID="cttEmail" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container mt-5">
        
      <div class="row tm-content-row">
         
        <div class="col-sm-12 col-md-12 col-lg-8 col-xl-8 tm-block-col">
             
          <div class="tm-bg-primary-dark tm-block tm-block-products">
              <h2 class="tm-block-title"> Tabela De Busca</h2>
            <div class="tm-product-table-container">
                
              <table class="table table-hover tm-table-small tm-product-table">
                <!--thead>
                  <tr>
                    
                    <th scope="col">ALUNO</th>
                    <th scope="col">EMAIL</th>
                    <th scope="col">TELEFONE</th>
                    <th scope="col">DATA</th>
                    
                  </tr>
                </thead-->
                <tbody>
                  <tr><!--
                    <th scope="row"><input type="checkbox" /></th>
                    <td class="tm-product-name">Marlon Lira</td>
                    <td>marlonlira3@gmail.com</td>
                    <td>984910952</td>
                    <td>11/04/2019</td>
                    <td>
                      <a href="#" class="tm-product-delete-link">
                        <i class="far fa-trash-alt tm-product-delete-icon"></i>
                      </a>
                    </td> -->
                      <asp:Table ID="tbl_control" runat="server" class="table table-hover tm-table-small tm-product-table">
                          <asp:TableHeaderRow  CssClass="bg-dark">
                                <asp:TableCell Text ="ALUNO"></asp:TableCell>
                                <asp:TableCell Text ="EMAIL"></asp:TableCell>
                                <asp:TableCell Text ="TELEFONE"></asp:TableCell>
                                <asp:TableCell Text ="DATA"></asp:TableCell>
                           </asp:TableHeaderRow>
                      </asp:Table>
                  </tr>
                </tbody>
              </table>
                

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
              <table class="table tm-table-small tm-product-table">
                <tbody>
                  <tr>
                    <td class="tm-product-name"> Aluno</td>
                    <td class="text-center">
                      <a href="#" class="tm-product-delete-link">
                        <i class="far fa-trash-alt tm-product-delete-icon"></i>
                      </a>
                    </td>
                  </tr>
                  <tr>
                    <td class="tm-product-name"> Visitante</td>
                    <td class="text-center">
                      <a href="#" class="tm-product-delete-link">
                        <i class="far fa-trash-alt tm-product-delete-icon"></i>
                      </a>
                    </td>
                  </tr>
                  <tr>
                    <td class="tm-product-name"> Leads</td>
                    <td class="text-center">
                      <a href="#" class="tm-product-delete-link">
                        <i class="far fa-trash-alt tm-product-delete-icon"></i>
                      </a>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
            <!-- table container -->
            <button class="btn btn-primary btn-block text-uppercase mb-3">
              Add new category
            </button>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
