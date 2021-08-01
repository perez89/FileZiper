
namespace Interface.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IUserArgumentsHandler
    {
        List<KeyValuePair<string, string>> Extract(string[] Args);
    }
}