using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Offer_Model 
{

    [Key]
    [ForeignKey(nameof(Compuny))]
    public int Compuny_ID { get; set; }
    public Compuny_Model Compuny { get; set; }

    [Key]
    [ForeignKey(nameof(Employee_Post))]
    public int Employee_Post_ID { get; set; }
    public Employee_Post_Model Employee_Post { get; set; }

}
