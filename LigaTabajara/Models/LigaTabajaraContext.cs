using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LigaTabajara.Models
{
	public class LigaTabajaraContext : DbContext
	{
        public LigaTabajaraContext() : base("LigaTabajaraContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<ComissaoTecnica> ComissoesTecnicas { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Gol> Gols { get; set; }

    }
}