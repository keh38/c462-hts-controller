namespace Turandot_Editor
{
    partial class InteractiveControlGridView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Channel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Property = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Expr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 21;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Channel,
            this.Property,
            this.Expr});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowHeadersWidth = 20;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(368, 203);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.propGridView_CellValueChanged);
            this.dataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView_CurrentCellDirtyStateChanged);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            this.dataGridView.Leave += new System.EventHandler(this.dataGridView_Leave);
            this.dataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseUp);
            // 
            // Channel
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Channel.DefaultCellStyle = dataGridViewCellStyle2;
            this.Channel.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Channel.HeaderText = "Channel";
            this.Channel.Name = "Channel";
            this.Channel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Channel.Width = 75;
            // 
            // Property
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Property.DefaultCellStyle = dataGridViewCellStyle3;
            this.Property.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Property.HeaderText = "Property";
            this.Property.Items.AddRange(new object[] {
            "",
            "true"});
            this.Property.Name = "Property";
            this.Property.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Property.Width = 150;
            // 
            // Expr
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Expr.DefaultCellStyle = dataGridViewCellStyle4;
            this.Expr.HeaderText = "Expression";
            this.Expr.Name = "Expr";
            this.Expr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NestedPropertyGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "NestedPropertyGridView";
            this.Size = new System.Drawing.Size(363, 209);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewComboBoxColumn Channel;
        private System.Windows.Forms.DataGridViewComboBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expr;
    }
}
