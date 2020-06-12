using System;

namespace Testes_Gerais.Interfaces
{
    public interface INameParserService
    {
        string GetLastName(string fullName);
        string GetLastNameUsingSubstring(string fullName);
        ReadOnlySpan<char> GetLastNameWithSpan(ReadOnlySpan<char> fullName);
    }
}
