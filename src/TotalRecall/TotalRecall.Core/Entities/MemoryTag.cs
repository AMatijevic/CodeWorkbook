using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalRecall.Core.SharedKernel;

namespace TotalRecall.Core.Entities
{
    public class MemoryTag: BaseEntity
    {
        private MemoryTag(){}

        public MemoryTag(Memory memory, Tag tag)
        {
            Memory = memory;
            Tag = tag;
        }

        public int MemoryId { get; protected set; }
        public Memory Memory { get; protected set; }

        public int TagId { get; protected set; }
        public Tag Tag { get; protected set; }
    }
}
