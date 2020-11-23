using ADOLibrairy;
using MovieDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MovieDAL.Services
{
    public class FilmService : ServiceBase<int, Film>
    {

        private Film Converter(SqlDataReader reader)
        {
            return new Film(

                (int)reader["FilmId"],
                reader["Title"].ToString(),
                reader["Description"].ToString(),
                (int)reader["ReleaseYear"],
                (int)reader["languageId"],
                (int)reader["RentalDuration"],
                (decimal)reader["RentalPrice"],
                (int)reader["Length"],
                (decimal)reader["ReplacementCost"],
                (int)reader["RatingId"]
                );
        }
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Film> GetAll()
        {
            Command cmd = new Command("GetAllFilm", true);
            return connection.ExecuteReader<Film>(cmd, Converter);
        }


        public IEnumerable<Film> GetByActor(string lastName)
        {
            Command cmd = new Command("GetFilmByActor", true);
            cmd.AddParameter("LastName", lastName);
            return connection.ExecuteReader<Film>(cmd, Converter);
        }

        public IEnumerable<Film> GetByIdActor(int id)
        {
            Command cmd = new Command("GetFimByIdActor", true);
            cmd.AddParameter("ActorId", id);
            return connection.ExecuteReader<Film>(cmd, Converter);
        }


        public IEnumerable<Film> GetByCategory(string catName)
        {
            Command cmd = new Command("GetFilmByCategory", true);
            cmd.AddParameter("Name", catName);
            return connection.ExecuteReader<Film>(cmd, Converter);

        }

        public IEnumerable<Film> GetByIdCategory(int id)
        {
            Command cmd = new Command("GetFilmByIdCategory", true);
            cmd.AddParameter("CategoryId", id);
            return connection.ExecuteReader<Film>(cmd, Converter);
        }


        public IEnumerable<Film> GetByLanguage(string language)
        {
            Command cmd = new Command("GetFilmByLanguage", true);
            cmd.AddParameter("Language", language);
            return connection.ExecuteReader<Film>(cmd, Converter);

        }

        public IEnumerable<Film> GetByIdLanguage(int id)
        {
            Command cmd = new Command("GetFilmByIdLanguage", true);
            cmd.AddParameter("LanguageId", id);
            return connection.ExecuteReader<Film>(cmd, Converter);
        }

        public IEnumerable<Film> GetByTitle(string title)
        {
            Command cmd = new Command("FilmByTitle", true);
            cmd.AddParameter("Title", title);
            return connection.ExecuteReader<Film>(cmd, Converter);

        }

        public IEnumerable<Film> GetByKeyWord(string KeyWord)
        {
            Command cmd = new Command("GetFilmByKeyWord", true);
            cmd.AddParameter("@KeyWord", KeyWord);
            return connection.ExecuteReader<Film>(cmd, Converter);

        }





        public override Film GetById(int key)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Film entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Film entity)
        {
            throw new NotImplementedException();
        }
    }
}
