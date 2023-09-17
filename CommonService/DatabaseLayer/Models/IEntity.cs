using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService.DatabaseLayer.Models
{
    public interface IEntity
    {
        public int ID { get; set; }
    }
}
