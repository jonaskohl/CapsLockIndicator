using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapsLockIndicatorV3
{
    public class QueryBuilder
    {
        private List<(string, string)> fields;

        public QueryBuilder()
        {
            fields = new List<(string, string)>();
        }

        public void Append(string name, string value)
        {
            fields.Add((name, value));
        }

        public string ToString(bool includeQuestionMark = false)
        {
            var sb = new StringBuilder();
            var lst = new List<string>();
            foreach (var (name, value) in fields)
            {
                sb.Clear();
                sb.Append(HttpUtility.UrlEncode(name));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(value));
                lst.Add(sb.ToString());
            }
            return (includeQuestionMark ? "?" : "") + string.Join("&", lst);
        }
    }
}
