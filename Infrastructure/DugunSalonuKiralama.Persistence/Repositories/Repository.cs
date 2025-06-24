﻿using DugunSalonuKiralama.Application.Interfaces;
using DugunSalonuKiralama.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DugunSalonuKiralama.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WeddingHallContext _weddingHallContext;
        public Repository(WeddingHallContext WeddingHallContext)
        {
            _weddingHallContext = WeddingHallContext;
        }
        public async Task CreateAsync(T entity)
        {
            _weddingHallContext.Set<T>().Add(entity);
            await _weddingHallContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _weddingHallContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _weddingHallContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _weddingHallContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _weddingHallContext.Set<T>().Remove(entity);
            await _weddingHallContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _weddingHallContext.Set<T>().Update(entity);
            await _weddingHallContext.SaveChangesAsync();
        }
    }
}
