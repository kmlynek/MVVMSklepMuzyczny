using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : WorkspaceViewModel // bo wszystkie zakładki dziedziczą po WVM
    {
       public NowyAdresViewModel()
        {
            base.DisplayName = "Adres";
        }
    }
}
