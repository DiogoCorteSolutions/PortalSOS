
using PortalSOS.Dommain;
using PortalSOS.Infra.Models;
using PortalSOS.Infra.Models.Mapping;
using PortalSOS.Infra.Models.Mappingg;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Infra.Contexto
{
    public partial class DB_Contetxt : DbContext
    {
        static DB_Contetxt()
        {
            Database.SetInitializer<DB_Contetxt>(null);
        }

        public DB_Contetxt()
            : base("Name=DefaultConnection")
        {
        }

        public DbSet<sosportalcliente_Dommain> sosportalclientes { get; set; }
        public DbSet<sosportalconfiguracao_Dommain> sosportalconfiguracaos { get; set; }
        public DbSet<sosportalconfiguracaocliente_Dommain> sosportalconfiguracaoclientes { get; set; }
        //public DbSet<sosportalconfiguracaopessoa_T> sosportalconfiguracaopessoa_T { get; set; }
        public DbSet<sosportalcontasapagar_Dommain> sosportalcontasapagars { get; set; }
        public DbSet<sosportalcontasareceber_Dommain> sosportalcontasarecebers { get; set; }
        public DbSet<sosportalcontato_Dommain> sosportalcontatoes { get; set; }
        public DbSet<sosportalendereco_Dommain> sosportalenderecoes { get; set; }
        //public DbSet<sosportalloja_T> sosportalloja_T { get; set; }
        public DbSet<sosportalmovimentacao_Dommain> sosportalmovimentacaos { get; set; }
        public DbSet<sosportaloperacao_Dommain> sosportaloperacaos { get; set; }
        public DbSet<sosportalperfil_Dommain> sosportalperfils { get; set; }
        //public DbSet<sosportalpessoa_T> sosportalpessoa_T { get; set; }
        public DbSet<sosportalproduto_Dommain> sosportalprodutoes { get; set; }
        public DbSet<sosportaltipooperacao_Dommain> sosportaltipooperacaos { get; set; }
        public DbSet<sosportaluf_Dommain> sosportalufs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new sosportalclienteMap());
            modelBuilder.Configurations.Add(new sosportalconfiguracaoMap());
            modelBuilder.Configurations.Add(new sosportalconfiguracaoclienteMap());
            //modelBuilder.Configurations.Add(new sosportalconfiguracaopessoa_TMap());
            modelBuilder.Configurations.Add(new sosportalcontasapagarMap());
            modelBuilder.Configurations.Add(new sosportalcontasareceberMap());
            modelBuilder.Configurations.Add(new sosportalcontatoMap());
            modelBuilder.Configurations.Add(new sosportalenderecoMap());
            //modelBuilder.Configurations.Add(new sosportalloja_TMap());
            modelBuilder.Configurations.Add(new sosportalmovimentacaoMap());
            modelBuilder.Configurations.Add(new sosportaloperacaoMap());
            modelBuilder.Configurations.Add(new sosportalperfilMap());
            //modelBuilder.Configurations.Add(new sosportalpessoa_TMap());
            modelBuilder.Configurations.Add(new sosportalprodutoMap());
            modelBuilder.Configurations.Add(new sosportaltipooperacaoMap());
            modelBuilder.Configurations.Add(new sosportalufMap());

        }
    }
}
