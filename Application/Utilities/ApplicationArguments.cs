

namespace Application.Utitlities
{
    using Application.Domain.Enums;
    using System;
    using System.Collections.Generic;
    public static class ApplicationArguments
    {
        public static Dictionary<int, string> AvailableOutputOperations()
        {
            var availableOutputOperations = new Dictionary<int, string>();

            foreach (OutputType uot in Enum.GetValues(typeof(OutputType)))
            {
                availableOutputOperations.Add((int)uot, uot.ToString());
            }

            return availableOutputOperations;
        }

        public static Dictionary<int, string> AvailableExtensions()
        {
            var availableExtensions = new Dictionary<int, string>();

            foreach (ExclusionType uot in Enum.GetValues(typeof(ExclusionType)))
            {
                availableExtensions.Add((int)uot, uot.ToString());
            }

            return availableExtensions;
        }

        public static Dictionary<int, string> AvailableCommands()
        {
            var availableCommands = new Dictionary<int, string>();

            foreach (CommandTypes uot in Enum.GetValues(typeof(CommandTypes)))
            {
                availableCommands.Add((int)uot, uot.ToString());
            }

            return availableCommands;
        }
    }
}
