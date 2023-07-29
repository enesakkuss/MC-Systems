using McSystems.Business;
using McSystems.Customers;
using McSystems.DataAccess;
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
    public partial class CustomerManagementForm : Form
    {
        private CustomerService _customerService = new CustomerService();
        private List<CustomerDto> _customerForReservation= new List<CustomerDto>();
        public CustomerManagementForm()
        {
            InitializeComponent();
            grdCustomerList.AutoGenerateColumns = false;
        }

        private void txtSearchIdentityNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var customer=_customerService.SearcCustomer(txtSearchIdentityNumber.Text, txtSearchName.Text, txtSearchLastName.Text);
            grdCustomerList.DataSource = customer;
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            var context = new McSystemsContext();
            cmbCountry.DataSource = context.Countries.ToList();
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "Id";

            cmbGender.DataSource = Enum.GetNames<Gender>();
            cmbGender.DataSource = Enum.GetValues<Gender>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var context=new McSystemsContext();

            try
            {
                var customer = new CustomerDto();
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.IdNumber = txtIdNumber.Text;
                customer.CountryId = (int)cmbCountry.SelectedValue;
                customer.PhoneNumber = txtPhone.Text;
                customer.EmailAdress = txtMail.Text;
                customer.Gender = (Gender)cmbGender.SelectedValue;
                _customerService.Add(customer);

                MessageBox.Show("Kayıt Başarılı");
            }

            catch (Exception )
            {
                MessageBox.Show("Kaydedilemedi");
            }
        }

        public event CustomerAddForReservationEventHandler CustomerReadyForReservation;
        private void btnAddCustomersForReservation_Click(object sender, EventArgs e)
        {
            var customer = (CustomerDto)grdCustomerList.SelectedRows[0].DataBoundItem;
            
            CustomerReadyForReservation(customer);
        }

        private void Customer_CustomerReadyForReservation(CustomerDto customerDto)
        {
            
        }
    }
}
