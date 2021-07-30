

namespace Application.Factory
{
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Exclusions.Interfaces;
    using System;
    using System.Collections.Generic;
    public  class ExclusionFactory : IExclusionFactory
    {
        public ExclusionBase CreateExclusion(ExclusionType type, IList<string> exclusions)
        {
            switch (type)
            {
                case ExclusionType.EFolder:
                    return new FolderExclusion(exclusions);
                case ExclusionType.EExtension:
                    return new ExtensionExclusion(exclusions);
                case ExclusionType.EFile:
                    return new FileExclusion(exclusions);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

        }
    }

}
