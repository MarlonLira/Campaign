﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WaitingPge.aspx.cs" Inherits="Dispatch.Views.Marketing.WaitingPge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<div class="container mt-5">
    <h2 class="tm-block-title">Lista de Envio</h2>
<div class="row tm-content-row">
    <div class="col-12 tm-block-col">
        <div class="tm-bg-primary-dark tm-block tm-block-taller tm-block-scroll">
            <asp:UpdatePanel>
                <ContentTemplate>
<<<<<<< HEAD
                    <asp:Timer ID="tmr_carga" Enabled ="true" Interval="10000" runat="server"></asp:Timer>
=======
                    <asp:Timer ID="tmr_carga" Enabled ="true" Interval="60000" runat="server"></asp:Timer>
>>>>>>> 756ddc5f8808e4bc844fa87d008ecfebf9ef821b
                    <asp:Table ID="tbl_waiting" runat="server" class="table">
                        <asp:TableHeaderRow  CssClass="bg-dark">
                            <asp:TableCell Text ="ALUNO"></asp:TableCell>
                            <asp:TableCell Text ="EMAIL"></asp:TableCell>
                            <asp:TableCell Text ="TELEFONE"></asp:TableCell>
                            <asp:TableCell Text ="LINK"></asp:TableCell>
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
