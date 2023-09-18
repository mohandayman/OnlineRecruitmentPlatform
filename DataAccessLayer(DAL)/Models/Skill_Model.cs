using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Skill_Model
{
    public int Id { get; set; } 
    public string Skill { get; set; }
    public ICollection<Compuny_Post_Model> Compuny_Post_Skills { get; set; }
    public ICollection<Employee_Model> Employee_skills { get; set; }
}
