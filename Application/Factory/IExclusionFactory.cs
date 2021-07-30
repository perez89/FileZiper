
namespace Application.Factory
{
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Exclusions.Interfaces;
    using System.Collections.Generic;

    public interface IExclusionFactory
    {
        ExclusionBase CreateExclusion(ExclusionType type, IList<string> exclusions);
    }
}