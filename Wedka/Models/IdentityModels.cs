using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Wedka.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Konto założone")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime zalozenie { get; set; }
        [Display(Name = "Opis")]
        [AllowHtml]
        public string opis { get; set; }
        public string nazwaUzytkownika { get; set; }

        [Display(Name = "Cytat")]
        public string Cytat { get; set; }
        public string zdjecieProfilowe { get; set; }

        public string lokacja { get; set; }
        public string lokacja2 { get; set; }
        [Display(Name = "Ostatnio Zalogowany")]
        public DateTime ostatnieLogowanie { get; set; }
        public double szerokosc { get; set; }
        public double dlugosc { get; set; }
        public string admin { get; set; }
        public int punkty { get; set; }
        public virtual ICollection<PostModel> PostModel { get; set; }
        public virtual ICollection<KomentarzModel> KomentarzModel { get; set; }
        public virtual ICollection<MapaModel> MapaModel { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<ArtykolModel> Artykol { get; set; }
        public DbSet<KomentarzModel> Komentarz { get; set; }
        public DbSet<PostModel> Post { get; set; }

        public System.Data.Entity.DbSet<Wedka.Models.MapaModel> MapaModels { get; set; }
    }
}