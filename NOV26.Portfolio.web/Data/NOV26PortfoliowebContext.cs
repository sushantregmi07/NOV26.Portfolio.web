using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOV26.Portfolio.web.Models;

namespace NOV26.Portfolio.web.Data
{
    public class NOV26PortfoliowebContext : DbContext
    {
        public NOV26PortfoliowebContext (DbContextOptions<NOV26PortfoliowebContext> options)
            : base(options)
        {
        }

        public DbSet<NOV26.Portfolio.web.Models.PersonalInformationModel> PersonalInformationModel { get; set; } = default!;
        public DbSet<NOV26.Portfolio.web.Models.ResumeModel> ResumeModel { get; set; } = default!;
        public DbSet<NOV26.Portfolio.web.Models.ServiceModel> ServiceModel { get; set; } = default!;
        public DbSet<NOV26.Portfolio.web.Models.SkillModel> SkillModel { get; set; } = default!;
        public DbSet<NOV26.Portfolio.web.Models.ProjectModel> ProjectModel { get; set; } = default!;
        public DbSet<NOV26.Portfolio.web.Models.BlogModel> BlogModel { get; set; } = default!;
    }
}
