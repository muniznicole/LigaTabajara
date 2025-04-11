using System;
using System.Collections.Generic;
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
        Goleiro,
        Zagueiro,
        Volante,
        Meia,
        Atacante
    }

    public enum PePreferido
    {
        Esquerdo,
        Direito,
        Ambidestro
    }
}