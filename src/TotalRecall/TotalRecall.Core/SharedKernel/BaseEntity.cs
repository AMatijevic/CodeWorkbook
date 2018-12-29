﻿using System;

namespace TotalRecall.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        protected object Actual => this;

        public DateTime Created { get; protected set; }
        public DateTime Edited { get; protected set; }
        public DateTime? Deleted { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity;

            if (other is null)
                return false;

            if (ReferenceEquals(Actual, other))
                return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }
        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }
    }
}