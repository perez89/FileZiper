
namespace Application.Utilities
{
    using System.IO;
    using System.Reflection;

    public static class App
    {
        public static string GetApplicationName() {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            string name = Path.GetFileName(codeBase);

            return name;
        }
    }
}
