using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevAppMAXI
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BoutiqueDataSet.tb_cliente' table. You can move, or remove it, as needed.
            this.tb_clienteTableAdapter.Fill(this.BoutiqueDataSet.tb_cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
