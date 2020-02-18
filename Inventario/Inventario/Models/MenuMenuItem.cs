using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Views
{

    public class MenuMenuItem
    {
        public MenuMenuItem()
        {
            TargetType = typeof(Productos);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}