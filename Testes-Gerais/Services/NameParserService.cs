using System;
using System.Linq;
using Testes_Gerais.Interfaces;

namespace Testes_Gerais.Services
{
    public class NameParserService : INameParserService
    {
        // Codigo Simples
        public string GetLastName(string fullName)
        {
            var names = fullName.Split(" ");
            var lastName = names.LastOrDefault();
            return lastName ?? string.Empty;
        }
        // Codigo basico
        public string GetLastNameUsingSubstring(string fullName)
        {
            var lastSpaceIndex = fullName.LastIndexOf(" ", StringComparison.Ordinal);

            // Se nao tiver espaços, retorna vazio
            return lastSpaceIndex == -1
                ? string.Empty
                : fullName.Substring(lastSpaceIndex + 1);
        }
        // Codigo refeito e mais rapido por conta do Span
        public ReadOnlySpan<char> GetLastNameWithSpan(ReadOnlySpan<char> fullName)
        {
            var lastSpaceIndex = fullName.LastIndexOf(' ');
            // Se nao tiver espaços, retorna vazio
            return lastSpaceIndex == -1
                ? ReadOnlySpan<char>.Empty
                : fullName.Slice(lastSpaceIndex + 1);
        }
    }
}
