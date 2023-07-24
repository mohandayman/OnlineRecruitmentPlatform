using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Compuny_Model
{
    public int Id { get; set; }
    public string CompunyName  { get; set; }
    public string  Insdustry{ get; set; }
    public string Address { get; set; }
    public ICollection< Compuny_Post_Model> Posts { get; set; }

    public ICollection<Offer_Model> Offers { get; set; }
    public string Logo { get; set; }

}
