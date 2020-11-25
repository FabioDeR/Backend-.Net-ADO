using ADOLibrairy;
using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MovieDAL.Services
{
    public class RentalService : ServiceBase<int, Rental>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Rental> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Rental GetById(int key)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Rental entity)
        {
            throw new NotImplementedException();
        }

       
        public int Insertion(Rental entity, int[] films)
        {
            DataTable filma = new DataTable();
            filma.Columns.Add(new DataColumn("Id", typeof(int)));

            foreach (int t in films)
            {
                filma.Rows.Add(t);
            }
            Command cmd = new Command("CreatRental", true);
            cmd.AddParameter("CustomerId", entity.CustomerId);
            cmd.AddParameter("FilmIds", filma);
            return connection.ExecuteNonQuery(cmd);
        }

        public override bool Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
