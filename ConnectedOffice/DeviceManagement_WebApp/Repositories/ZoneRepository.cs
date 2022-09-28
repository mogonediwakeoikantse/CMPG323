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
    public class ZoneRepository : IZoneRepository
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        //public ZoneRepository(ConnectedOfficeContext context) : base(context)
        //{ }

        public void Add(Zone entity)
        {
            _context.Set<Zone>().Add(entity);
        }

        public void AddRange(IEnumerable<Zone> entities)
        {
            _context.Set<Zone>().AddRange(entities);
        }

        public IEnumerable<Zone> Find(Expression<Func<Zone, bool>> expression)
        {
            return _context.Set<Zone>().Where(expression);
        }

        public IEnumerable<Zone> GetAll()
        {
            //return _context.Set<T>().ToList(); 
            return _context.Zone.ToList();
        }

        public Zone GetById(Guid? id)
        {
            //return _context.Set<T>().Find(id);
            return _context.Zone.Find(id);
        }


        public void Remove(Zone entity)
        {
            _context.Set<Zone>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Zone> entities)
        {
            _context.Set<Zone>().RemoveRange(entities);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Zone entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}