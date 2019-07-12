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
    using System.Web;

    public partial class university
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public university()
        {
            this.convention = new HashSet<convention>();
            this.department = new HashSet<department>();
            this.eclass = new HashSet<eclass>();
        }
    
        public long id { get; set; }
        public string email { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public long zip_code { get; set; }
        public string fax { get; set; }
        public string name { get; set; }
        public string registration_number { get; set; }
        public string tel { get; set; }
        public string web_site { get; set; }
        public long representative_id { get; set; }
        public string Logo { get; set; }
        public HttpPostedFileBase logoFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<convention> convention { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<department> department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eclass> eclass { get; set; }
        public virtual users users { get; set; }
    }
}
