using System.Collections.Generic;
using TotalRecall.Core.SharedKernel;

namespace TotalRecall.Core.Entities
{
    public class Tag : BaseEntity
    {
        private Tag(){}

        public Tag(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        private readonly List<MemoryTag> _memoryTags = new List<MemoryTag>();
        public IReadOnlyCollection<MemoryTag> MemoryTags => _memoryTags.AsReadOnly();
    }
}