using System;
using System.Collections.Generic;
using GoogleApi.Extensions.Entities;

namespace GoogleApi.Extensions
{
    /// <summary>
    /// List holding Name / value pairs, and allow duplicates.
    /// </summary>
    public class QueryStringParameters : List<QueryStringParameter>
    {
        /// <summary>
        /// Adds a parameter to the collecton.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
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