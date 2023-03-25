using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("FinancialSystem")]
    public class FinancialSystem : Base
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public int CloseDay { get; set; }

        public bool GenerateCopyDespise { get; set; }

        public int MonthCopy { get; set; }

        public int YearCopy { get; set; }

    }
}
