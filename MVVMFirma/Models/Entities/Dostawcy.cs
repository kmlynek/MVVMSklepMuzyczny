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
    
    public partial class Dostawcy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dostawcy()
        {
            this.ProduktyDostawcy = new HashSet<ProduktyDostawcy>();
        }
    
        public int DostawcaID { get; set; }
        public string Nazwa { get; set; }
        public string Kontakt { get; set; }
        public Nullable<int> AdresID { get; set; }
    
        public virtual Adresy Adresy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProduktyDostawcy> ProduktyDostawcy { get; set; }
    }
}
