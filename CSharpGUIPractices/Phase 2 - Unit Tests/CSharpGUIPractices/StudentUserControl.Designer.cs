namespace CSharpGUIPractices
{
  partial class StudentUserControl
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
      this.btnAdd = new System.Windows.Forms.Button();
      this.tbxFirstName = new System.Windows.Forms.TextBox();
      this.tbxLastName = new System.Windows.Forms.TextBox();
      this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
      this.lblFirstName = new System.Windows.Forms.Label();
      this.lblLastName = new System.Windows.Forms.Label();
      this.lblBirthDate = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(219, 238);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 0;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
      // 
      // tbxFirstName
      // 
      this.tbxFirstName.Location = new System.Drawing.Point(163, 136);
      this.tbxFirstName.Name = "tbxFirstName";
      this.tbxFirstName.Size = new System.Drawing.Size(200, 20);
      this.tbxFirstName.TabIndex = 1;
      // 
      // tbxLastName
      // 
      this.tbxLastName.Location = new System.Drawing.Point(163, 162);
      this.tbxLastName.Name = "tbxLastName";
      this.tbxLastName.Size = new System.Drawing.Size(200, 20);
      this.tbxLastName.TabIndex = 2;
      // 
      // dtpBirthDate
      // 
      this.dtpBirthDate.Location = new System.Drawing.Point(163, 188);
      this.dtpBirthDate.Name = "dtpBirthDate";
      this.dtpBirthDate.Size = new System.Drawing.Size(200, 20);
      this.dtpBirthDate.TabIndex = 3;
      // 
      // lblFirstName
      // 
      this.lblFirstName.AutoSize = true;
      this.lblFirstName.Location = new System.Drawing.Point(100, 139);
      this.lblFirstName.Name = "lblFirstName";
      this.lblFirstName.Size = new System.Drawing.Size(57, 13);
      this.lblFirstName.TabIndex = 4;
      this.lblFirstName.Text = "First Name";
      // 
      // lblLastName
      // 
      this.lblLastName.AutoSize = true;
      this.lblLastName.Location = new System.Drawing.Point(99, 165);
      this.lblLastName.Name = "lblLastName";
      this.lblLastName.Size = new System.Drawing.Size(58, 13);
      this.lblLastName.TabIndex = 5;
      this.lblLastName.Text = "Last Name";
      // 
      // lblBirthDate
      // 
      this.lblBirthDate.AutoSize = true;
      this.lblBirthDate.Location = new System.Drawing.Point(106, 194);
      this.lblBirthDate.Name = "lblBirthDate";
      this.lblBirthDate.Size = new System.Drawing.Size(51, 13);
      this.lblBirthDate.TabIndex = 6;
      this.lblBirthDate.Text = "BirthDate";
      // 
      // StudentUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblBirthDate);
      this.Controls.Add(this.lblLastName);
      this.Controls.Add(this.lblFirstName);
      this.Controls.Add(this.dtpBirthDate);
      this.Controls.Add(this.tbxLastName);
      this.Controls.Add(this.tbxFirstName);
      this.Controls.Add(this.btnAdd);
      this.Name = "StudentUserControl";
      this.Size = new System.Drawing.Size(548, 374);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblBirthDate;
    }
}
