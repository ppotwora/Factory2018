﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fabryka2018
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelDataContainer : DbContext
    {
        public ModelDataContainer()
            : base("name=ModelDataContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hala> Halas { get; set; }
        public virtual DbSet<Maszyna> Maszynas { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
    }
}
