namespace Application.Domain.Exclusions
{
    using Application.Domain.Exclusions.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtensionExclusion : ExclusionBase
    {
        public ExtensionExclusion(IList<string> exclusions) : base(exclusions)
        {

        }

        public override bool Exclude(string filePath)
        {
            return Exclusions.Any(extensionExclusion => string.Equals(GetExtension(filePath), string.Format(".{0}", extensionExclusion), System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
