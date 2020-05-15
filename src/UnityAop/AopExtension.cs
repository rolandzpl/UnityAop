using Unity.Extension;
using System.Linq.Expressions;
using System;

namespace Lithium.UnityAop
{
    public class AopExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public Pointcut Intercept<T>(Expression<Func<T, object>> method)
        {
            return new Pointcut(this);
        }
    }

    public class Pointcut
    {
        private readonly AopExtension parent;

        public Pointcut(AopExtension parent)
        {
            this.parent = parent;
        }
        
        public Pointcut Intercept<T>(Expression<Func<T, object>> method)
        {
            return this;
        }

        public AopExtension WithAdvise()
        {
            return parent;
        }
    }
}
