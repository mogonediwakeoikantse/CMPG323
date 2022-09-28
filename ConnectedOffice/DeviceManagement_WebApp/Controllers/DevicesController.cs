using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        //private readonly ConnectedOfficeContext _context;

        //public DevicesController(ConnectedOfficeContext context)
        //{
        //    _context = context;
        //}

        DeviceRepository _deviceRepository = new DeviceRepository();

        //1
        // GET: Devices
        public async Task<IActionResult> Index()
        {
            //var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            var result = _deviceRepository.Get();
            return View(result);
        }

        //2
        // GET: Devices/Details/5
        public async Task<IActionResult> GetDetails(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var result = await _context.Device
            //    .Include(d => d.Category)
            //    .Include(d => d.Zone)
            //    .FirstOrDefaultAsync(m => m.DeviceId == id);
            var result = _deviceRepository.Details(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }


        //3
        // GET: Devices/Create
        public IActionResult Create(Device device)
        {
            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            //ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName");
            //ViewData["ZoneId"] = new SelectList(_deviceRepository.Zone, "ZoneId", "ZoneName");
            //return View();
            //_deviceRepository.Create(device);
            return View(device);
        }


        //4
        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _deviceRepository.Create(device);
            //_context.Add(device);
            //await _context.SaveChangesAsync();
            _deviceRepository.Save();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device =  _deviceRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", device.CategoryId);
            //ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName", device.ZoneId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepository.Update(device);
                _deviceRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != (device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device =  _deviceRepository.GetById(id);
                //.Include(d => d.Category)
                //.Include(d => d.Zone)
                //.FirstOrDefaultAsync(m => m.DeviceId == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = _deviceRepository.GetById(id);
            _deviceRepository.Remove(device);
            _deviceRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool DeviceExists(Guid id)
        //{
        //    return _context.Device.Any(e => e.DeviceId == id);
        //}

    }
}
