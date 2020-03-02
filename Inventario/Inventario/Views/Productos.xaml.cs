using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Inventario.Views
{
    public partial class Productos : ContentPage
    {
        ViewCell lastCell;

        public Productos()
        {
            InitializeComponent();
        }

        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.Gray;
                lastCell = viewCell;
            }
        }
    }
}
