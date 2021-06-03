using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class BaseDBEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// when derived from BaseDBEntity and PK is not BaseDBEntity.Id
        public int Id { get; set; }

        public BaseDBEntity()
        { }
        public BaseDBEntity(int id)
        { this.Id = id; }
    }
}
