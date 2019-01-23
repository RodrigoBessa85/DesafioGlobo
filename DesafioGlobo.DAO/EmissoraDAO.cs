using DesafioGlobo.DOMINIO;
using DesafioGlobo.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.DAO
{
    public class EmissoraDAO
    {
        public EmissoraModel Excluir(EmissoraModel oModel)
        {
            DB banco = new DB();

            SqlParameter[] P = {
                new SqlParameter("@Id", oModel.Id)
            };

            return banco.ExecQueryReturnOne<EmissoraModel>(P, "Emissora_Excluir");
        }

        public EmissoraModel Incluir(EmissoraModel oModel)
        {
            DB banco = new DB();
            SqlParameter[] P = {
                new SqlParameter("@Nome", oModel.Nome)
            };

            return banco.ExecQueryReturnOne<EmissoraModel>(P, "Emissora_Incluir");
        }

        public EmissoraModel Alterar(EmissoraModel oModel)
        {
            DB banco = new DB();
            SqlParameter[] P = {
                new SqlParameter("@Id", oModel.Id),
                new SqlParameter("@Nome", oModel.Nome)
            };

            return banco.ExecQueryReturnOne<EmissoraModel>(P, "Emissora_Alterar");
        }


        public List<EmissoraModel> Listar(EmissoraModel oModel)
        {
            DB banco = new DB();

            SqlParameter[] P = {
                new SqlParameter("@Id", oModel.Id),
                new SqlParameter("@Nome", oModel.Nome)
            };

            return banco.ExecQuery<EmissoraModel>(P, "Emissora_Listar");
        }




    }
}
