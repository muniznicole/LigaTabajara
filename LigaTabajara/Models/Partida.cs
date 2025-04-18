using System;
using System.Collections.Generic;

namespace LigaTabajara.Models
{
    public class Partida
    {
        public int PartidaId { get; set; }

        public int TimeCasaId { get; set; }
        public int TimeForaId { get; set; }

        public DateTime DataHora { get; set; }
        public string Estadio { get; set; }

        public int PlacarTimeCasa { get; set; }
        public int PlacarTimeFora { get; set; }

        public int Rodada { get; set; }

        public virtual Time TimeCasa { get; set; }
        public virtual Time TimeFora { get; set; }

        public virtual ICollection<Gol> Gols { get; set; }
    }
}
