using Core;
using Core.Entities;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DAL;

namespace Infrastructure.DAL
{
    public class UnitOfWork: IDisposable
    {
        private RHDbContext _context;
        //private GenericRepository<Persona> personaRepository;        
       
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(RHDbContext context)
        {
            _context = context;
        }

        public GenericRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            //if (repositories == null)
            //{
            //    repositories = new Dictionary<string, object>();
            //}

            //var type = typeof(TEntity).Name;

            //if (!repositories.ContainsKey(type))
            //{
              //  var repositoryType = typeof(Repository<TEntity>);
            //    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            //    repositories.Add(type, repositoryInstance);
            //}

            //return (Repository<TEntity>)repositories[type];

            IRepository<TEntity> repo = new GenericRepository<TEntity>(_context);
            repositories.Add(typeof(TEntity), repo);
            return repo;            
        }


        //public GenericRepository<TEntity> PersonaRepository
        //{
        //    get 
        //    {

        //        if (this.personaRepository == null)
        //        {
        //            this.personaRepository = new GenericRepository<TEntity>(_context);
        //        }
        //        return personaRepository;
        //    }
        //}

        //public CourseRepository CourseRepository
        //{
        //    get
        //    {

        //        if (this.courseRepository == null)
        //        {
        //            this.courseRepository = new CourseRepository(context);
        //        }
        //        return courseRepository;
        //    }
        //}


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}

