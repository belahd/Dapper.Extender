using System;
using System.Linq.Expressions;
using System.Text;

namespace Dapper.Extender.Helpers
{
    public class Where<T> : ExpressionVisitor where T : class
    {
        StringBuilder builder = null;

        public Where()
        {
            builder = new StringBuilder();
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Negate:
                    builder.Append("-");
                    break;
            }
            Visit(node.Operand);

            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            builder.Append("(");

            Visit(node.Left);

            switch (node.NodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    builder.Append(" AND ");
                    break;

                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    builder.Append(" OR ");
                    break;

                case ExpressionType.GreaterThan:
                    builder.Append(" > ");
                    break;

                case ExpressionType.GreaterThanOrEqual:
                    builder.Append(" >= ");
                    break;

                case ExpressionType.LessThan:
                    builder.Append(" < ");
                    break;

                case ExpressionType.LessThanOrEqual:
                    builder.Append(" <= ");
                    break;

                case ExpressionType.Equal:
                    builder.Append(" = ");
                    break;

                case ExpressionType.NotEqual:
                    builder.Append(" <> ");
                    break;

                case ExpressionType.Add:
                    builder.Append(" + ");
                    break;

                case ExpressionType.Subtract:
                    builder.Append("-");
                    break;

                case ExpressionType.Multiply:
                    builder.Append(" * ");
                    break;

                case ExpressionType.Divide:
                    builder.Append(" / ");
                    break;
            }

            Visit(node.Right);


            builder.Append(")");

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            switch (Type.GetTypeCode(node.Value.GetType()))
            {
                case TypeCode.String:
                    builder.Append("'" + Convert.ToString(node.Value).Replace("'", "''") + "'");
                    break;

                case TypeCode.Int32:
                    builder.Append(node.Value);
                    break;

            }
            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            builder.Append(node.Name);
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            builder.Append("[" + typeof(T).Name + "].[" + node.Member.Name + "]");
            return node;
        }

        public override string ToString()
        {
            return "WHERE " + builder.ToString();
        }
    }
}