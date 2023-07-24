using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Jop_Response
{
    [ForeignKey(nameof(Employee))]
    [Key]
    public int Employee_ID { get; set; }
    public Employee_Model Employee { get; set; }

    [ForeignKey(nameof(Compuny))]
    [Key]
    public int Compuny_ID { get; set; }
    public Compuny_Model Compuny { get; set; }

    public string Response_Status { get; set; } = "Applied";

}
