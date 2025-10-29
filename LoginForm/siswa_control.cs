using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public partial class siswa_control : Component
    {
        public siswa_control()
        {
            InitializeComponent();
        }

        public siswa_control(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
