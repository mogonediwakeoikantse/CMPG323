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
    //public class DeviceRepository : Controller, IDeviceRepository
    public class DeviceRepository :  IDeviceRepository
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        public void Add(Device entity)
        {
            _context.Set<Device>().Add(entity);
        }

        public void AddRange(IEnumerable<Device> entities)
        {
            _context.Set<Device>().AddRange(entities);
        }

        public IEnumerable<Device> Find(Expression<Func<Device, bool>> expression)
        {
            return _context.Set<Device>().Where(expression);
        }

       

        public Device GetById(Guid? id)
        {
            //return _context.Set<T>().Find(id);
            return _context.Device.Find(id);
        }


        public void Remove(Device entity)
        {
            _context.Set<Device>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Device> entities)
        {
            _context.Set<Device>().RemoveRange(entities);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Device entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        //1
        public IEnumerable<Device> GetAll()
        {
            //var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            var result = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return result.ToList();
        }

        //public Device GetById(Guid? id)
        //{
        //    //return _context.Set<T>().Find(id);
        //    return _context.Device.Find(id);
        //}


        //2
        //public IEnumerable<Device> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var result =  _context.Device
        //        .Include(d => d.Category)
        //        .Include(d => d.Zone)
        //        .FirstOrDefaultAsync(m => m.DeviceId == id);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return (IEnumerable<Device>)result;
        //}

        private IEnumerable<Device> NotFound()
        {
            throw new NotImplementedException();
        }

        //3
        // GET: Devices/Create
        //public void Create(Device device)
        //{
        //    //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
        //    //ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName");
        //    //var _context.Zone(d => d.CategoryId) = new SelectList(_context.Zone, "ZoneId", "ZoneName");
        //    //return View();
        //    var result = _context.Device
        //        .Include(d => d.CategoryId)
        //        .Include(d => d.ZoneId);
        //    //    .FirstOrDefaultAsync(m => m.DeviceId);

        //    _context.Device.Add(device);
        //    //return (IEnumerable<Device>)result;
        //}


        ////4
        //// POST: Devices/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public void Create1([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        //{
        //    device.DeviceId = Guid.NewGuid();
        //    _context.Add(device);
        //    _context.SaveChangesAsync();
        //    //return RedirectToAction(nameof(Index));

        //}

       





        

        //public void Add(Device entity)
        //{
        //    _context.Set<Device>().Add(entity);
        //}

        //public void AddRange(IEnumerable<Device> entities)
        //{
        //    _context.Set<Device>().AddRange(entities);
        //}

        //public IEnumerable<Device> Find(Expression<Func<Device, bool>> expression)
        //{
        //    return _context.Set<Device>().Where(expression);
        //}


        //public Device GetById(Guid? id)
        //{
        //    return _context.Device.Find(id);
        //}

        //public Device GetById(Guid? id)
        //{
        //    //return _context.Set<T>().Find(id);
        //    return _context.Device.Find(id);
        //}


        //public void Remove(Device entity)
        //{
        //    _context.Set<Device>().Remove(entity);
        //}

        //public void RemoveRange(IEnumerable<Device> entities)
        //{
        //    _context.Set<Device>().RemoveRange(entities);
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        //public void Update(Device entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //}

        private bool Exists(Guid id)
        {
            //return _categoryRepository.Find(id);
            return _context.Device.Any(e => e.CategoryId == id);
        }

    }
}