using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public class BaseRepository<T>
         : IDisposable, IBaseRepository<T> where T : class
    {
        protected FreelancerSpaceContext _context;


        public T get(int id)
        {
            using (_context = new FreelancerSpaceContext())
            {
                return _context.Set<T>().Find(id);
            }
           
        }

        public  List<T> getAll()
        {
            using (_context = new FreelancerSpaceContext())
            {
                return _context.Set<T>().ToList();
            }
            
        }

        public bool add(T item)
        {
            using (_context = new FreelancerSpaceContext())
            {
                try
                {
                    _context.Set<T>().Add(item);
                    _context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public bool delete(T item)
        {
            using (_context = new FreelancerSpaceContext())
            {
                try
                {
                    _context.Entry(item).State = EntityState.Deleted;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool edit(T item)
        {
            using (_context = new FreelancerSpaceContext())
            {
                try
                {
                    _context.Entry(item).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public void Dispose()
        {
            using (_context = new FreelancerSpaceContext())
            {
                _context.Dispose();
            }
           
        }
    }


    
}
