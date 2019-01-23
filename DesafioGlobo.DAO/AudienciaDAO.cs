using DesafioGlobo.DOMINIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.DAO
{
    public class AudienciaDAO
    {
        public AudienciaModel Excluir(AudienciaModel oModel)
        {
            DB banco = new DB();

            SqlParameter[] P = {
                new SqlParameter("@Id", oModel.Id)
            };

            return banco.ExecQueryReturnOne<AudienciaModel>(P, "Audiencia_Excluir");
        }

        public AudienciaModel Incluir(AudienciaModel oModel)
        {
            DB banco = new DB();
            SqlParameter[] P = {
                new SqlParameter("@Pontos_audiencia", oModel.Pontos_audiencia),
                new SqlParameter("@Data_hora_audiencia", oModel.Data_hora_audiencia),
                new SqlParameter("@Emissora_audiencia", oModel.Emissora_audiencia)
            };

            return banco.ExecQueryReturnOne<AudienciaModel>(P, "Audiencia_Incluir");
        }

        public AudienciaModel Alterar(AudienciaModel oModel)
        {
            DB banco = new DB();
            SqlParameter[] P = {
                new SqlParameter("@Id", oModel.Id),
                new SqlParameter("@Pontos_audiencia", oModel.Pontos_audiencia),
                new SqlParameter("@Data_hora_audiencia", oModel.Data_hora_audiencia),
                new SqlParameter("@Emissora_audiencia", oModel.Emissora_audiencia)
            };

            return banco.ExecQueryReturnOne<AudienciaModel>(P, "Audiencia_Alterar");
        }


        public List<AudienciaModel> Listar(AudienciaModel oModel)
        {
            DB banco = new DB();

            SqlParameter[] P = {
                new SqlParameter("@Id", oModel.Id),
                new SqlParameter("@Pontos_audiencia", oModel.Pontos_audiencia),
                new SqlParameter("@Data_hora_audiencia", oModel.Data_hora_audiencia),
                new SqlParameter("@Emissora_audiencia", oModel.Emissora_audiencia),
                new SqlParameter("@Emissora_audiencia_Nome", oModel.Emissora_audiencia_Nome),
            };

            return banco.ExecQuery<AudienciaModel>(P, "Audiencia_Listar");
        }






    }
}
