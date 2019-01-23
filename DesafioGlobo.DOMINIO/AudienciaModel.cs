using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGlobo.DOMINIO
{
    public class AudienciaModel
    {
        public int? Id { get; set; }

        public double? Pontos_audiencia { get; set; }

        public DateTime? Data_hora_audiencia { get; set; }

        public int? Emissora_audiencia { get; set; }

        public String Emissora_audiencia_Nome { get; set; }
    }
}
