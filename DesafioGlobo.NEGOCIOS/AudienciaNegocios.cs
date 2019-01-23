using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioGlobo.DAO;
using DesafioGlobo.DOMINIO;

namespace DesafioGlobo.NEGOCIOS
{
    public class AudienciaNegocios
    {
        public AudienciaModel Excluir(AudienciaModel oModel)
        {
            AudienciaDAO oDAO = new AudienciaDAO();
            return oDAO.Excluir(oModel);
        }

        public AudienciaModel Salvar(AudienciaModel oModel)
        {
            AudienciaDAO oDAO = new AudienciaDAO();

            if (oModel.Id.HasValue)
            {
                return oDAO.Alterar(oModel);
            }
            else
            {
                return oDAO.Incluir(oModel);
            }
        }


        public List<AudienciaModel> Listar(AudienciaModel oModel)
        {
            AudienciaDAO oDAO = new AudienciaDAO();
            return oDAO.Listar(oModel);
        }
    }
}
