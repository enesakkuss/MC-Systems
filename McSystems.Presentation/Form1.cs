namespace McSystems.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rezervasyonYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newReservationForm = new NewReservationForm();
            newReservationForm.Show();
        }

        private void rezervasyonListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = new ReservationListForm();
            res.Show();
        }
    }
}