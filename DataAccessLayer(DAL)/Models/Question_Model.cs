using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Question_Model
{
    public int Id { get; set; }
    public string Question_Content { get; set; }

    
    public ICollection<Question_Application_Model> QuetionApplication{ get; set; }
}
