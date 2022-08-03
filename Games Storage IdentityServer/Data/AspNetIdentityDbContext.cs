﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Games_Storage_IdentityServer.Data
{
    public class AspNetIdentityDbContext : IdentityDbContext
    {
        public AspNetIdentityDbContext(DbContextOptions<AspNetIdentityDbContext> options) : base(options)
        {
        }
    }
}
