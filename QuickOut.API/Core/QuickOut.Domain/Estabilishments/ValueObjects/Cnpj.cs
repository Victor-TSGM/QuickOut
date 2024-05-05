using System.Text.RegularExpressions;
using QuickOut.Domain.Common.Shared;
using QuickOut.Library;

namespace QuickOut.Domain.Estabilishments.ValueObjects;

public class Cnpj : ValueObject
{
    public string Document { get; private set; }
    
    protected Cnpj() {}

    public static Result<Cnpj> New(string document)
    {
        if (string.IsNullOrEmpty(document))
        {
            return Result<Cnpj>.Fail("CNPJ inválido");
        }

        Regex regex = new Regex(@"^\d{2}\.?\d{3}\.?\d{3}\/?\d{4}\-?\d{2}$");

        if (!regex.IsMatch(document))
        {
            return Result<Cnpj>.Fail("CNPJ inválido");
        }

        Cnpj cnpj = new Cnpj()
        {
            Document = document
        };

        return Result<Cnpj>.Success(cnpj);
    }
}