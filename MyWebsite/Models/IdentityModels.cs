using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyWebsite.Domains;

namespace MyWebsite.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Database Domains
        public DbSet<Question> Questions { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<QuestionSectionRelation>
            QuestionSection { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // указываем для 3й таблицы составной ключ
            modelBuilder.Entity<QuestionSectionRelation>()
                .HasKey(o => new {o.QuestId, o.SectionId });
            base.OnModelCreating(modelBuilder);
        }

        #endregion



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}