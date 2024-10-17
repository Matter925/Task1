using Microsoft.EntityFrameworkCore;
using Task1.Areas.Admin.Services.Interfaces;
using Task1.Data;

namespace Task1.Areas.Admin.Services.Implementation;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _entities.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _entities.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
