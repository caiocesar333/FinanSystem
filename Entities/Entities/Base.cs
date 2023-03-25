using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Entities
{
    public class Base : Notifie
    {
        [Display(Name="Code")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }


    }
}
