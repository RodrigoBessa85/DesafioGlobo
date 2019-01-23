using DesafioGlobo.DAO;
using DesafioGlobo.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.NEGOCIOS
{
    public class EmissoraNegocios
    {


        public EmissoraModel Excluir(EmissoraModel oModel)
        {
            EmissoraDAO oDAO = new EmissoraDAO();
            return oDAO.Excluir(oModel);
        }

        public EmissoraModel Salvar(EmissoraModel oModel)
        {
            EmissoraDAO oDAO = new EmissoraDAO();

            if (oModel.Id.HasValue)
            {
                return oDAO.Alterar(oModel);
            }
            else
            {
                return oDAO.Incluir(oModel);
            }
        }

        public List<EmissoraModel> Listar(EmissoraModel oModel)
        {
            EmissoraDAO oDAO = new EmissoraDAO();
            return oDAO.Listar(oModel);
        }
    }
}
