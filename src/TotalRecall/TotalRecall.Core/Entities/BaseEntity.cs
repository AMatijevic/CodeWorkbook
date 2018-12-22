using System;

namespace TotalRecall.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime Created { get; protected set; }
        public DateTime Edited { get; protected set; }
        public DateTime Deleted { get; protected set; }
    }
}