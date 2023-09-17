using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using User.Management.Service.Data_Access_Layer__DAL_.Models;

namespace User.Management.Service.Data_Access_Layer__DAL_.Context
{
    public class UserManagementContext : IdentityDbContext<UserModel>
    {

        public UserManagementContext(DbContextOptions DbOptions) : base(DbOptions)
        { }



        #region Models 

        internal DbSet<Employee_Model> Employees => Set<Employee_Model>();
        internal DbSet<Compuny_Model> Compunies => Set<Compuny_Model>();



        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {


            //builder.Entity<IdentityEmployeeClaim>().ToTable("IdentityEmployeeClaim");
            //builder.Entity<IdentityCompunyClaim>().ToTable("IdentityCompunyClaim");
        
            #region Configurations Composite Keys 

            //// Creating  Composite Key For Answer Employee Table 

            //builder.Entity<Employee_Answer_Model>().HasKey(e => new { e.Employee_ID, e.Question_ID });

            //// Creatiing  Composite Key For Apply Table 

            //builder.Entity<Apply_Model>().HasKey(e => new { e.Employee_ID, e.Compuny_Post_ID });

            //// Creatiing  Composite Key For Answer Employee Table 

            //builder.Entity<Offer_Model>().HasKey(e => new { e.Compuny_ID, e.Employee_Post_ID });

            //// Creating Composite Key for Application Quetion Model 

            //builder.Entity<Question_Application_Model>().HasKey(e => new { e.Application_ID, e.Question_ID });

            //// Creating Composite Key for Application Jop Response Model 

            //builder.Entity<Jop_Response>().HasKey(e => new { e.Employee_ID, e.Compuny_ID });




            //#endregion

            //#region Configure Foreign Key  Resolve Cyrcular Referace

            //builder.Entity<Compuny_Post_Model>()
            //    .HasOne(p => p.Compuny)
            //    .WithMany(c => c.Posts)
            //    .HasForeignKey(p => p.Compuny_ID)
            //    .OnDelete(DeleteBehavior.NoAction);



            #endregion



            base.OnModelCreating(builder);
        }
    }
    }
