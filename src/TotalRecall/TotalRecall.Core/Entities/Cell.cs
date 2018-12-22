using System.Collections.Generic;
using System.Collections.ObjectModel;
using TotalRecall.Core.Enums;

namespace TotalRecall.Core.Entities
{
    public class Cell : BaseEntity
    {
        public string Type { get; protected set; }

        //EF Core Many to Many
        private readonly List<Tag> _tags = new List<Tag>();
        public IEnumerable<Tag> Tags => new ReadOnlyCollection<Tag>(_tags);

        public Importance Importance { get; protected set; } 
        public double TimeEstimate { get; protected set; }
        public string Complexity { get; protected set; }
        public string Url { get; protected set; }
        public Length Length { get; set; }

        private readonly List<Summary> _summarys = new List<Summary>();
        public IEnumerable<Summary> Summarys => new ReadOnlyCollection<Summary>(_summarys);
    }
}