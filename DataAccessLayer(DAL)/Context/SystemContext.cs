using DataAccessLayer_DAL_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer_DAL_;

public class SystemContext : IdentityDbContext<IdentityUser>
{
    public SystemContext(DbContextOptions<SystemContext> options) :base(options)
    {
        
    }

    #region Models 

    internal DbSet<Employee_Model> Employees => Set<Employee_Model>();
    internal DbSet<Compuny_Model> Compunies => Set<Compuny_Model>();
    internal DbSet<Application_Model> CompuniesApplications => Set<Application_Model>();
    internal DbSet<Question_Model> Questions => Set<Question_Model>();
    internal DbSet<Employee_Post_Model> EmployeesPosts => Set<Employee_Post_Model>();
    internal DbSet<Compuny_Post_Model> CompuniesPosts => Set<Compuny_Post_Model>();
    internal DbSet<Apply_Model> Employees_Applies => Set<Apply_Model>();
    internal DbSet<Offer_Model> Compunies_Offers => Set<Offer_Model>();
    internal DbSet<Employee_Answer_Model> Employees_Answers => Set<Employee_Answer_Model>();
    internal DbSet<Jop_Categories_Model> Jop_Categories => Set<Jop_Categories_Model>();
    internal DbSet<Skill_Model> Jop_Skills => Set<Skill_Model>();
    internal DbSet<Question_Application_Model> Application_Qustions => Set<Question_Application_Model>();
    internal DbSet<Jop_Response> Jop_Responses => Set<Jop_Response>();
    internal DbSet<Employee_Answer_Model> Employee_Answers => Set<Employee_Answer_Model>();


    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {


        #region Configurations Composite Keys 

        // Creating  Composite Key For Answer Employee Table 

        builder.Entity<Employee_Answer_Model>().HasKey(e => new { e.Employee_ID, e.Question_ID });
        
        // Creatiing  Composite Key For Apply Table 

        builder.Entity<Apply_Model>().HasKey(e => new { e.Employee_ID, e.Compuny_Post_ID });
        
        // Creatiing  Composite Key For Answer Employee Table 

        builder.Entity<Offer_Model>().HasKey(e => new { e.Compuny_ID, e.Employee_Post_ID });

        // Creating Composite Key for Application Quetion Model 

        builder.Entity<Question_Application_Model>().HasKey(e=> new {e.Application_ID , e.Question_ID});

        // Creating Composite Key for Application Jop Response Model 

        builder.Entity<Jop_Response>().HasKey(e=> new {e.Employee_ID     , e.Compuny_ID});




        #endregion

        #region Configure Foreign Key  Resolve Cyrcular Referace

        builder.Entity<Compuny_Post_Model>()
            .HasOne(p => p.Compuny)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.Compuny_ID)
            .OnDelete(DeleteBehavior.NoAction);
      


        #endregion



        base.OnModelCreating(builder);
    }

}
