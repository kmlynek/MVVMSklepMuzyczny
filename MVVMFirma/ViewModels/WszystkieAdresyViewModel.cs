using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszystkieAdresyViewModel : WorkspaceViewModel
    {
        #region Fields
        private readonly SklepMuzycznyEntities sklepMuzycznyEntities;//to jest pole, ktore reprezentuje baze danych
        #endregion
        #region Properties

        #endregion
        #region Constructor

        #endregion
        #region Helpers

        #endregion
        public WszystkieAdresyViewModel()
        {
            base.DisplayName = "Adresy";
        }
    }
}
