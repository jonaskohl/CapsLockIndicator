using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    public class StringFormatter
    {
        public string String { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public StringFormatter(string @string)
        {
            String = @string;
            Parameters = new Dictionary<string, object>();
        }

        public void Add(string key, object val)
        {
            Parameters.Add(key, val);
        }

        public override string ToString()
        {
            return Parameters.Aggregate(String, (current, parameter) => current.Replace("{" + parameter.Key + "}", parameter.Value.ToString()));
        }

    }
}
