using System;
using System.Data.Entity;
using System.Linq;
using Unisc.Massas.Data.Mapping;
using Unisc.Massas.Domain.Models;

namespace Unisc.Massas.Data.Context
{
    public sealed class MassasContext : DbContext
    {
        private static volatile MassasContext _instance;
        private static readonly object syncLock = new Object();

        static MassasContext()
        {
            Database.SetInitializer<MassasContext>(null);
        }

        public MassasContext() : base("Name=massasContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        /// <summary>
        /// O contexto Singleton do banco de dados.
        /// </summary>
        public static MassasContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance != null)
                        {
                            if (_instance.GetValidationErrors().Any())
                            {
                                _instance = new MassasContext();
                            }
                        }
                        else
                        {
                            _instance = new MassasContext();
                        }
                    }
                }

                return _instance;                
            }
        }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Forma> Formas { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<FuncaoUsuario> FuncoesUsuario { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<PermissaoFuncao> PermissoesFuncoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoMassa> TiposMassas { get; set; }
        public DbSet<UnidadeMedida> UnidadesMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new EncomendaMap());
            modelBuilder.Configurations.Add(new EstoqueMap());
            modelBuilder.Configurations.Add(new FormaMap());
            modelBuilder.Configurations.Add(new FuncaoMap());
            modelBuilder.Configurations.Add(new FuncaoUsuarioMap());
            modelBuilder.Configurations.Add(new LocalMap());
            modelBuilder.Configurations.Add(new MaquinaMap());
            modelBuilder.Configurations.Add(new PermissaoMap());
            modelBuilder.Configurations.Add(new PermissaoFuncaoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new TipoMassaMap());
            modelBuilder.Configurations.Add(new UnidadeMedidaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
