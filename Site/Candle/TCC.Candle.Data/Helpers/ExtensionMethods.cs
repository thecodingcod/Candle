using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Remotion.Linq.Parsing.ExpressionVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TCC.Candle.Data.Helpers
{
    public static class ExtensionMethods
    {

        public static void ApplyGlobalFilters<TBase>(this ModelBuilder modelBuilder, Expression<Func<TBase, bool>> filterExpression)
        {
            // Looping over All Entity Types
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check that entity inherits from a TBase
                if (entityType.ClrType.BaseType != null && entityType.ClrType.BaseType.Name == typeof(TBase).Name)
                {
                    // Create A Parameter Expression Node
                    var newParam = Expression.Parameter(entityType.ClrType);



                    // Replacing the ParameterType to match one of the IInterface Ancestors
                    var newBody = ReplacingExpressionVisitor.Replace(filterExpression.Parameters.Single(), newParam,
                        filterExpression.Body);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(newBody, newParam));
                }
            }
        }
    }
}
