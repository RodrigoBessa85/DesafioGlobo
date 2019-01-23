<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadRelatorio.aspx.cs" Inherits="DesafioGlobo.Web.Views.CadRelatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Consultar Audiência
                </h1>

            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel runat="server" ID="PanelAviso">
                    <ContentTemplate>
                        <div runat="server" id="AvisoPage" visible="false" class="">
                        </div>
                        <asp:HiddenField runat="server" ID="Relatorio_Id" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-2">
                <div class="form-group">
                    <label>Data</label>
                    <asp:TextBox runat="server" ID="txData" CssClass="form-control" Width="100%" TextMode="Date"></asp:TextBox>
                </div>
            </div>


            <div class="col-lg-2">
                <div class="form-inline">
                    <label>Visão da Audiência</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlVisao">
                        <asp:ListItem Text="Soma" Value="Soma"></asp:ListItem>
                        <asp:ListItem Text="Média" Value="Media"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="btnVisao" CssClass="btn btn-primary" Text="<i class='fa fa-search'></i>" OnClick="btnVisao_Click" />
                </div>
            </div>
        </div>

        <br />
        <br />

        <h4>Relatório de Audiência por emissora:</h4>
        <hr />

        <div class="row">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <table class="table table-bordered table-hover table-striped" id="tblList">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Nome da Emissora</th>
                                        <th>Data</th>
                                        <th>Média da Audiência</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Rpt" runat="server" OnItemCommand="Rpt_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Id") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Nome") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Data") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Resultado") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
</asp:Content>
