using System.Linq.Expressions;

namespace Dto
{
    public static class ExpressionUtils
    {
        public static Expression RemoveConvert(this Expression exp)
        {
            if (exp.NodeType == ExpressionType.Convert)
                return ((UnaryExpression)exp).Operand;
            return exp;
        }
    }
}