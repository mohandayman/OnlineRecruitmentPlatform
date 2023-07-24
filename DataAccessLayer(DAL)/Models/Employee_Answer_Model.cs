using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Employee_Answer_Model
{

    [ForeignKey(nameof(Employee))]
    [Key]

    public int Employee_ID { get; set; }

    public Employee_Model Employee { get; set; }


    
    [ForeignKey(nameof(Question))]
    [Key]
    public int  Question_ID { get; set; }

    public Question_Model Question { get; set; }
    
    
 


    public string Answer_Content { get; set; }
}
