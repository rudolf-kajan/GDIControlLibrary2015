using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class AdvancedToolTipConfigurator : UserControl
    {
        private AdvancedToolTip _advancedToolTip;

        public AdvancedToolTipConfigurator()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    _advancedToolTip.ChangeSkin(new BlackToolTipSkin());
                    break;
                case 1:
                    _advancedToolTip.ChangeSkin(new MaterialBlueSkin());
                    break;
                case 2:
                    _advancedToolTip.ChangeSkin(new MaterialOrangeSkin());
                    break;
            }
        }

        public void SetToolTipReference(AdvancedToolTip advancedToolTip)
        {
            _advancedToolTip = advancedToolTip;
        }
    }
}
