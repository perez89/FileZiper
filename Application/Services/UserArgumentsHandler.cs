

namespace Application.Services
{
    using Application.Domain.DTOs;
    using Application.Services.Interfaces;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class UserArgumentsHandler : IUserArgumentsHandler
    {
        public UserCommandsDTO Extract(string[] Args)
        {
            var commands = new UserCommandsDTO();


            Regex Spliter = new Regex(@"^-{1,2}|^/|=",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            Regex Remover = new Regex(@"^['""]?(.*?)['""]?$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

            string Parameter = null;
            string[] Parts;


            foreach (string Txt in Args)
            {
              //  Console.WriteLine(Txt);
                // Look for new parameters (-,/ or --) and a
                // possible enclosed value (=,:)
                Parts = Spliter.Split(Txt, 3);

                switch (Parts.Length)
                {
                    // Found a value (for the last parameter 
                    // found (space separator))
                    case 1:
                        if (Parameter != null)
                        {

                            Parts[0] =
                                Remover.Replace(Parts[0], "$1");

                            commands.Add(new KeyValuePair<string, string>(Parameter, Parts[0]));
                         
                        }
                        // else Error: no parameter waiting for a value (skipped)
                        break;

                    // Found just a parameter
                    case 2:


                        Parameter = Parts[1];
                        break;


                }
            }

            return commands;


        }



    }
}
