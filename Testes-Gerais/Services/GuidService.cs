using System;

namespace Testes_Gerais.Services
{
    public class GuidService
    {
        private readonly Guid serviceGuid;
        public GuidService()
        {
            serviceGuid = Guid.NewGuid();
        }

        public string GetGuid() => serviceGuid.ToString();
    }
}
