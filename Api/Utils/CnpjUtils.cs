namespace Api.Utils
{
    public class CnpjUtils
    {
        public static bool ValidarCNPJ(string cnpj)
        {
            cnpj = System.Text.RegularExpressions.Regex.Replace(cnpj, @"[^0-9]", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            int[] digitos = new int[cnpj.Length];
            int ind = 0;
            foreach (char c in cnpj)
            {
                if (char.IsDigit(c)) 
                {
                    digitos[ind++] = int.Parse(c.ToString());
                }
            }


            int soma1 = 0;
            int peso1 = 5;
            for (int i = 0; i < 12; i++)
            {
                soma1 += digitos[i] * peso1;
                peso1 = peso1 == 2 ? 9 : peso1 - 1;
            }

            int resto1 = soma1 % 11;
            int digito1 = resto1 < 2 ? 0 : 11 - resto1;

            int soma2 = 0;
            int peso2 = 6;
            for (int i = 0; i < 13; i++)
            {
                soma2 += digitos[i] * peso2;
                peso2 = peso2 == 2 ? 9 : peso2 - 1;
            }

            int resto2 = soma2 % 11;
            int digito2 = resto2 < 2 ? 0 : 11 - resto2;

            return digitos[12] == digito1 && digitos[13] == digito2;
        }
    }
}