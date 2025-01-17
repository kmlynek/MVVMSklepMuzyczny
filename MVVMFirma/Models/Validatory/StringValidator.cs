using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.Validatory
{
    public class StringValidator
    {
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                    return "Rozpocznij dużą literą!";
            }
            catch (Exception e) { }
            return null;
        }
            public static string SprawdzCzyZawieraAt(string email)
            {
            if (email == null) 
                return "Adres e-mail nie może być pusty.";
            if (!email.Contains("@")) 
                return "Adres e-mail musi zawierać znak '@'!";
            return null; 
        }
        }
   }

    
      



