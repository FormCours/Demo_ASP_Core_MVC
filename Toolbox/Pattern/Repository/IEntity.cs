using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Pattern.Repository
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
