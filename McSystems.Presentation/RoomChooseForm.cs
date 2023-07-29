using McSystems.Business;
using McSystems.DataAccess;
using McSystems.Reservations;
using McSystems.Rooms;
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
    public partial class RoomChooseForm : Form
    {
        private ReservationService _reservationService = new ReservationService();
        private DateTime _startDate;
        private DateTime _endDate;
        public RoomChooseForm(DateTime startDate,DateTime endDate)
        {
            InitializeComponent();
            _startDate = startDate;
            _endDate = endDate;
            grdAvailableRooms.AutoGenerateColumns = false;
        }

        private void RoomChooseForm_Load(object sender, EventArgs e)
        {
            var context = new McSystemsContext();

            var room = _reservationService.SearchAvailableRoom(_startDate, _endDate);
            grdAvailableRooms.DataSource=room;
        }

        public event RoomAddForReservationEventHandler RoomReadyForReservation;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(grdAvailableRooms.SelectedRows.Count>0)
            {
                var selectedRoom=(RoomDto)grdAvailableRooms.SelectedRows[0].DataBoundItem;

                RoomReadyForReservation(selectedRoom);
            }
        }
        


    }
}
