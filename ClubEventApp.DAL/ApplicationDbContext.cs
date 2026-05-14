using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClubEventApp.DAL.Entities;

namespace ClubEventApp.DAL
{
    internal class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
