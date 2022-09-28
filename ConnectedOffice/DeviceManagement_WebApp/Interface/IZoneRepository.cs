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

namespace DeviceManagement_WebApp.Interface
{
    public interface IZoneRepository
    {

        Zone GetById(Guid? id);

        IEnumerable<Zone> GetAll();

        IEnumerable<Zone> Find(Expression<Func<Zone, bool>> expression);

        void Add(Zone entity);

        void AddRange(IEnumerable<Zone> entities);

        void Remove(Zone entity);

        void RemoveRange(IEnumerable<Zone> entites);
    }
}