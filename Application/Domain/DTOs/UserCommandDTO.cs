
namespace Application.Domain.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserCommandsDTO
    {
        public UserCommandsDTO()
        {
            Parameters = new List<KeyValuePair<string, string>>();
        }
        // Variables
        private List<KeyValuePair<string, string>> Parameters;

        public void Add(KeyValuePair<string, string> data)
        {
            var _keyValuePair = new KeyValuePair<string, string>(data.Key, data.Value);
            Parameters.Add(_keyValuePair);
        }

        public IEnumerable<string> GetFlags()
        {
            return Parameters.Select(x => x.Key).ToList();
        }

        public IEnumerable<string> GetValues(string flag)
        {
            return Parameters.Where(x => string.Equals(x.Key, flag, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> this[string Param]
        {
            get
            {
                return (Parameters.Where(x => string.Equals(Param, x.Key, StringComparison.OrdinalIgnoreCase)).Select(x => x).ToList());
            }
        }

        public IEnumerable<KeyValuePair<string, string>> this[string[] Param]
        {
            get
            {
                return (Parameters.Where(x => Param.Contains(x.Key, StringComparer.OrdinalIgnoreCase)).Select(x => x).ToList());
            }
        }

    }

}
