
using FitnessCentar.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.SearchObject
{
    public class PrijemPacijentaSearchObject : BaseSearchObject
    {
        public DateTime? DatumIVrijemePrijemaStart { get; set; }
        public DateTime? DatumIVrijemePrijemaEnd { get; set; }



    }
}
