﻿using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContextClass context) : base(context)
        {
        }
        public override async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _dbContext.Set<Transaction>()
                .Include(s => s.Order)
                .ToListAsync();
        }
    }
}
