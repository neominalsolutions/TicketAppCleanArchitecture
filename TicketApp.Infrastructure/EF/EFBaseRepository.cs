using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Domain.Repositories;
using TicketApp.Domain.SeedWork;
namespace TicketApp.Infrastructure.EF
{
  // Respository sınıfları EFBaseRepository kalıtım alıp ortak create update delete işlemlerini base sınıf üzerinden yapıp, kendileri ile alakalı bir db işlemi varsa kendi repository içerisinde bunu tanımlayacak.
  // Protected variants, polymorphism GRASP ait patternleri kullanıyorum.

  public abstract class EFBaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : Entity 
    where TContext:DbContext
  {

    // TContext EFBaseContext direkt olarak bağlamadık, Dependency Inversion yaparak farklı dbContext instanceları ilede çalışabilmesini sağladık
    protected TContext db;
    protected DbSet<TEntity> table; // db deki table instance

    public EFBaseRepository(TContext db)
    {
      this.db = db;
      this.table = db.Set<TEntity>(); // gönderilen nesne üzerinden db instance vericek.
    }
   

    public virtual List<TEntity> FindAll()
    {
      return this.table.ToList();
    }

    public virtual TEntity FindById(string key)
    {
      return this.table.Find(key);
    }

    public virtual void Create(TEntity entity)
    {
      this.table.Add(entity);
      this.db.SaveChanges();
    }

    public virtual void Delete(string key)
    {
     var entity = this.table.Find(key); // attached

      this.table.Remove(entity);
      this.db.SaveChanges();
    }

    public virtual void Update(TEntity entity)
    {
      this.table.Update(entity);
      this.db.SaveChanges();
    }


  }
}
