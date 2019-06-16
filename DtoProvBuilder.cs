using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dto
{
    public class DtoProvBuilder<T>
    {
        private List<Expression<Func<T, object>>> props;

        public DtoProvBuilder()
        {
            props = new List<Expression<Func<T, object>>>();
        }

        public DtoProvBuilder<T> addYechizi(Expression<Func<T, object>> exp)
        {
            props.Add(exp);
            return this;
        }

        public DtoProvider<T> build()
        {
            return new DtoProvider<T>(props.ToArray());
        }
    }
}