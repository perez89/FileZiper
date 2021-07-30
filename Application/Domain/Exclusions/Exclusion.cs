

namespace Application.Domain.Exclusions
{
    using Application.Domain.Enums;
    using Application.Domain.Exclusions.Interfaces;
    using System.Collections.Generic;

    public class Exclusion : IExclusion
    {    
        public ExclusionType ExclusionType { get; set; }
        public List<string> Exclusions { get; set; }
    }
}
