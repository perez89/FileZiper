
namespace Application.Domain.Exclusions.Interfaces
{
    using Application.Domain.Enums;
    using System.Collections.Generic;
    public interface IExclusion
    {
        ExclusionType ExclusionType { get; set; }

        List<string> Exclusions { get; set; }
    }
}
