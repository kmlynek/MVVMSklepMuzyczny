﻿using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ProduktyB : DataBaseClass
    {
        #region Konstruktor
        public ProduktyB(SklepMuzycznyEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        //dodajemy funkcje, która będzie zwracała id Zamówień itd. oraz nazwy i kod w KeyAndValue
        public IQueryable<KeyAndValue> GetProduktyKeyAndValueItems()
        {
            return (
                from produkt in db.Produkty
                select new KeyAndValue
                {
                    Key = produkt.ProduktID,
                    Value = produkt.Nazwa + " ; " + produkt.Opis + " ; " + produkt.Cena
                }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
