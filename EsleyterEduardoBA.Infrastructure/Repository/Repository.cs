using EsleyterEduardoBA.Domain.Ports.Repository;
using EsleyterEduardoBA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EsleyterEduardoBA.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly SistemaTicketsDbContext _context;

    public Repository(SistemaTicketsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}