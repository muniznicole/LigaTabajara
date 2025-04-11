using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaTabajara.Models
{
	public class ComissaoTecnica
	{
        public int ComissaoTecnicaId { get; set; }
        public string Nome { get; set; }
        public CargoComissao Cargo { get; set; }
        public DateTime DataNascimento { get; set; }

        public int TimeId { get; set; }
        public virtual Time Time { get; set; }
    }

    public enum CargoComissao
    {
        Treinador,
        Auxiliar,
        PreparadorFisico,
        Fisiologista,
        TreinadorGoleiros,
        Fisioterapeuta
    }
}