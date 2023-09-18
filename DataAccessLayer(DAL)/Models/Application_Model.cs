using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Application_Model
{
    public int Id { get; set;}

    /// <summary>
    /// Compuny That Make The Appliction 
    /// </summary>

    [ForeignKey(nameof(Compuny))]
    public int CompunyId { get; set; }
    public Compuny_Model Compuny { get; set; }


    
    public ICollection<Question_Application_Model> Questions { get; set; }
}
