using DesafioGlobo.DOMINIO;
using DesafioGlobo.NEGOCIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioGlobo.Web.Views
{
    public partial class CadAudiencias : System.Web.UI.Page
    {
        private List<AudienciaModel> oList = new List<AudienciaModel>();

        protected void Page_Load(object sender, EventArgs e)
        {

            txtDataHoraAudiencia.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm");
            CarregaComboEmissoras();
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
                            Response.Redirect("CadAudiencia.aspx");
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

            AudienciaModel oModel = new AudienciaModel();
            List<AudienciaModel> oListModel = new List<AudienciaModel>();
            AudienciaNegocios oNegocios = new AudienciaNegocios();

            oModel.Id = Id;
            oListModel = oNegocios.Listar(oModel);
            if (oListModel.Count > 0)
            {
                oModel = oListModel[0];

                Audiencia_Id.Value = oModel.Id.ToString();

                txtPontosAudiencia.Text = oModel.Pontos_audiencia.ToString().Trim();
                txtDataHoraAudiencia.Text = oModel.Data_hora_audiencia.ToString().Trim();
                ddlEmissora_Audiencia.SelectedValue = oModel.Emissora_audiencia.ToString();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    AudienciaModel oModel = new AudienciaModel();
                    AudienciaNegocios oNegocios = new AudienciaNegocios();

                    if (!string.IsNullOrEmpty(Audiencia_Id.Value))
                        oModel.Id = UTIL.UTIL.Parse<int>(Audiencia_Id.Value);

                    if (!string.IsNullOrEmpty(txtPontosAudiencia.Text))
                        oModel.Pontos_audiencia = UTIL.UTIL.Parse<double>(txtPontosAudiencia.Text);

                    if (!string.IsNullOrEmpty(txtDataHoraAudiencia.Text))
                        oModel.Data_hora_audiencia = UTIL.UTIL.Parse<DateTime>(txtDataHoraAudiencia.Text);

                    oModel.Emissora_audiencia = int.Parse(ddlEmissora_Audiencia.SelectedValue);

                    oModel = oNegocios.Salvar(oModel);

                    Audiencia_Id.Value = oModel.Id.ToString();
                    CarregaGrid();
                    LimpaCampos();
                    
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "SUCESSbtnSalvar_Click", "$(document).MensagemModal(1,'Registro salvo com <strong>sucesso</strong>!');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'Ocorreu um erro inesperado! Mensagem = " + new JavaScriptSerializer().Serialize(ex.Message.ToString()) + "');", true);
            }
        }

        private bool ValidarCampos()
        {
            Boolean Valido = true;
            String MSG_ERROR = String.Empty;


            if (string.IsNullOrEmpty(txtPontosAudiencia.Text.Trim()))
            {
                MSG_ERROR += "- Pontos de Audiência. <br />";
            }

            if (string.IsNullOrEmpty(txtDataHoraAudiencia.Text.Trim()))
            {
                MSG_ERROR += " - Data e Hora da Audiência. <br />";
            }

            foreach (var item in oList)
            {
                if ((item.Emissora_audiencia_Nome == ddlEmissora_Audiencia.SelectedItem.Text) || (item.Data_hora_audiencia == UTIL.UTIL.Parse<DateTime>((txtDataHoraAudiencia.Text))))
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

        protected void Rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Remover")
                {
                    int? Id = UTIL.UTIL.Parse<int?>(((HiddenField)e.Item.FindControl("Audiencia_Id")).Value);

                    if (Id != null)
                    {
                        new AudienciaNegocios().Excluir(new AudienciaModel { Id = Id });
                        LimpaCampos();
                    }
                }
                else if (e.CommandName == "Editar")
                {
                    int? Id = UTIL.UTIL.Parse<int?>(((HiddenField)e.Item.FindControl("Audiencia_Id")).Value);
                    Double? Pontos_audiencia = UTIL.UTIL.Parse<double>(((HiddenField)e.Item.FindControl("Pontos_audiencia")).Value);
                    DateTime Data_hora_audiencia = UTIL.UTIL.Parse<DateTime>(((HiddenField)e.Item.FindControl("Data_hora_audiencia")).Value);
                    int? Emissora_audiencia = UTIL.UTIL.Parse<int>(((HiddenField)e.Item.FindControl("Emissora_audiencia")).Value);
                    String Emissora_audiencia_Nome = UTIL.UTIL.Parse<String>(((HiddenField)e.Item.FindControl("Emissora_audiencia_Nome")).Value);

                    if (Id != null)
                    {
                        new AudienciaNegocios().Salvar(new AudienciaModel { Id = Id, Pontos_audiencia = Pontos_audiencia, Data_hora_audiencia = Data_hora_audiencia, Emissora_audiencia = Emissora_audiencia, Emissora_audiencia_Nome = Emissora_audiencia_Nome });
                        Audiencia_Id.Value = Id.ToString();
                        txtPontosAudiencia.Text = Pontos_audiencia.ToString();
                        txtDataHoraAudiencia.Text = Data_hora_audiencia.ToString();
                        ddlEmissora_Audiencia.SelectedItem.Text = Emissora_audiencia_Nome;
                    }
                }

                CarregaGrid();
            }
            catch (Exception ex)
            {
                string msg = "Ocorreu um erro ao remover a audiência!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'" + msg + "');", true);
            }
        }

        private void ListarAudiencia(int Id)
        {

            AudienciaModel oModel = new AudienciaModel();
            List<AudienciaModel> oListModel = new List<AudienciaModel>();
            AudienciaNegocios oNegocios = new AudienciaNegocios();

            oModel.Id = Id;
            oListModel = oNegocios.Listar(oModel);
            if (oListModel.Count > 0)
            {
                Rpt.DataSource = oListModel;
                Rpt.DataBind();
            }
            else
            {
                Rpt.DataSource = new List<AudienciaModel>();
                Rpt.DataBind();
            }
        }

        protected void CarregaGrid()
        {
            try
            {
                AudienciaNegocios oNegocios = new AudienciaNegocios();
              
                oList = oNegocios.Listar(new AudienciaModel());

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

        protected void CarregaComboEmissoras()
        {
            try
            {
                EmissoraNegocios oNegocios = new EmissoraNegocios();
                List<EmissoraModel> oAudienciaList = new List<EmissoraModel>();

                oAudienciaList = oNegocios.Listar(new EmissoraModel { });
                oAudienciaList.Insert(0, new EmissoraModel { Id = 0, Nome = "Selecione" });

                ddlEmissora_Audiencia.DataSource = oAudienciaList;
                ddlEmissora_Audiencia.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'Ocorreu um erro inesperado! Mensagem = " + new JavaScriptSerializer().Serialize(ex.Message.ToString()) + "');", true);
            }
        }

        private void LimpaCampos()
        {
            txtPontosAudiencia.Text = string.Empty;
            txtDataHoraAudiencia.Text = string.Empty;
        }
    }
}