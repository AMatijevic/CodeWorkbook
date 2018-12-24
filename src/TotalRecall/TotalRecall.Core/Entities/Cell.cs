using System.Collections.Generic;
using System.Collections.ObjectModel;
using TotalRecall.Core.Enums;

namespace TotalRecall.Core.Entities
{
    public class Cell : BaseEntity
    {
        private Cell()
        {
        }
        public Cell(string title, Type type)
        {
            Title = title;
            Type = type;
            Length = new Length();
        }
        public string Title { get; protected set; }
        public Type Type { get; protected set; }

        //EF Core Many to Many
        private readonly List<Tag> _tags = new List<Tag>();
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        public Importance Importance { get; protected set; } 
        public double TimeEstimate { get; protected set; }
        public string Complexity { get; protected set; }
        public string Url { get; protected set; }
        public Length Length { get; set; }

        private readonly List<Summary> _summarys = new List<Summary>();
        public IReadOnlyCollection<Summary> Summarys => _summarys.AsReadOnly();
    }
}