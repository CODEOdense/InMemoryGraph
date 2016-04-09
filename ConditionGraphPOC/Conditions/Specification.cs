using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Conditions
{
    public interface ISpecification<TCandidate>
    {
        bool IsSatisfiedBy(TCandidate candidate);
    }

    //public abstract class Specification<TCandidate> : ISpecification<TCandidate>
    //{
    //    public bool IsSatisfiedBy(TCandidate candidate)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public abstract class CompositeSpecification<TCandidate> : ISpecification<TCandidate>
    {
        protected readonly ISpecification<TCandidate> _a;
        protected readonly ISpecification<TCandidate> _b;

        protected CompositeSpecification(ISpecification<TCandidate> a, ISpecification<TCandidate> b)
        {
            if (a == null) throw new ArgumentNullException("a");
            if (b == null) throw new ArgumentNullException("b");
            _a = a; _b = b;
        }
        public abstract bool IsSatisfiedBy(TCandidate candidate);
    }

    public class AndSpecification<TCandidate> : CompositeSpecification<TCandidate>
    {
        protected AndSpecification(ISpecification<TCandidate> a, ISpecification<TCandidate> b) : base(a, b) { }

        public override bool IsSatisfiedBy(TCandidate candidate)
        {
            return _a.IsSatisfiedBy(candidate) && _b.IsSatisfiedBy(candidate);
        }
    }

    public class OrSpecification<TCandidate> : CompositeSpecification<TCandidate>
    {
        protected OrSpecification(ISpecification<TCandidate> a, ISpecification<TCandidate> b) : base(a, b) { }

        public override bool IsSatisfiedBy(TCandidate candidate)
        {
            return _a.IsSatisfiedBy(candidate) || _b.IsSatisfiedBy(candidate);
        }
    }
}
