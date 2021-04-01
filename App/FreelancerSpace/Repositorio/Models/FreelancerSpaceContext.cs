using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repositorio.Models
{
    public partial class FreelancerSpaceContext : DbContext
    {
        public FreelancerSpaceContext()
        {
        }

        public FreelancerSpaceContext(DbContextOptions<FreelancerSpaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acesso> Acessos { get; set; }
        public virtual DbSet<AtividadesClass> AtividadesClasses { get; set; }
        public virtual DbSet<AtividadesDiviso> AtividadesDivisoes { get; set; }
        public virtual DbSet<AtividadesGrupo> AtividadesGrupos { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<EnderecosXempresa> EnderecosXempresas { get; set; }
        public virtual DbSet<EnderecosXpessoa> EnderecosXpessoas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<FaqPergunta> FaqPerguntas { get; set; }
        public virtual DbSet<FaqResposta> FaqRespostas { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<GruposAcesso> GruposAcessos { get; set; }
        public virtual DbSet<HorarioAtendimento> HorarioAtendimentos { get; set; }
        public virtual DbSet<HorarioAtendimentoXempresa> HorarioAtendimentoXempresas { get; set; }
        public virtual DbSet<NotaAvaliacao> NotaAvaliacaos { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<PerfilEmpresa> PerfilEmpresas { get; set; }
        public virtual DbSet<PermissaoAcesso> PermissaoAcessos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<ProdutosServico> ProdutosServicos { get; set; }
        public virtual DbSet<ProdutosServicosXempresa> ProdutosServicosXempresas { get; set; }
        public virtual DbSet<TiposEndereco> TiposEnderecos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4QBF915 ; Database=FreelancerSpace; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Acesso>(entity =>
            {
                entity.HasOne(d => d.PermiassaoCadastroNavigation)
                    .WithMany(p => p.AcessoPermiassaoCadastroNavigations)
                    .HasForeignKey(d => d.PermiassaoCadastro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acessos_PermissaoAcesso");

                entity.HasOne(d => d.PermiassaoEstatisticasNavigation)
                    .WithMany(p => p.AcessoPermiassaoEstatisticasNavigations)
                    .HasForeignKey(d => d.PermiassaoEstatisticas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acessos_PermissaoAcesso3");

                entity.HasOne(d => d.PermiassaoFaqEmpresaNavigation)
                    .WithMany(p => p.AcessoPermiassaoFaqEmpresaNavigations)
                    .HasForeignKey(d => d.PermiassaoFaqEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acessos_PermissaoAcesso2");

                entity.HasOne(d => d.PermiassaoPerfilEmpresaNavigation)
                    .WithMany(p => p.AcessoPermiassaoPerfilEmpresaNavigations)
                    .HasForeignKey(d => d.PermiassaoPerfilEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acessos_PermissaoAcesso1");
            });

            modelBuilder.Entity<AtividadesClass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAtividadeGruposNavigation)
                    .WithMany(p => p.AtividadesClasses)
                    .HasForeignKey(d => d.IdAtividadeGrupos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtividadesClasses_AtividadesGrupos");
            });

            modelBuilder.Entity<AtividadesDiviso>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtividadesGrupo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAtividadeDivisaoNavigation)
                    .WithMany(p => p.AtividadesGrupos)
                    .HasForeignKey(d => d.IdAtividadeDivisao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtividadesGrupos_AtividadesDivisoes");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidades_Estados");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Interesses)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Pessoas");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_Usuarios");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Cnae).HasColumnName("CNAE");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ImagemDestaque)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAtividadesDivisaoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdAtividadesDivisao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresas_AtividadesDivisoes");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("CEP")
                    .IsFixedLength(true);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enderecos_Cidades");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enderecos_Estados");

                entity.HasOne(d => d.IdTipoEnderecoNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdTipoEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enderecos_TiposEndereco");
            });

            modelBuilder.Entity<EnderecosXempresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EnderecosXEmpresas");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnderecosXEmpresas_Empresas");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnderecosXEmpresas_Enderecos");
            });

            modelBuilder.Entity<EnderecosXpessoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EnderecosXPessoas");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnderecosXPessoas_Enderecos");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnderecosXPessoas_Pessoas");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estados_Pais");
            });

            modelBuilder.Entity<FaqPergunta>(entity =>
            {
                entity.Property(e => e.Anexo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataHorario).HasColumnType("datetime");

                entity.Property(e => e.Pergunta)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.FaqPergunta)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaqPerguntas_Empresas");
            });

            modelBuilder.Entity<FaqResposta>(entity =>
            {
                entity.Property(e => e.Anexo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataHorario).HasColumnType("datetime");

                entity.Property(e => e.Resposta)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.FaqResposta)
                    .HasForeignKey(d => d.IdPergunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FaqRespostas_FaqPerguntas");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.Property(e => e.DataContratacao).HasColumnType("date");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Empresas");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Pessoas");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionarios_Usuarios");
            });

            modelBuilder.Entity<GruposAcesso>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAcessosNavigation)
                    .WithMany(p => p.GruposAcessos)
                    .HasForeignKey(d => d.IdAcessos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposAcessos_Acessos");
            });

            modelBuilder.Entity<HorarioAtendimento>(entity =>
            {
                entity.ToTable("HorarioAtendimento");

                entity.Property(e => e.DiasAtendimento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioAtendimento1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HorarioAtendimento");
            });

            modelBuilder.Entity<HorarioAtendimentoXempresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HorarioAtendimentoXEmpresas");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HorarioAtendimentoXEmpresas_Empresas");

                entity.HasOne(d => d.IdHorarioAtendimentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHorarioAtendimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HorarioAtendimentoXEmpresas_HorarioAtendimento");
            });

            modelBuilder.Entity<NotaAvaliacao>(entity =>
            {
                entity.ToTable("NotaAvaliacao");

                entity.Property(e => e.DataAvaliacao).HasColumnType("datetime");

                entity.Property(e => e.NotaAvaliacao1)
                    .HasColumnType("decimal(1, 1)")
                    .HasColumnName("NotaAvaliacao");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.NotaAvaliacaos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotaAvaliacao_Empresas");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sigla");
            });

            modelBuilder.Entity<PerfilEmpresa>(entity =>
            {
                entity.ToTable("PerfilEmpresa");

                entity.Property(e => e.Likes).HasColumnType("numeric(9, 0)");

                entity.Property(e => e.Visualizacoes).HasColumnType("numeric(9, 0)");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.PerfilEmpresas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilEmpresa_Empresas");
            });

            modelBuilder.Entity<PermissaoAcesso>(entity =>
            {
                entity.ToTable("PermissaoAcesso");

                entity.Property(e => e.Criar)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Editar)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Excluir)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ler)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdutosServico>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAtividadeClasseNavigation)
                    .WithMany(p => p.ProdutosServicos)
                    .HasForeignKey(d => d.IdAtividadeClasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutosServicos_AtividadesClasses");
            });

            modelBuilder.Entity<ProdutosServicosXempresa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProdutosServicosXEmpresas");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutosServicosXEmpresas_Empresas");

                entity.HasOne(d => d.IdProdutoServicoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProdutoServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdutosServicosXEmpresas_ProdutosServicos");
            });

            modelBuilder.Entity<TiposEndereco>(entity =>
            {
                entity.ToTable("TiposEndereco");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGrupoAcessoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGrupoAcesso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_GruposAcessos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
