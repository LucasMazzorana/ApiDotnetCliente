using System.ComponentModel.DataAnnotations;
using Api.Utils;

public class CnpjAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null || !(value is string cnpj))
        {
            return false;
        }
        return CnpjUtils.ValidarCNPJ(cnpj);
    }
}