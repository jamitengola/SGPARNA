using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SGPARNA.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {

        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public int MyProperty { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Tipo_Documento>tipo_Doocumentos { get; set; }
        public DbSet<Processos> Processos { get; set; }
        public DbSet<Documentos_Achados> Documentos_Achados { get; set; }
        public DbSet<Documentos_Perdidos> Documentos_Perdidos { get; set; }
        public DbSet<Estado_Documento> estado_Documentos { get; set; }
        public DbSet<Servicos_de_utildidade> servicos_De_Utildidades { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SGPARNA.Models.Categoria> Categorias { get; set; }
    }
}