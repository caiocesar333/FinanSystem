using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notifications
{
    public class Notifie
    {
        public Notifie() 
        {
            notifications = new List<Notifie>();
        }    

        [NotMapped]
        public string NameProperty { get; set; }

        [NotMapped]
        public string message { get; set; }

        [NotMapped]
        public List<Notifie> notifications;

        public bool ValidatePropertyString(string value, string propertyName) 
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(propertyName))
                
                {
                notifications.Add(new Notifie 
                { 
                    message = "Required Field",
                    NameProperty = propertyName,
                });

                return false;    
                }
            return true;
        }

        public bool ValidatePropertyInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))

            {
                notifications.Add(new Notifie
                {
                    message = "Required Field",
                    NameProperty = propertyName,
                });

                return false;
            }
            return true;
        }

    }

}

