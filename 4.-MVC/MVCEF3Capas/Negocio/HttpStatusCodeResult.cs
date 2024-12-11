using Entidades;

namespace Negocio
{
    internal class HttpStatusCodeResult : EstatusAlumnos
    {
        private object badRequest;

        public HttpStatusCodeResult(object badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}