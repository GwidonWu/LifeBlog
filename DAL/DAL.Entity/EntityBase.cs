using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EntityBase<TKey> : IEntityBase<TKey>
    {
        [Key]
        public TKey ID { get; set; }

    }
}
