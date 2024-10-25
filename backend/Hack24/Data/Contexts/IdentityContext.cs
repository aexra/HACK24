﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Web.Data.Models;

namespace Web.Data.Contexts;

public class IdentityContext : IdentityDbContext<User>
{
    public string DbPath { get; }

    public IdentityContext()
    {
        DbPath = "Data/Databases/Identity.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234");
}