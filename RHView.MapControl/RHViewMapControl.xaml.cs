using System.ComponentModel;
using System.Windows.Controls;
using GMap.NET.MapProviders;

namespace RHView.MapControl
{    
    public partial class RHViewMapControl : UserControl
    {
        public RHViewMapControl()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                if (!DesignerProperties.GetIsInDesignMode(this))
                MapControl.MapProvider = GMapProviders.GoogleMap;              
            };
        }
    }
}
