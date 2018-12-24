using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TotalRecall.Core.Entities
{
    public class Memory : BaseEntity
    {
        private Memory()
        {
        }
        public Memory(string name, Cell cell)
        {
            Name = name;
            AddCell(cell);
        }

        public string Name { get; set; }
        private readonly List<Cell> _cells = new List<Cell>();
        public IReadOnlyCollection<Cell> Cells => _cells.AsReadOnly();

        private void AddCell(Cell cell)
        {
            _cells.Add(cell);
        }
    }
}