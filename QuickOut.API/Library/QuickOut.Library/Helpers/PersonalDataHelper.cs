using System.Text.RegularExpressions;

namespace QuickOut.Library;

public static class PersonalDataHelper
{
    public static bool IsValidCPF(string cpf)
    {

        // Remover todos os caracteres que não sejam dígitos
        string cpfLimpo = Regex.Replace(cpf, @"[^\d]", "");

        // Verificar se a string resultante possui 11 dígitos
        if (cpfLimpo.Length != 11)
        {
            return false;
        }

        // Verificar se todos os dígitos são iguais, o que tornaria o CPF inválido
        bool todosDigitosIguais = new string(cpfLimpo[0], cpfLimpo.Length) == cpfLimpo;
        if (todosDigitosIguais)
        {
            return false;
        }

        // Calcular dígitos verificadores
        int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string cpfSemDigitosVerificadores = cpfLimpo.Substring(0, 9);

        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(cpfSemDigitosVerificadores[i].ToString()) * multiplicadoresPrimeiroDigito[i];
        }

        int resto = soma % 11;
        int primeiroDigitoVerificador = resto < 2 ? 0 : 11 - resto;

        cpfSemDigitosVerificadores += primeiroDigitoVerificador;

        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpfSemDigitosVerificadores[i].ToString()) * multiplicadoresSegundoDigito[i];
        }

        resto = soma % 11;
        int segundoDigitoVerificador = resto < 2 ? 0 : 11 - resto;

        cpfSemDigitosVerificadores += segundoDigitoVerificador;

        // Verificar se os dígitos verificadores calculados são iguais aos fornecidos no CPF
        return cpfLimpo.EndsWith(primeiroDigitoVerificador.ToString() + segundoDigitoVerificador.ToString());
    }

}
