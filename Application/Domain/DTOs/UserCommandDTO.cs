
namespace Application.Domain.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserCommandsDTO
    {
        public UserCommandsDTO()
        {
            Parameters = new List<UserCommand>();
        }
        // Variables
        private List<UserCommand> Parameters;

        public void Add(KeyValuePair<string, string> data)
        {
            Parameters.Add(new UserCommand { Option = data.Key, Argument = data.Value });
        }

        public IEnumerable<string> GetFlags()
        {
            return Parameters.Select(x => x.Option).ToList();
        }

        public IEnumerable<string> GetValues(string flag)
        {
            return Parameters.Where(x => string.Equals(x.Option, flag, StringComparison.OrdinalIgnoreCase)).Select(x => x.Argument).ToList();
        }

        public IEnumerable<UserCommand> this[string Param]
        {
            get
            {
                return (Parameters.Where(x => string.Equals(Param, x.Option, StringComparison.OrdinalIgnoreCase)).Select(x => x).ToList());
            }
        }

        public IEnumerable<UserCommand> this[string[] Param]
        {
            get
            {
                return (Parameters.Where(x => Param.Contains(x.Option, StringComparer.OrdinalIgnoreCase)).Select(x => x).ToList());
            }
        }

    }

}
