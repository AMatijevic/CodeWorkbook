using System.Collections.Generic;
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

        public Type Type { get; protected set; }

        //EF Core Many to Many
        private readonly List<Tag> _tags = new List<Tag>();
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        public Importance Importance { get; protected set; }
        public double TimeEstimate { get; protected set; }
        public string Complexity { get; protected set; }
        public string Url { get; protected set; }
        public Length Length { get; protected set; }

        private readonly List<Summary> _summarys = new List<Summary>();
        public IReadOnlyCollection<Summary> Summarys => _summarys.AsReadOnly();
    }
}