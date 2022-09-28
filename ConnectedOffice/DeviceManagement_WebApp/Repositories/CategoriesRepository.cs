using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Generic;
using DeviceManagement_WebApp.Interface;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repositories
{
   
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();


        public void Add(Category entity)
        {
            _context.Set<Category>().Add(entity);
        }

        public void AddRange(IEnumerable<Category> entities)
        {
            _context.Set<Category>().AddRange(entities);
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> expression)
        {
            return _context.Set<Category>().Where(expression);
        }

        public IEnumerable<Category> GetAll()
        {
            //return _context.Set<T>().ToList(); 
            return _context.Category.ToList();
        }

       

        public Category GetById(Guid? id)
        {
            //return _context.Set<T>().Find(id);
            return _context.Category.Find(id);
        }
       

        public void Remove(Category entity)
        {
            _context.Set<Category>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _context.Set<Category>().RemoveRange(entities);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }



        private bool Exists(Guid id)
        {
            //return _categoryRepository.Find(id);
            return _context.Category.Any(e => e.CategoryId == id);
        }


    }
}

