using System;

namespace Common.Attributes
{
    /// <summary>
    /// Type that handles the data-type of the specified blizzard guid.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class BlizzardGuidAttribute : Attribute
    {
        public string BlizzardGuid { get; private set; }

        public BlizzardGuidAttribute(string blizzardGuid)
        {
            BlizzardGuid = blizzardGuid;
        }
    }
}
