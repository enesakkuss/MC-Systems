using McSystems.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McSystems.Presentation
{
    public partial class ReservationListForm : Form
    {
        private ReservationService _service=new ReservationService();
        public ReservationListForm()
        {
            InitializeComponent();
            grdReservationListForm.DataSource = _service.GetAll();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            grdReservationListForm.DataSource = _service.GetAll();
        }

        private void grdReservationListForm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
