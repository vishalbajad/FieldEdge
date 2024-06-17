using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEdge.Object_Provider
{
    /// <summary>
    /// App Setting Configuration Model
    /// </summary>
    public class AppSettingsConfigurations
    {
        public string Origins { get; set; }
        public string APIServerBaseUrl { get; set; }
        public string APIServerUsername { get; set; }
        public string APIServerPassword { get; set; }
        public string APIServerToken { get; set; }
    }
}
