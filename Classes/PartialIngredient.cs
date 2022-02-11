using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptiShitovaTarakanova
{
    public partial class Ingredient
    {
        public string FullPrice 
        { 
            get
            {
                return Cost.ToString("N0")+" руб. за "+CostForCount + " " +Unit.Name;
            }  
        }
    }
}
