using Core.Entities;
using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL
{
    public class UnitOfWork: IDisposable
    {
        private RHDbContext _context;
        private GenericRepository<Persona> personaRepository;
        //private CourseRepository courseRepository;

        public UnitOfWork(RHDbContext context)
        {
            _context = context;
        }
        public GenericRepository<Persona> PersonaRepository
        {
            get
            {

                if (this.personaRepository == null)
                {
                    this.personaRepository = new GenericRepository<Persona>(_context);
                }
                return personaRepository;
            }
        }

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

