namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("registation")]
    public partial class registation
    {
        public int id { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        [Display(Name ="Id")]
        public string nic { get; set; }

        public int? course_id { get; set; }

        public int? batch_id { get; set; }

        public int? telno { get; set; }

        public virtual batch batch { get; set; }

        public virtual course course { get; set; }
    }
}
