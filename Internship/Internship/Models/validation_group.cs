//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Internship.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class validation_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public validation_group()
        {
            this.final_project_assignment = new HashSet<final_project_assignment>();
        }
    
        public long id { get; set; }
        public bool valid_internship_director { get; set; }
        public bool valid_pre_validator { get; set; }
        public bool valid_president { get; set; }
        public bool valid_reporter { get; set; }
        public bool valid_supervisor { get; set; }
        public Nullable<long> internship_director_id { get; set; }
        public Nullable<long> pre_validator_id { get; set; }
        public Nullable<long> president_id { get; set; }
        public Nullable<long> reporter_id { get; set; }
        public Nullable<long> supervisor_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<final_project_assignment> final_project_assignment { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
        public virtual users users2 { get; set; }
        public virtual users users3 { get; set; }
        public virtual users users4 { get; set; }
    }
}