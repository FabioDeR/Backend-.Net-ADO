using ADOLibrairy;
using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieDAL.Services
{
    public class CustomerService : ServiceBase<int, Customer>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Customer GetById(int key)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Customer entity)
        {
            Command cmd = new Command("MVSP_RegisterCustomer", true);
            cmd.AddParameter("LastName", entity.LastName);
            cmd.AddParameter("FirstName", entity.FirstName);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Passwd", entity.Passwd);
            return connection.ExecuteNonQuery(cmd);

        }

        public Customer GetCheck(Customer entity)
        {
            Command cmd = new Command("MVSP_CheckCustomer", true);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Passwd", entity.Passwd);
            return connection.ExecuteReader<Customer>(cmd, Converter).FirstOrDefault();
        }

        private Customer Converter(SqlDataReader reader)
        {
            return new Customer(

                (int)reader["CustomerId"],
                reader["LastName"].ToString(),
                reader["FirstName"].ToString(),
                reader["Email"].ToString()
                
            );
        }

        public override bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
