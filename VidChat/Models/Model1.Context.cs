﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VidChat.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class videoConEntities1 : DbContext
    {
        public videoConEntities1()
            : base("name=videoConEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<callInfo> callInfoes { get; set; }
        public virtual DbSet<loggedUser> loggedUsers { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}