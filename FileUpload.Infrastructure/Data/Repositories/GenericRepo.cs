using FileUpload.Application.Abstractions.Repositories;
using FileUpload.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FileUpload.Infrastructure.Data.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly FileDbContext _dbContext;
        public GenericRepo(FileDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GetAll
        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                .ToListAsync();
        }

        //GetById
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>()
                .FindAsync(id);
        }

        //Add
        public virtual async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>()
                .AddAsync(entity);
        }

        //Update
        public virtual void UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        //Delete
        public virtual void DeleteAsync(T entity)
        {
            _dbContext.Set<T>()
                .Remove(entity);
        }

    }
}
