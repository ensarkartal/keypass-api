using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Concrete;

public class AggregateEntity : BaseEntity
{
    public AggregateEntity()
    {
        CreatedTime = DateTime.UtcNow;
        IsDeleted = false;
    }
    public string CreatedUserId { get; set; }
    public DateTime? CreatedTime { get; set; }
    public string UpdatedUserId { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}