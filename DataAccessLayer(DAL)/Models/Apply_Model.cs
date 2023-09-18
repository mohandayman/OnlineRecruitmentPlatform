using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Apply_Model 
{
    [Key]
    [ForeignKey(nameof(Employee))]
    public int Employee_ID { get; set; }
    public Employee_Model Employee { get; set; }

    [Key]
    [ForeignKey(nameof(Compuny_Post))]
    public int Compuny_Post_ID { get; set; }
    public Compuny_Post_Model Compuny_Post { get; set; }

}
