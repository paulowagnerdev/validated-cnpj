using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Validate_CNPJ.Services;
 
 internal class FormataCnpj
 {
     internal static string Formatar(string cnpj)
     {
         var stringFormatada = new string(cnpj
             .Where(char.IsLetterOrDigit)
             .ToArray());

         if (stringFormatada.Length > 14)
             stringFormatada = stringFormatada.Substring(0, 14);

         return AplicaMascara(stringFormatada);
     }
     private static string AplicaMascara(string cnpj)
     {
         if (string.IsNullOrEmpty(cnpj))
             return string.Empty;

         if (cnpj.Length <= 2)
             return cnpj;

         if (cnpj.Length <= 5)
             return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2)}";

         if (cnpj.Length <= 8)
             return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5)}";

         if (cnpj.Length <= 12)
             return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8)}";

         return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12)}";
     }
 }