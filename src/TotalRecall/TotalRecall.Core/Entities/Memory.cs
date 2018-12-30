using System.Collections.Generic;
using TotalRecall.Core.SharedKernel;

namespace TotalRecall.Core.Entities
{
    public class Memory : BaseEntity
    {
        public string Name { get; protected set; }
        public string Path { get; protected set; }
        private readonly List<Cell> _cells = new List<Cell>();
        public IReadOnlyCollection<Cell> Cells => _cells.AsReadOnly();
    }
}