using ADOLibrairy;
using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MovieDAL.Services
{
    public class ActorService : ServiceBase<int, Actor>
    {
        private Actor Converter(SqlDataReader reader)
        {
            return new Actor(


                (int)reader["ActorId"],
                reader["LastName"].ToString(),
                reader["FirstName"].ToString()

            );

        }

        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Actor> GetAll()
        {
            Command cmd = new Command("GetAllActor", true);
            return connection.ExecuteReader<Actor>(cmd, Converter);
        }



        public override Actor GetById(int key)
        {
            Command cmd = new Command("GetByIdActor", true);
            cmd.AddParameter("Id", key);

            return connection.ExecuteReader<Actor>(cmd, Converter).FirstOrDefault();
        }


        public IEnumerable<Actor> GetByFilm(String title)
        {
            Command cmd = new Command("GetActorByFilm", true);
            cmd.AddParameter("title", title);
            return connection.ExecuteReader<Actor>(cmd, Converter);
        }




        public IEnumerable<Actor> GetActorByInitial(char first, char last)
        {
            Command cmd = new Command("GetActorInitial", true);
            cmd.AddParameter("initialF", first);
            cmd.AddParameter("initialL", last);
            return connection.ExecuteReader<Actor>(cmd, Converter);
        }

        #region CORRIGER
        
        public IEnumerable<string> GetAllInitials()
        {
            Command cmd = new Command("GetAllActorInitial", true);
            return connection.ExecuteReader(cmd, Converter).Select(item => item.LastName).ToList();

        }
        #endregion

        public override int Insert(Actor entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Actor entity)
        {
            throw new NotImplementedException();
        }
    }


}

