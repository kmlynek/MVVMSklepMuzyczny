//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class KoszykiZakupowe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KoszykiZakupowe()
        {
            this.ElementyKoszyka = new HashSet<ElementyKoszyka>();
        }
    
        public int KoszykID { get; set; }
        public Nullable<int> KlientID { get; set; }
        public Nullable<System.DateTime> DataUtworzenia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElementyKoszyka> ElementyKoszyka { get; set; }
        public virtual Klienci Klienci { get; set; }
    }
}
