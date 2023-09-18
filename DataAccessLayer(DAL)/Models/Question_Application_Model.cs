using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Question_Application_Model
{

    [ForeignKey(nameof(Question))]
    [Key]
    public int Question_ID { get; set; }
    public Question_Model Question { get; set; }
    [ForeignKey(nameof(Application))]
    [Key]
    public int Application_ID { get; set; }
    public Application_Model Application { get; set; }

}
