using McSystems.Business;
using McSystems.Customers;
using McSystems.DataAccess.Entities;
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
    public partial class NewReservationForm : Form
    {
        private RoomDto _selectedRoom;
        private CustomerService _customerService = new CustomerService();
        private ReservationService _reservationService= new ReservationService();
        private List<CustomerDto> customers=new List<CustomerDto>();
        private List<RoomDto> rooms= new List<RoomDto>();
        public NewReservationForm()
        {
            InitializeComponent();
        }

        private void btnGetAvailableRoom_Click(object sender, EventArgs e)
        {
            var reservation = new ReservationDto();
            var roomChooseForm = new RoomChooseForm(reservation.StartDate,reservation.EndDate);
            roomChooseForm.RoomReadyForReservation += RoomChooseForm_RoomReadyForReservation;
            roomChooseForm.Show();
        }

        private void RoomChooseForm_RoomReadyForReservation(RoomDto roomDto)
        {
            var room = new RoomDto()
            {
                Id = roomDto.Id,
                Capacity = roomDto.Capacity,
                Floor = roomDto.Floor,
                InMaintanance = roomDto.InMaintanance,
                Number = roomDto.Number,
                RoomType = roomDto.RoomType
            };
            rooms.Add(room);
            txtSelectedRoom.Text = roomDto.Name;
            txtSelectedRoom.Tag = roomDto.Id;
        }

        private void NewReservationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customerAddForm= new CustomerManagementForm();
            customerAddForm.CustomerReadyForReservation += CustomerAddForm_CustomerReadyForReservation;
            customerAddForm.Show();
        }

        private void CustomerAddForm_CustomerReadyForReservation(Customers.CustomerDto customerDto)
        {
            var customer = new CustomerDto()
            {
                Id = customerDto.Id,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                IdNumber = customerDto.IdNumber
            };
            
            customers.Add(customer);
            grdCustomers.DataSource = null;
            grdCustomers.DataSource=customers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var reserve = new ReservationDto()
                {
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    RoomId = (int)txtSelectedRoom.Tag,
                    EmployeeId = 1,


                };
                foreach (var item in customers)
                {
                    reserve.Customers.Add(item);
                }

                _reservationService.Creat(reserve);
                MessageBox.Show("Kayıt Başarılı");
                var list = new ReservationListForm();
                list.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Kaydedilemedi");
            }
        }
    }
}
