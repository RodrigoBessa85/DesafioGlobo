<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadAudiencia.aspx.cs" Inherits="DesafioGlobo.Web.Views.CadAudiencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cadastro de Audiências
                </h1>

            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel runat="server" ID="PanelAviso">
                    <ContentTemplate>
                        <div runat="server" id="AvisoPage" visible="false" class="">
                        </div>
                        <asp:HiddenField runat="server" ID="Audiencia_Id" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSalvar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-3">
                <div class="form-group">
                    <label>Pontos Audiência</label>
                    <asp:TextBox runat="server" ID="txtPontosAudiencia" CssClass="form-control" placeholder="Digite o Ponto da Audiência"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-3">
                <div class="form-group">
                    <label>Data e Hora da Audiência</label>
                    <asp:TextBox runat="server" ID="txtDataHoraAudiencia" CssClass="form-control" placeholder="Digite a Data e a Hora da Audiência"></asp:TextBox>
                </div>
            </div>            

            <div class="col-lg-4">
                <label>Emissora da Audiência</label>
                <div class="form-inline">
                    <asp:DropDownList ID="ddlEmissora_Audiencia" runat="server" DataTextField="Nome" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                    <asp:Button runat="server" ID="btnSalvar" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button>
                </div>
            </div>
        </div>

        <br />
        <br />

        <h4>Lista de Emissoras:</h4>
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
                                        <th>Pontos de Audiência</th>
                                        <th>Data/Hora da Audiência</th>
                                        <th>Emissora da Audiência</th>
                                        <th>Editar</th>
                                        <th>Excluir</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Rpt" runat="server" OnItemCommand="Rpt_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Id") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Pontos_audiencia") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Data_hora_audiencia",  "{0:dd/MM/yyyy hh:mm:ss tt}") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Emissora_audiencia_Nome") %></td>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="Audiencia_Id" Value='<%#DataBinder.Eval(Container.DataItem, "Id") %>' />
                                                    <asp:HiddenField runat="server" ID="Pontos_audiencia" Value='<%#DataBinder.Eval(Container.DataItem, "Pontos_audiencia") %>' />
                                                    <asp:HiddenField runat="server" ID="Data_hora_audiencia" Value='<%#DataBinder.Eval(Container.DataItem, "Data_hora_audiencia") %>' />
                                                    <asp:HiddenField runat="server" ID="Emissora_audiencia" Value='<%#DataBinder.Eval(Container.DataItem, "Emissora_audiencia") %>' />
                                                    <asp:HiddenField runat="server" ID="Emissora_audiencia_Nome" Value='<%#DataBinder.Eval(Container.DataItem, "Emissora_audiencia_Nome") %>' />
                                                    <asp:LinkButton runat="server" ID="LinkButton1" Text="<i class='fa fa-pencil' style='font-size: 30px;'></i>" ToolTip="Editar Item" CommandName="Editar" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#DataBinder.Eval(Container.DataItem, "Id") %>' />
                                                    <asp:LinkButton runat="server" ID="LinkButton2" Text="<i class='fa fa-trash-o fa-2x'></i>" ToolTip="Remover Item" CommandName="Remover"
                                                        OnClientClick="return confirm('Tem certeza que deseja <p>Remover</p> este item?');" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSalvar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
</asp:Content>
