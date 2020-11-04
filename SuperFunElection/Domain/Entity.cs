using System;

namespace SuperFunElection.Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(int id) : this()
        {
            Id = id;
        }

        private Type GetRealType()
        {
            var type = GetType();

            if (type.ToString().Contains("Castle.Proxies."))
                return type.BaseType;

            return type;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return ($"{GetRealType()}{Id}").GetHashCode();
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}
