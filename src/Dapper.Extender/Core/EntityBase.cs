using System;

namespace Dapper.Extender.Core
{
    public class EntityBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; };
    }
}
