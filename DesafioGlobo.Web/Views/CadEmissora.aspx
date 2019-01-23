<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadEmissora.aspx.cs" Inherits="DesafioGlobo.Web.Views.CadEmissoras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cadastro de Emissoras
                </h1>

            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <asp:UpdatePanel runat="server" ID="PanelAviso">
                    <ContentTemplate>
                        <div runat="server" id="AvisoPage" visible="false" class="">
                        </div>
                        <asp:HiddenField runat="server" ID="Emissora_Id" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSalvar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-6">
                <label>Nome da Emissora</label>
                <div class="form-inline ">
                    <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" placeholder="Digite o Nome da Emissora"></asp:TextBox>
                    <asp:Button runat="server" ID="btnSalvar" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click"></asp:Button>
                </div>
            </div>
        </div>

        <br/>
        <br/>

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
                                        <th>Nome da Emissora</th>
                                        <th>Editar</th>
                                        <th>Excluir</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Rpt" runat="server" OnItemCommand="Rpt_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Id") %></td>
                                                <td><%#DataBinder.Eval(Container.DataItem, "Nome") %></td>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="Emissora_Id" Value='<%#DataBinder.Eval(Container.DataItem, "Id") %>' />
                                                    <asp:HiddenField runat="server" ID="Emissora_Nome" Value='<%#DataBinder.Eval(Container.DataItem, "Nome") %>' />
                                                    <asp:LinkButton runat="server" ID="LinkButton1" Text="<i class='fa fa-pencil' style='font-size: 30px;'></i>" ToolTip="Editar Item" CommandName="Editar" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#DataBinder.Eval(Container.DataItem, "Id") %>' />
                                                    <asp:LinkButton runat="server" ID="LinkButton2" Text="<i class='fa fa-trash-o fa-2x'></i>" ToolTip="Remover Item" CommandName="Remover"
                                                        OnClientClick="return confirm('Tem certeza que deseja Remover este item?');" />
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
