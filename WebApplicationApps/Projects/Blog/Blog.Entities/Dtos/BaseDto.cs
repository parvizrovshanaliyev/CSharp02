using System;

namespace Blog.Entities.Dtos
{
    public abstract class BaseDto
    {
        public virtual int Id { get; set; }
        public virtual bool IsActive { get;  set; }
        public virtual bool IsDeleted { get;  set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Note { get; set; }
        public virtual string CreatedByName { get;  set; }
        public virtual string ModifiedByName { get;  set; } 
    }
}
