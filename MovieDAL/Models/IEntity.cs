using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDAL.Models
{
    public interface IEntity<Tkey>
    {
        Tkey Id { get; }

    }
}
