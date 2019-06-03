<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SmsPge.aspx.cs" Inherits="Dispatch.Views.Marketing.SmsPge" %>
<asp:Content ID="ctt_sms" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-5">
    <h2 class="tm-block-title">Lista de Envio</h2>
    <div class="row tm-content-row">
        <div class="col-12 tm-block-col">
            <div class="tm-bg-primary-dark tm-block tm-block-taller tm-block-scroll">
                <asp:UpdatePanel>
                    <ContentTemplate>
                        <asp:Timer ID="tmr_carga" Enabled ="true" Interval="15000" runat="server"></asp:Timer>
                        <asp:Table ID="tbl_control" runat="server" class="table">
                            <asp:TableHeaderRow CssClass="bg-dark">
                                <asp:TableCell Text ="ALUNO"></asp:TableCell>
                                <asp:TableCell Text ="TELEFONE"></asp:TableCell>
                                <asp:TableCell Text ="CAMPANHA"></asp:TableCell>
                                <asp:TableCell Text ="STATUS"></asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    <asp:Label ID="lbl_erro" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>

</asp:Content>
