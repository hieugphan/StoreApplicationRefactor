using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplicationDL
{
    public class QueryOptions<T> where T: class
    {
        public IList<Func<T, bool>> Conditions { get; set; }
        public IList<string> Includes { get; set; }
        
        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(0, int.MaxValue)]
        public int PageSize { get; set; }
        public string OrderBy { get; set; }

        public QueryOptions()
        {
            Conditions = new List<Func<T, bool>>();
            Includes = new List<string>();
        }
    }
}
