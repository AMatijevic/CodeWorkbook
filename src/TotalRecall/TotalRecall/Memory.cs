using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TotalRecall
{
    public class Memory : BaseEntity
    {
        public string Name { get; set; }
        private readonly List<Cell> _cells = new List<Cell>();
        public IEnumerable<Cell> Cells => new ReadOnlyCollection<Cell>(_cells);
    }
}