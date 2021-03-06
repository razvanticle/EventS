﻿using System;

namespace EventS.Domain.SharedKernel
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        protected Entity(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            Id = id;
        }
        
        public TId Id { get; }

        public override bool Equals(object otherObject)
        {
            Entity<TId> entity = otherObject as Entity<TId>;
            if (entity != null)
            {
                return Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public bool Equals(Entity<TId> other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}