using System;

namespace LigaTabajara.Models
{
    public class Gol
    {
        public int GolId { get; set; }

        public int PartidaId { get; set; }
        public int JogadorId { get; set; }
        public int Minuto { get; set; }

        public virtual Partida Partida { get; set; }
        public virtual Jogador Jogador { get; set; }
    }
}
