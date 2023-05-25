namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("batch")]
    public partial class batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public batch()
        {
            registations = new HashSet<registation>();
        }

        public int id { get; set; }

        [Column("batch")]
        [StringLength(50)]
        public string batch1 { get; set; }

        [StringLength(50)]
        public string year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registation> registations { get; set; }
    }
}
