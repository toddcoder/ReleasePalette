
namespace ReleasePalette
{
   partial class Release
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
         this.labelRelease = new System.Windows.Forms.Label();
         this.textRelease = new System.Windows.Forms.TextBox();
         this.buttonOk = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.labelState = new System.Windows.Forms.Label();
         this.listReleases = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // labelRelease
         // 
         this.labelRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelRelease.Location = new System.Drawing.Point(12, 188);
         this.labelRelease.Name = "labelRelease";
         this.labelRelease.Size = new System.Drawing.Size(447, 19);
         this.labelRelease.TabIndex = 0;
         this.labelRelease.Text = "Release";
         this.labelRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // textRelease
         // 
         this.textRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textRelease.Location = new System.Drawing.Point(15, 210);
         this.textRelease.Name = "textRelease";
         this.textRelease.Size = new System.Drawing.Size(444, 20);
         this.textRelease.TabIndex = 1;
         this.textRelease.TextChanged += new System.EventHandler(this.textRelease_TextChanged);
         // 
         // buttonOk
         // 
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Enabled = false;
         this.buttonOk.Location = new System.Drawing.Point(303, 259);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 2;
         this.buttonOk.Text = "OK";
         this.buttonOk.UseVisualStyleBackColor = true;
         this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(384, 259);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 3;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
         // 
         // labelState
         // 
         this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelState.BackColor = System.Drawing.Color.Red;
         this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelState.ForeColor = System.Drawing.Color.White;
         this.labelState.Location = new System.Drawing.Point(15, 233);
         this.labelState.Name = "labelState";
         this.labelState.Size = new System.Drawing.Size(444, 23);
         this.labelState.TabIndex = 4;
         this.labelState.Text = "Invalid";
         this.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // listReleases
         // 
         this.listReleases.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listReleases.FormattingEnabled = true;
         this.listReleases.ItemHeight = 19;
         this.listReleases.Location = new System.Drawing.Point(12, 12);
         this.listReleases.Name = "listReleases";
         this.listReleases.Size = new System.Drawing.Size(447, 156);
         this.listReleases.TabIndex = 5;
         this.listReleases.SelectedIndexChanged += new System.EventHandler(this.listReleases_SelectedIndexChanged);
         this.listReleases.DoubleClick += new System.EventHandler(this.listReleases_DoubleClick);
         // 
         // Release
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(471, 291);
         this.ControlBox = false;
         this.Controls.Add(this.listReleases);
         this.Controls.Add(this.labelState);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.textRelease);
         this.Controls.Add(this.labelRelease);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Release";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Release";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Release_FormClosing);
         this.Load += new System.EventHandler(this.Release_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelRelease;
      private System.Windows.Forms.TextBox textRelease;
      private System.Windows.Forms.Button buttonOk;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label labelState;
      private System.Windows.Forms.ListBox listReleases;
   }
}