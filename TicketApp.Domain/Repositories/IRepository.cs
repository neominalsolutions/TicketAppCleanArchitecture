using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.SeedWork;

namespace TicketApp.Domain.Repositories
{
  public interface IRepository<TEntity>:IReadOnlyRepository<TEntity>,IWriteOnlyRepository<TEntity> where TEntity:Entity
  {
    
  }

  // Interface Seggragation işlemi yaptık
  public interface IReadOnlyRepository<TEntity> where TEntity:Entity
  {
    TEntity FindById(string key);
    List<TEntity> FindAll();
  }

  public interface IWriteOnlyRepository<TEntity> where TEntity:Entity
  {
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(string key);
  }
}
