namespace CSharpGUIPractices
{
  partial class Form1
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
      this.studentUserControl1 = new CSharpGUIPractices.StudentUserControl();
      this.btnTestSaving = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // studentUserControl1
      // 
      this.studentUserControl1.Location = new System.Drawing.Point(174, 71);
      this.studentUserControl1.Name = "studentUserControl1";
      this.studentUserControl1.Size = new System.Drawing.Size(381, 277);
      this.studentUserControl1.TabIndex = 0;
      // 
      // btnTestSaving
      // 
      this.btnTestSaving.Location = new System.Drawing.Point(12, 12);
      this.btnTestSaving.Name = "btnTestSaving";
      this.btnTestSaving.Size = new System.Drawing.Size(75, 23);
      this.btnTestSaving.TabIndex = 1;
      this.btnTestSaving.Text = "Test Saving";
      this.btnTestSaving.UseVisualStyleBackColor = true;
      this.btnTestSaving.Click += new System.EventHandler(this.btnTestSaving_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.btnTestSaving);
      this.Controls.Add(this.studentUserControl1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

        #endregion

        private StudentUserControl studentUserControl1;
        private System.Windows.Forms.Button btnTestSaving;
    }
}

