﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAlpha.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlphaEntities : DbContext
    {
        public AlphaEntities()
            : base("name=AlphaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<provider> providers { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<view_show_products> view_show_products { get; set; }
        public virtual DbSet<view_show_providers> view_show_providers { get; set; }
    }
}
