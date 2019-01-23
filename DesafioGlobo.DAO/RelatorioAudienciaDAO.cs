using DesafioGlobo.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.DAO
{
    public class RelatorioAudienciaDAO
    {
        public List<RelatorioAudienciaModel> Listar(RelatorioAudienciaModel oModel)
        {
            DB banco = new DB();

            SqlParameter[] P = {
                new SqlParameter("@Data", oModel.Data),
                new SqlParameter("@Visao", oModel.Visao)
            };

            return banco.ExecQuery<RelatorioAudienciaModel>(P, "Relatorio_Audiencia");
        }
    }
}
