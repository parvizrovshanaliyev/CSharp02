using System;

namespace Blog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual bool IsActive { get; private set; } = true;
        public virtual bool IsDeleted { get; private set; } = false;
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual string Note { get; private set; }

        public virtual string CreatedByName { get; private set; } = "Admin";
        public virtual string ModifiedByName { get; private set; } = "Admin";

        // methods
        public void SetIsActive(bool isActive)
        {
            this.IsActive = isActive;
        }
        public void SetIsDeleted(bool isDeleted)
        {
            this.IsDeleted = isDeleted;
        }
        public void SetCreatedByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.CreatedByName = name;
            }
        }
        public void SetModifiedByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.ModifiedByName = name;
            }
        }

        public void SetNote(string note)
        {
            if (!string.IsNullOrEmpty(note))
            {
                this.Note = note;
            }
        }
    }
}
