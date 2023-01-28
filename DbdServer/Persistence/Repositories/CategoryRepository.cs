﻿using Core.Contracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class CategoryRepository : GenericRepository<PerkCategory>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ClearTable()
        {
            await _dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {nameof(ApplicationDbContext.Categories)}");
            _dbContext.ChangeTracker.Clear();
            await _dbContext.SaveChangesAsync();
        }
    }
}
