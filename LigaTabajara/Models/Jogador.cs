using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LigaTabajara.Models
{
	public class Jogador
	{
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public PosicaoJogador Posicao { get; set; }
        public int NumeroCamisa { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public PePreferido PePreferido { get; set; }

        public int TimeId { get; set; }
        public virtual Time Time { get; set; }
    }

    public enum PosicaoJogador
    {
        [Display(Name = "Goleiro")]
        Goleiro,

        [Display(Name = "Zagueiro")]
        Zagueiro,

        [Display(Name = "Volante")]
        Volante,

        [Display(Name = "Meia")]
        Meia,

        [Display(Name = "Atacante")]
        Atacante
    }

    public enum PePreferido
    {
        [Display(Name = "Pé Esquerdo")]
        Esquerdo,

        [Display(Name = "Pé Direito")]
        Direito,

        [Display(Name = "Ambidestro")]
        Ambidestro
    }
}