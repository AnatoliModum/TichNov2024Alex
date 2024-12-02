using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEstados
{
    public class EstadosController
    {
        public Dictionary<int, string> Estados = new Dictionary<int, string>();
        
        public  void CreateEstados(int id, string estado)
        {
            Estados.Add(id, estado);
        }

        public  void UpdateEstados(int id, string estadoUpdate)
        {
            Estados[id] = estadoUpdate;
        }

        public Dictionary<int, string> ReadEstados()
        {
            return Estados;
        }

        public  void DeleteEstados(int id)
        {
            Estados.Remove(id);
        }

        
    }
}
