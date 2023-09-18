using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Employee_Post_Model
{
    public int Id { get; set; }
    public string  Title  { get; set; }
    public string Position { get; set; }
    public string Description { get; set; }

    [ForeignKey(nameof(Employee))]
    public int Employee_ID { get; set; }
    public Employee_Model Employee { get; set; }

    public ICollection<Offer_Model> Offers { get; set; }

}
