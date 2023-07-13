﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Domain.Common
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CreatedUserId")]
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey("UpdatedUserId")]
        public int? UpdatedUserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("CreatedUserId")]
        public virtual User? CreatedUser { get; set; }
        [ForeignKey("UpdatedUserId")]
        public virtual User? UpdatedUser { get; set; }
    }
}