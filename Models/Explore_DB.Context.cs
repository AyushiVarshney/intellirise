﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Explore_App.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class iOS_ExploreEntities1 : DbContext
    {
        public iOS_ExploreEntities1()
            : base("name=iOS_ExploreEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<city> cities { get; set; }
        public DbSet<country> countries { get; set; }
        public DbSet<Lst_Asst_Coach> Lst_Asst_Coach { get; set; }
        public DbSet<Reg_Coach> Reg_Coach { get; set; }
        public DbSet<Reg_Player> Reg_Player { get; set; }
        public DbSet<state> states { get; set; }
    }
}