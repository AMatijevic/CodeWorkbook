using System.Collections.Generic;
using System.Linq;
using TotalRecall.Core.Entities.ValueObjects;
using TotalRecall.Core.Enums;
using TotalRecall.Core.SharedKernel;

namespace TotalRecall.Core.Entities
{
    public class Memory : BaseEntity
    {
        private Memory()
        {
        }

        public Memory(string name, Type type, IEnumerable<Tag> tags)
        {
            Name = name;
            Type = type;
            Length = new Length();
            //AddTag(tags.FirstOrDefault());
            _memoryTags.AddRange(tags.Select(tag => new MemoryTag(this, tag)));
        }

        public Type Type { get; protected set; }

        public string Name { get; set; }

        //EF Core Many to Many
        private readonly List<MemoryTag> _memoryTags = new List<MemoryTag>();
        public IReadOnlyCollection<MemoryTag> MemoryTags => _memoryTags.AsReadOnly();

        public Importance Importance { get; protected set; }
        public double TimeEstimate { get; protected set; }
        public string Complexity { get; protected set; }
        public string Url { get; protected set; }
        public Length Length { get; protected set; }

        private readonly List<Summary> _summarys = new List<Summary>();
        public IReadOnlyCollection<Summary> Summarys => _summarys.AsReadOnly();

        public void AddTag(Tag tag)
        {
            _memoryTags.Add(new MemoryTag(this, tag));
        }
    }
}