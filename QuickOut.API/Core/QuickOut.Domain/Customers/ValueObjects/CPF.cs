using QuickOut.Domain.Common.Shared;
using QuickOut.Library;

namespace QuickOut.Domain.Customers.ValueObjects;

public class Cpf : ValueObject
{
    public string Document { get; private set; }
    
    protected Cpf() {}

    public static Result<Cpf> New(string document)
    {
        if (string.IsNullOrEmpty(document))
        {
            return Result<Cpf>.Fail("CPF vazio");
        }

        if (!PersonalDataHelper.IsValidCPF(document))
        {
            return Result<Cpf>.Fail("CPF Inválido");
        }

        Cpf cpf = new Cpf
        {
            Document = document
        };

        return Result<Cpf>.Success(cpf);
    } 
}