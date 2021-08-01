
namespace Application.Domain.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserCommandsDTO
    {
        private readonly List<KeyValuePair<string, string>> Parameters;

        public UserCommandsDTO(List<KeyValuePair<string, string>> parameters)
        {
            Parameters = parameters;
        }

        public IEnumerable<string> GetKeys()
        {
            return Parameters.Select(x => x.Key).ToList();
        }

        public IEnumerable<string> GetValues(string key)
        {
            return Parameters.Where(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> Get(string Param)
        {

            return Parameters.Where(x => string.Equals(Param, x.Key, StringComparison.OrdinalIgnoreCase)).Select(x => x).ToList();

        }

        public IEnumerable<KeyValuePair<string, string>> Get(string[] Param)
        {

            return Parameters.Where(x => Param.Contains(x.Key, StringComparer.OrdinalIgnoreCase)).Select(x => x).ToList();

        }

    }

}
