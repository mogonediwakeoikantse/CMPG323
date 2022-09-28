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
    public interface ICategoryRepository /*: IDisposable*/
    {


        //T GetById(int id);
        Category GetById(Guid? id);

        //IEnumerable<T> GetAll();
        IEnumerable<Category> GetAll();

        IEnumerable<Category> Find(Expression<Func<Category, bool>> expression);

        void Add(Category entity);

        void AddRange(IEnumerable<Category> entities);

        void Remove(Category entity);

        void RemoveRange(IEnumerable<Category> entites);

        void Save();
        void Update(Category entity);
    }


    
}