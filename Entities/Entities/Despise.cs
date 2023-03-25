using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("Despise")]
    public class Despise : Base
    {

        public decimal Value { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public EnumTypeDespise TypeDespise { get; set; }

        public DateTime DateRegister { get; set; }

        public DateTime DateUpdate { get; set; }

        public DateTime DatePayment { get; set; }

        public DateTime DueDate { get; set;}

        public bool IsPayed { get; set; }

        public bool LateDespise{ get; set;}

        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int IdCategory { get; set; }

        public virtual Category Category { get; set; }
    }
}
