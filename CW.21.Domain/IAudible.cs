using System;
using System.Collections.Generic;
using System.Text;

namespace CW._21.Domain
{
    public interface IAudible
    {
        DateTime CreatedAt { get; protected set; }
        DateTime ModifiedAt { get; protected set; }
        bool IsDeleted { get; protected set; }
    }
}
