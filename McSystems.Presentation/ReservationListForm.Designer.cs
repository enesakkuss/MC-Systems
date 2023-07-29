namespace McSystems.Presentation
{
    partial class ReservationListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdReservationListForm = new System.Windows.Forms.DataGridView();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdReservationListForm)).BeginInit();
            this.SuspendLayout();
            // 
            // grdReservationListForm
            // 
            this.grdReservationListForm.AllowUserToAddRows = false;
            this.grdReservationListForm.AllowUserToDeleteRows = false;
            this.grdReservationListForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReservationListForm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoom});
            this.grdReservationListForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReservationListForm.Location = new System.Drawing.Point(0, 0);
            this.grdReservationListForm.Name = "grdReservationListForm";
            this.grdReservationListForm.ReadOnly = true;
            this.grdReservationListForm.RowHeadersWidth = 51;
            this.grdReservationListForm.RowTemplate.Height = 29;
            this.grdReservationListForm.Size = new System.Drawing.Size(800, 450);
            this.grdReservationListForm.TabIndex = 0;
            this.grdReservationListForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdReservationListForm_CellContentClick);
            // 
            // colRoom
            // 
            this.colRoom.DataPropertyName = "Name";
            this.colRoom.HeaderText = "Oda Adı";
            this.colRoom.MinimumWidth = 6;
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            this.colRoom.Width = 125;
            // 
            // ReservationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdReservationListForm);
            this.Name = "ReservationListForm";
            this.Text = "CustomerListForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdReservationListForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grdReservationListForm;
        private DataGridViewTextBoxColumn colRoom;
    }
}