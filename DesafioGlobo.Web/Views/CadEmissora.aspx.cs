using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using DesafioGlobo.DOMINIO;
using DesafioGlobo.NEGOCIOS;
using System.Text.RegularExpressions;

namespace DesafioGlobo.Web.Views
{
    public partial class CadEmissoras : System.Web.UI.Page
    {
        private List<EmissoraModel> oList = new List<EmissoraModel>();

        protected void Page_Load(object sender, EventArgs e)
        {

            CarregaGrid();

            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["Cod"] != null)
                    {
                        int id;
                        if (int.TryParse(Request.QueryString["Cod"].ToString(), out id))
                        {
                            DetalharObj(id);
                        }
                        else
                        {
                            Response.Redirect("CadEmissora.aspx");
                        }

                    }
                    else { } //Novo
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'Ocorreu um erro inesperado! Mensagem = " + new JavaScriptSerializer().Serialize(ex.Message.ToString()) + "');", true);
                }
            }
        }

        private void DetalharObj(int Id)
        {

            EmissoraModel oModel = new EmissoraModel();
            List<EmissoraModel> oListModel = new List<EmissoraModel>();
            EmissoraNegocios oNegocios = new EmissoraNegocios();

            oModel.Id = Id;
            oListModel = oNegocios.Listar(oModel);
            if (oListModel.Count > 0)
            {
                oModel = oListModel[0];

                Emissora_Id.Value = oModel.Id.ToString();
                txtNome.Text = oModel.Nome;
            }
        }


        private bool ValidarCampos()
        {
            Boolean Valido = true;
            String MSG_ERROR = String.Empty;
            String index = @"[\|!#$%&/()=?»«@£§€{}.-;'<>_,]";
            Regex reg = new Regex(index);

            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MSG_ERROR += "- Nome da Emissora. <br />";
            }

            if (reg.Match(txtNome.Text.Trim()).Success)
            {
                MSG_ERROR += " - Nome da Emissora - Carácteres especiais não são permitidos. <br />";
            }

            foreach(var item in oList)
            {
                if(item.Nome.Trim() == txtNome.Text.Trim())
                {
                    MSG_ERROR += " - Nome da Emissora - Não é permitido cadastrar a mesma emissora. <br />";
                }
            }

            if (MSG_ERROR.Length > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CamposObrigatorios", "$(document).MensagemModal(3,'<strong>Informações obrigatórias:</strong><br/>" + MSG_ERROR + "');", true);
                Valido = false;
            }

            return Valido;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    EmissoraModel oModel = new EmissoraModel();
                    EmissoraNegocios oNegocios = new EmissoraNegocios();

                    if (!string.IsNullOrEmpty(Emissora_Id.Value))
                        oModel.Id = UTIL.UTIL.Parse<int>(Emissora_Id.Value);

                    oModel.Nome = UTIL.UTIL.Parse<string>(txtNome.Text);

                    oModel = oNegocios.Salvar(oModel);

                    Emissora_Id.Value = oModel.Id.ToString();
                    CarregaGrid();
                    txtNome.Text = string.Empty;

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SUCESSbtnSalvar_Click", "$(document).MensagemModal(1,'Registro salvo com <strong>sucesso</strong>!');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'Ocorreu um erro inesperado! Mensagem = " + new JavaScriptSerializer().Serialize(ex.Message.ToString()) + "');", true);
            }
        }


        private void ListarEmissora(int Id)
        {

            EmissoraModel oModel = new EmissoraModel();
            List<EmissoraModel> oListModel = new List<EmissoraModel>();
            EmissoraNegocios oNegocios = new EmissoraNegocios();

            oModel.Id = Id;
            oListModel = oNegocios.Listar(oModel);
            if (oListModel.Count > 0)
            {
                Rpt.DataSource = oListModel;
                Rpt.DataBind();
            }
            else
            {
                Rpt.DataSource = new List<EmissoraModel>();
                Rpt.DataBind();
            }
        }


        protected void Rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Remover")
                {
                    int? Id = UTIL.UTIL.Parse<int?>(((HiddenField)e.Item.FindControl("Emissora_Id")).Value);

                    if (Id != null)
                    {
                        new EmissoraNegocios().Excluir(new EmissoraModel { Id = Id });
                        txtNome.Text = string.Empty;
                    }
                }
                else if(e.CommandName == "Editar")
                {
                    int? Id = UTIL.UTIL.Parse<int?>(((HiddenField)e.Item.FindControl("Emissora_Id")).Value);
                    String Nome = UTIL.UTIL.Parse<String>(((HiddenField)e.Item.FindControl("Emissora_Nome")).Value);

                    if (Id != null)
                    {
                        new EmissoraNegocios().Salvar(new EmissoraModel { Id = Id , Nome = Nome });
                        Emissora_Id.Value = Id.ToString();
                        txtNome.Text = Nome;                        
                    }
                }

                CarregaGrid();
            }
            catch (Exception ex)
            {
                string msg = "Ocorreu um erro ao remover a emissora.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'" + msg + "');", true);
            }
        }


        protected void CarregaGrid()
        {
            try
            {
                EmissoraNegocios oNegocios = new EmissoraNegocios();

                oList = oNegocios.Listar(new EmissoraModel());

                if (oList.Count > 0)
                {
                    Rpt.DataSource = oList;
                    Rpt.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EROOR", "$(document).MensagemModal(3,'Ocorreu um erro inesperado! Mensagem = " + new JavaScriptSerializer().Serialize(ex.Message.ToString()) + "');", true);
            }
        }


    }
}