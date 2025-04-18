using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Treinador")]
        Treinador,

        [Display(Name = "Auxiliar")]
        Auxiliar,

        [Display(Name = "Preparador Físico")]
        PreparadorFisico,

        [Display(Name = "Fisiologista")]
        Fisiologista,

        [Display(Name = "Treinador de Goleiros")]
        TreinadorGoleiros,

        [Display(Name = "Fisioterapeuta")]
        Fisioterapeuta
    }
}