using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
        }

        protected EntityBase(string note) : this()
        {
            Note = note;
        }

        public virtual int Id { get; set; }

        [Required] public virtual bool IsActive { get; private set; } = true;

        [Required] public virtual bool IsDeleted { get; private set; }

        [Required] public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required] public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        [MaxLength(500)] public virtual string Note { get; set; }

        [Required] public virtual string CreatedByName { get; private set; } = "Admin";

        [Required] public virtual string ModifiedByName { get; private set; } = "Admin";

        // methods
        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

        public void SetCreatedByName(string name)
        {
            if (!string.IsNullOrEmpty(name)) CreatedByName = name;
        }

        public void SetModifiedByName(string name)
        {
            if (!string.IsNullOrEmpty(name)) ModifiedByName = name;
        }

        public void SetNote(string note)
        {
            if (!string.IsNullOrEmpty(note)) Note = note;
        }
    }
}