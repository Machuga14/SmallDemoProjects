namespace CSharpGUIUnitTest
{
  partial class MyFormThatIWantToTest
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
      this.tbxValidatesOnFocusLeave = new System.Windows.Forms.TextBox();
      this.tbxTheSecond = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // tbxValidatesOnFocusLeave
      // 
      this.tbxValidatesOnFocusLeave.Location = new System.Drawing.Point(215, 119);
      this.tbxValidatesOnFocusLeave.Name = "tbxValidatesOnFocusLeave";
      this.tbxValidatesOnFocusLeave.Size = new System.Drawing.Size(271, 20);
      this.tbxValidatesOnFocusLeave.TabIndex = 0;
      this.tbxValidatesOnFocusLeave.Enter += new System.EventHandler(this.tbxValidatesOnFocusLeave_Enter);
      this.tbxValidatesOnFocusLeave.Leave += new System.EventHandler(this.tbxValidatesOnFocusLeave_Leave);
      // 
      // tbxTheSecond
      // 
      this.tbxTheSecond.Location = new System.Drawing.Point(215, 145);
      this.tbxTheSecond.Name = "tbxTheSecond";
      this.tbxTheSecond.Size = new System.Drawing.Size(271, 20);
      this.tbxTheSecond.TabIndex = 1;
      // 
      // MyFormThatIWantToTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tbxTheSecond);
      this.Controls.Add(this.tbxValidatesOnFocusLeave);
      this.Name = "MyFormThatIWantToTest";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        public System.Windows.Forms.TextBox tbxValidatesOnFocusLeave;
        public System.Windows.Forms.TextBox tbxTheSecond;
    }
}

