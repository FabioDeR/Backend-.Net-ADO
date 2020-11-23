using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDAL.Models
{
    public class Actor : IEntity<int>
    {
        public int Id { get; set; }

        public int ActorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Actor(int actorId, string lastName, string firstName)
        {
            ActorId = actorId;
            LastName = lastName;
            FirstName = firstName;
        }

        public Actor(int id, int actorId, string lastName, string firstName) :
            this(actorId, lastName, firstName)
        {
            Id = id;
        }

        public Actor()
        {

        }
    }
}
