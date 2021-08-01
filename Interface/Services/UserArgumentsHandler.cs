

namespace Interface.Services
{
    using Interface.Services.Interfaces;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class UserArgumentsHandler : IUserArgumentsHandler
    {
        public List<KeyValuePair<string, string>> Extract(string[] Args)
        {
            var Parameters = new List<KeyValuePair<string, string>>();


            Regex Spliter = new Regex(@"^-{1,2}|^/|=",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            Regex Remover = new Regex(@"^['""]?(.*?)['""]?$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            string Parameter = null;
            string[] Parts;


            foreach (string Txt in Args)
            {                             
                // Look for new parameters (-,/ or --) 
                Parts = Spliter.Split(Txt.ToLower(), 3);

                switch (Parts.Length)
                {
          
                    case 1:
                        if (Parameter != null)
                        {

                            Parts[0] =
                                Remover.Replace(Parts[0], "$1");

                            Parameters.Add(new KeyValuePair<string, string>(Parameter, Parts[0]));
                         
                        }
                        break;

                    case 2:
                        Parameter = Parts[1];
                        break;


                }
            }

            return Parameters;


        }



    }
}
