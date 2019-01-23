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
    public partial class CadRelatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txData.Text = DateTime.Now.ToString("yyyy-MM-dd");            

            }

        }

        protected void Rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string msg = "Ocorreu um erro ao remover a emissora.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(3,'" + msg + "');", true);
            }
        }

        protected void btnVisao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txData.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ERROR", "$(document).MensagemModal(2,'Selecione a data!');", true);
            }
            else
            {
                RelatorioAudienciaNegocios oNegocios = new RelatorioAudienciaNegocios();
                List<RelatorioAudienciaModel> oListModel = new List<RelatorioAudienciaModel>();
                RelatorioAudienciaModel oModel = new RelatorioAudienciaModel();

                oModel.Data = UTIL.UTIL.Parse<DateTime>(txData.Text);
                oModel.Visao = UTIL.UTIL.Parse<string>(ddlVisao.SelectedValue);


                oListModel = oNegocios.Listar(oModel);
                if (oListModel.Count > 0)
                {
                    Rpt.DataSource = oListModel;
                    Rpt.DataBind();
                }
                else
                {
                    Rpt.DataSource = new List<RelatorioAudienciaModel>();
                    Rpt.DataBind();
                }
            }
        }


    }
}