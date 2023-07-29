namespace McSystems.Presentation
{
    partial class RoomChooseForm
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
            this.grdAvailableRooms = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInMaintanance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAvailableRooms
            // 
            this.grdAvailableRooms.AllowUserToAddRows = false;
            this.grdAvailableRooms.AllowUserToDeleteRows = false;
            this.grdAvailableRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAvailableRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colCapacity,
            this.colInMaintanance});
            this.grdAvailableRooms.Location = new System.Drawing.Point(12, 12);
            this.grdAvailableRooms.MultiSelect = false;
            this.grdAvailableRooms.Name = "grdAvailableRooms";
            this.grdAvailableRooms.ReadOnly = true;
            this.grdAvailableRooms.RowHeadersWidth = 51;
            this.grdAvailableRooms.RowTemplate.Height = 29;
            this.grdAvailableRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAvailableRooms.Size = new System.Drawing.Size(431, 307);
            this.grdAvailableRooms.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(349, 325);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 29);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Seç";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Oda";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 125;
            // 
            // colCapacity
            // 
            this.colCapacity.DataPropertyName = "Capacity";
            this.colCapacity.HeaderText = "Kişi Sayısı";
            this.colCapacity.MinimumWidth = 6;
            this.colCapacity.Name = "colCapacity";
            this.colCapacity.ReadOnly = true;
            this.colCapacity.Width = 125;
            // 
            // colInMaintanance
            // 
            this.colInMaintanance.DataPropertyName = "Maintanance";
            this.colInMaintanance.HeaderText = "Durum";
            this.colInMaintanance.MinimumWidth = 6;
            this.colInMaintanance.Name = "colInMaintanance";
            this.colInMaintanance.ReadOnly = true;
            this.colInMaintanance.Width = 125;
            // 
            // RoomChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 371);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.grdAvailableRooms);
            this.Name = "RoomChooseForm";
            this.Text = "RoomChooseForm";
            this.Load += new System.EventHandler(this.RoomChooseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableRooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grdAvailableRooms;
        private Button btnSelect;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCapacity;
        private DataGridViewTextBoxColumn colInMaintanance;
    }
}