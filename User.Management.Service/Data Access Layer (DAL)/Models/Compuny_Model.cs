using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Management.Service.Data_Access_Layer__DAL_.Models;

public class Compuny_Model: UserModel
{
    public override string Id { get; set; }
    public string CompunyName  { get; set; }
    public string  Insdustry{ get; set; }
    public string Address { get; set; }
    public string Logo { get; set; }

    //public ICollection< Compuny_Post_Model> Posts { get; set; }  // Map Into New Table Using Mass Transit Fire Events

    //public ICollection<Offer_Model> Offers { get; set; }   // Map Into New Table Using Mass Transit Fire Events

}
