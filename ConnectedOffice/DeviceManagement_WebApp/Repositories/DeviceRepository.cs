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

namespace DeviceManagement_WebApp.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository<Device>
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        { }

        //GET: Devices
        public List<Device> GetAll()
        {
            return _context.Device.ToList();
        }
    }
}