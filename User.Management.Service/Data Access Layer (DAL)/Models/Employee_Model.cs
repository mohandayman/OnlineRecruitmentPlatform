using DataAccessLayer_DAL_;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Management.Service.Data_Access_Layer__DAL_.Models;

public class Employee_Model : UserModel
{
    public override string Id { get; set; }
    public string Position { get; set; }
    public ICollection<Skill_Model> Skills { get; set; }

    public string CV { get; set; }
    public string Gender { get; set; }
    public string Image { get; set; }
    //public ICollection<Employee_Post_Model> Posts { get; set; }

    //public ICollection<Apply_Model> Applies { get; set; }
}
