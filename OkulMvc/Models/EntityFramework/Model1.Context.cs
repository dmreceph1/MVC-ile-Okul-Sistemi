﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OkulMvc.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbMvcOkulEntities : DbContext
    {
        public DbMvcOkulEntities()
            : base("name=DbMvcOkulEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBLDERSLER> TBLDERSLERs { get; set; }
        public virtual DbSet<TBLKULUPLER> TBLKULUPLERs { get; set; }
        public virtual DbSet<TBLNOTLAR> TBLNOTLARs { get; set; }
        public virtual DbSet<TBLOGRENCILER> TBLOGRENCILERs { get; set; }
    }
}
