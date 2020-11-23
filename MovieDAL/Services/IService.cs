using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDAL.Services
{
    public interface IService<Tkey, TEntity>
        where TEntity : IEntity<Tkey>
    {
        //CRUD

        Tkey Insert(TEntity entity);

        //Read
        TEntity GetById(Tkey key);

        IEnumerable<TEntity> GetAll();


        //Update
        bool Update(TEntity entity);

        //Delete
        bool Delete(Tkey key);
    }
}
