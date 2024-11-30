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
    
    public partial class Produkty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produkty()
        {
            this.ElementyKoszyka = new HashSet<ElementyKoszyka>();
            this.ProduktyDostawcy = new HashSet<ProduktyDostawcy>();
            this.Promocje = new HashSet<Promocje>();
            this.Recenzje = new HashSet<Recenzje>();
            this.StanMagazynowy = new HashSet<StanMagazynowy>();
            this.SzczegolyZamowienia = new HashSet<SzczegolyZamowienia>();
        }
    
        public int ProduktID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Nullable<decimal> Cena { get; set; }
        public Nullable<int> KategoriaID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElementyKoszyka> ElementyKoszyka { get; set; }
        public virtual Kategorie Kategorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProduktyDostawcy> ProduktyDostawcy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promocje> Promocje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recenzje> Recenzje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StanMagazynowy> StanMagazynowy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SzczegolyZamowienia> SzczegolyZamowienia { get; set; }
    }
}
