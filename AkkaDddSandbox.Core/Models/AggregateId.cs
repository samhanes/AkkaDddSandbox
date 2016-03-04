namespace AkkaDddSandbox.Core.Models
{
    public abstract class AggregateId
    {
        protected bool Equals(AggregateId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;

            return string.Equals(other.ToString(), ToString());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AggregateId);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode() * GetType().GetHashCode();
        }

        public static bool operator ==(AggregateId left, AggregateId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AggregateId left, AggregateId right)
        {
            return !Equals(left, right);
        }
    }
}