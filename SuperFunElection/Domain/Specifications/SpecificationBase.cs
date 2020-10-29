using System;
using System.Linq.Expressions;

namespace SuperFunElection.Domain.Specifications
{
    public abstract class SpecificationBase<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> Filter();

        protected Expression<Func<T, bool>> And(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            Expression<Func<T, bool>> leftExpression = left;
            Expression<Func<T, bool>> rightExpression = right;

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }

        protected Expression<Func<T, bool>> Or(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var leftExpression = left;
            var rightExpression = right;
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }

        protected class ParameterReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _parameter;

            protected override Expression VisitParameter(ParameterExpression node)
                => base.VisitParameter(_parameter);

            internal ParameterReplacer(ParameterExpression parameter)
            {
                _parameter = parameter;
            }
        }
    }
}
