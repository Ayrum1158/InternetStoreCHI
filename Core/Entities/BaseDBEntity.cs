using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class BaseDBEntity
    {
        public int Id { get; set; }

        public BaseDBEntity()
        { }
        public BaseDBEntity(int id)
        { this.Id = id; }
    }
}
