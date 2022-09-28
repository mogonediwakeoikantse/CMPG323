using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Generic;
using DeviceManagement_WebApp.Interface;

namespace DeviceManagement_WebApp.Interface
{
    //public interface IDeviceRepository where T : class
    public interface IDeviceRepository
    {

        Device GetById(Guid? id);

        IEnumerable<Device> GetAll();

        IEnumerable<Device> Find(Expression<Func<Device, bool>> expression);

        void Add(Device entity);

        void AddRange(IEnumerable<Device> entities);

        void Remove(Device entity);

        void RemoveRange(IEnumerable<Device> entites);

        

        

        //IEnumerable<Device> Get();

        //IEnumerable<Device> Details(Guid? id);
        
        //void Create(Device device);

        //void Create1([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device);

    }
}