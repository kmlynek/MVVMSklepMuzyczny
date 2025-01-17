using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class BiznesValidator
    {
        public static string SprawdzCene(decimal? cena)
        {
            if (cena < 0)
                return "Cena powinna być wyższa od 0!";
            return null;
        }

        public static string SprawdzRabat(decimal? rabat)
        {
            if (rabat < 0 || rabat > 100)
                return "Rabat musi mieścić się w przedziale od 0 do 100!";
            return null;
        }

        public static string SprawdzNumerTelefonu(string numerTelefonu)
        {
            if (numerTelefonu == null)
                return "Numer telefonu nie może być pusty.";
            if (numerTelefonu.Length < 7 || numerTelefonu.Length > 15)
                return "Numer telefonu musi mieć od 7 do 15 znaków.";
            return null;
        }

    }
}
