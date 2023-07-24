using DataAccessLayer_DAL_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_DAL_;

public class Compuny_Post_Model
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Experience_Years_Need { get; set; }
    public string Career_Level  { get; set; }
    public ICollection<Jop_Categories_Model> Jop_Categories  { get; set; }
    public ICollection< Skill_Model> Skills_Needed { get; set; }

    /// <summary>
    /// The Compuny That Publish The Post Information
    /// </summary>

    [ForeignKey(nameof(Compuny))]
    public int Compuny_ID { get; set; }
    public Compuny_Model Compuny { get; set; }

    /// <summary>
    ///  The Application That Related To The Post 
    /// </summary>

    [ForeignKey(nameof(Compuny_Jop_Application))]
    public int Jop_Application_ID { get; set; }
    public Application_Model Compuny_Jop_Application { get; set; }

    public ICollection<Apply_Model> Applies { get; set; }
}
