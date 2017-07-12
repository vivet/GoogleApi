using System;
using System.Collections.Generic;

namespace GoogleApi.Entities
{
    /// <summary>
    /// List of <see cref="QueryStringParameter"/>'s.
    /// Resembles a <see cref="Dictionary{TKey,TValue}"/>, but allow duplicate values.
    /// </summary>
    public class QueryStringParameters : List<QueryStringParameter>
    {
        /// <summary>
        /// Adds a parameter to the collecton.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public void Add(string name, string value)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var parameter = new QueryStringParameter { Name = name, Value = value };

            this.Add(parameter);
        }
    }
}