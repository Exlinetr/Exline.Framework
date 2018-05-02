using System;
using System.Linq.Expressions;

namespace Exline.Framework.Data
{
    public static class Extensions
    {
        public static string ToSql<TDocument>(this Expression<Func<TDocument, bool>> predicate)
            where TDocument : class, IDocument
        {
            return string.Empty;
        }
    }
}