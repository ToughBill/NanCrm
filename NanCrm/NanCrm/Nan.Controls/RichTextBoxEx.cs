using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nan.BusinessObjects;

namespace Nan.Controls
{
    public partial class RichTextBoxEx : RichTextBox
    {
        public BOIDEnum BOID { get; set; }
        public string BOField { get; set; }

        public RichTextBoxEx()
        {
            InitializeComponent();
        }
    }
}
