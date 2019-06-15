using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dto
{
    public class DtoProvider<T>
    {
        private (string name, Func<T, object> function)[] DtoProps;

        public DtoProvider(params Expression<Func<T, object>>[] props)
        {
            DtoProps = new (string, Func<T, object>)[props.Length];
            for (int i = 0; i < props.Length; i++)
            {
                var body = props[i].Body;
                body = body.RemoveConvert();
                if (!(body is MemberExpression meBody))
                {
                    throw new Exception("Expresion Tube must be memberAccess");
                }

                DtoProps[i] = (meBody.Member.Name, props[i].Compile());
            }
        }

        public Dictionary<string, object> createDto(T obj)
        {
            var Dto = new Dictionary<string, object>();
            foreach (var item in DtoProps)
            {
                Dto.Add(item.name, item.function.Invoke(obj));
            }

            return Dto;
        }

    }
}