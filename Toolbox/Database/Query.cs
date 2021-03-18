using System;
using System.Collections.Generic;
using System.Linq;

namespace Toolbox.Database
{
    public sealed class Query
    {
        public string Request { get; }
        public bool IsProcedure { get; }

        private Dictionary<string, object> _Parameters;
        public IEnumerable<KeyValuePair<string, object>> Parameters
        {
            get { return _Parameters.Select(p => p); }
        }

        public Query(string request, bool isProcedure = false)
        {
            if (string.IsNullOrWhiteSpace(request))
                throw new ArgumentNullException(nameof(request));

            Request = request;
            IsProcedure = isProcedure;
            _Parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            _Parameters.Add(key, value ?? DBNull.Value);
        }

    }
}
