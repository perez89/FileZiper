
namespace Application.Domain.Exclusions.Interfaces
{
    using Application.Domain.Enums;
    using System.Collections.Generic;
    public interface IExclusion
    {
        ExclusionType Type { get; set; }

        List<string> Values { get; set; }
    }
}
