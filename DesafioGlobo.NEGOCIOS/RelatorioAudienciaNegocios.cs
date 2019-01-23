using DesafioGlobo.DAO;
using DesafioGlobo.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.NEGOCIOS
{
    public class RelatorioAudienciaNegocios
    {
        public List<RelatorioAudienciaModel> Listar(RelatorioAudienciaModel oModel)
        {
            RelatorioAudienciaDAO oDAO = new RelatorioAudienciaDAO();
            return oDAO.Listar(oModel);
        }
    }
}
