
namespace ReleasePalette
{
   partial class Compare
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
         this.tableMain = new System.Windows.Forms.TableLayoutPanel();
         this.labelRightMessage = new System.Windows.Forms.Label();
         this.panelLeftTop = new System.Windows.Forms.Panel();
         this.listLeft = new System.Windows.Forms.ListBox();
         this.panelRightTop = new System.Windows.Forms.Panel();
         this.listRight = new System.Windows.Forms.ListBox();
         this.panelLeftBottom = new System.Windows.Forms.Panel();
         this.buttonRevertLeft = new System.Windows.Forms.Button();
         this.buttonCompareLeft = new System.Windows.Forms.Button();
         this.buttonCopyLeft = new System.Windows.Forms.Button();
         this.buttonPasteLeft = new System.Windows.Forms.Button();
         this.panelRightBottom = new System.Windows.Forms.Panel();
         this.buttonRevertRight = new System.Windows.Forms.Button();
         this.buttonCompareRight = new System.Windows.Forms.Button();
         this.buttonCopyRight = new System.Windows.Forms.Button();
         this.buttonPasteRight = new System.Windows.Forms.Button();
         this.labelLeftMessage = new System.Windows.Forms.Label();
         this.tableMain.SuspendLayout();
         this.panelLeftTop.SuspendLayout();
         this.panelRightTop.SuspendLayout();
         this.panelLeftBottom.SuspendLayout();
         this.panelRightBottom.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableMain
         // 
         this.tableMain.ColumnCount = 2;
         this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableMain.Controls.Add(this.labelRightMessage, 1, 2);
         this.tableMain.Controls.Add(this.panelLeftTop, 0, 0);
         this.tableMain.Controls.Add(this.panelRightTop, 1, 0);
         this.tableMain.Controls.Add(this.panelLeftBottom, 0, 1);
         this.tableMain.Controls.Add(this.panelRightBottom, 1, 1);
         this.tableMain.Controls.Add(this.labelLeftMessage, 0, 2);
         this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableMain.Location = new System.Drawing.Point(0, 0);
         this.tableMain.Name = "tableMain";
         this.tableMain.RowCount = 3;
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
         this.tableMain.Size = new System.Drawing.Size(800, 450);
         this.tableMain.TabIndex = 0;
         // 
         // labelRightMessage
         // 
         this.labelRightMessage.AutoSize = true;
         this.labelRightMessage.Dock = System.Windows.Forms.DockStyle.Fill;
         this.labelRightMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelRightMessage.Location = new System.Drawing.Point(403, 405);
         this.labelRightMessage.Name = "labelRightMessage";
         this.labelRightMessage.Size = new System.Drawing.Size(394, 45);
         this.labelRightMessage.TabIndex = 5;
         this.labelRightMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // panelLeftTop
         // 
         this.panelLeftTop.Controls.Add(this.listLeft);
         this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelLeftTop.Location = new System.Drawing.Point(3, 3);
         this.panelLeftTop.Name = "panelLeftTop";
         this.panelLeftTop.Size = new System.Drawing.Size(394, 354);
         this.panelLeftTop.TabIndex = 0;
         // 
         // listLeft
         // 
         this.listLeft.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listLeft.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listLeft.FormattingEnabled = true;
         this.listLeft.ItemHeight = 19;
         this.listLeft.Location = new System.Drawing.Point(0, 0);
         this.listLeft.Name = "listLeft";
         this.listLeft.Size = new System.Drawing.Size(394, 354);
         this.listLeft.TabIndex = 0;
         this.listLeft.SelectedIndexChanged += new System.EventHandler(this.listLeft_SelectedIndexChanged);
         // 
         // panelRightTop
         // 
         this.panelRightTop.Controls.Add(this.listRight);
         this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelRightTop.Location = new System.Drawing.Point(403, 3);
         this.panelRightTop.Name = "panelRightTop";
         this.panelRightTop.Size = new System.Drawing.Size(394, 354);
         this.panelRightTop.TabIndex = 1;
         // 
         // listRight
         // 
         this.listRight.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listRight.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listRight.FormattingEnabled = true;
         this.listRight.ItemHeight = 19;
         this.listRight.Location = new System.Drawing.Point(0, 0);
         this.listRight.Name = "listRight";
         this.listRight.Size = new System.Drawing.Size(394, 354);
         this.listRight.TabIndex = 0;
         this.listRight.SelectedIndexChanged += new System.EventHandler(this.listRight_SelectedIndexChanged);
         // 
         // panelLeftBottom
         // 
         this.panelLeftBottom.Controls.Add(this.buttonRevertLeft);
         this.panelLeftBottom.Controls.Add(this.buttonCompareLeft);
         this.panelLeftBottom.Controls.Add(this.buttonCopyLeft);
         this.panelLeftBottom.Controls.Add(this.buttonPasteLeft);
         this.panelLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelLeftBottom.Location = new System.Drawing.Point(3, 363);
         this.panelLeftBottom.Name = "panelLeftBottom";
         this.panelLeftBottom.Size = new System.Drawing.Size(394, 39);
         this.panelLeftBottom.TabIndex = 2;
         // 
         // buttonRevertLeft
         // 
         this.buttonRevertLeft.Location = new System.Drawing.Point(297, 7);
         this.buttonRevertLeft.Name = "buttonRevertLeft";
         this.buttonRevertLeft.Size = new System.Drawing.Size(75, 23);
         this.buttonRevertLeft.TabIndex = 3;
         this.buttonRevertLeft.Text = "Revert";
         this.buttonRevertLeft.UseVisualStyleBackColor = true;
         this.buttonRevertLeft.Click += new System.EventHandler(this.buttonRevertLeft_Click);
         // 
         // buttonCompareLeft
         // 
         this.buttonCompareLeft.Location = new System.Drawing.Point(184, 7);
         this.buttonCompareLeft.Name = "buttonCompareLeft";
         this.buttonCompareLeft.Size = new System.Drawing.Size(107, 23);
         this.buttonCompareLeft.TabIndex = 2;
         this.buttonCompareLeft.Text = "Compare to Right";
         this.buttonCompareLeft.UseVisualStyleBackColor = true;
         this.buttonCompareLeft.Click += new System.EventHandler(this.buttonCompareLeft_Click);
         // 
         // buttonCopyLeft
         // 
         this.buttonCopyLeft.Location = new System.Drawing.Point(103, 7);
         this.buttonCopyLeft.Name = "buttonCopyLeft";
         this.buttonCopyLeft.Size = new System.Drawing.Size(75, 23);
         this.buttonCopyLeft.TabIndex = 1;
         this.buttonCopyLeft.Text = "Copy";
         this.buttonCopyLeft.UseVisualStyleBackColor = true;
         this.buttonCopyLeft.Click += new System.EventHandler(this.buttonCopyLeft_Click);
         // 
         // buttonPasteLeft
         // 
         this.buttonPasteLeft.Location = new System.Drawing.Point(22, 7);
         this.buttonPasteLeft.Name = "buttonPasteLeft";
         this.buttonPasteLeft.Size = new System.Drawing.Size(75, 23);
         this.buttonPasteLeft.TabIndex = 0;
         this.buttonPasteLeft.Text = "Paste";
         this.buttonPasteLeft.UseVisualStyleBackColor = true;
         this.buttonPasteLeft.Click += new System.EventHandler(this.buttonPasteLeft_Click);
         // 
         // panelRightBottom
         // 
         this.panelRightBottom.Controls.Add(this.buttonRevertRight);
         this.panelRightBottom.Controls.Add(this.buttonCompareRight);
         this.panelRightBottom.Controls.Add(this.buttonCopyRight);
         this.panelRightBottom.Controls.Add(this.buttonPasteRight);
         this.panelRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelRightBottom.Location = new System.Drawing.Point(403, 363);
         this.panelRightBottom.Name = "panelRightBottom";
         this.panelRightBottom.Size = new System.Drawing.Size(394, 39);
         this.panelRightBottom.TabIndex = 3;
         // 
         // buttonRevertRight
         // 
         this.buttonRevertRight.Location = new System.Drawing.Point(297, 7);
         this.buttonRevertRight.Name = "buttonRevertRight";
         this.buttonRevertRight.Size = new System.Drawing.Size(75, 23);
         this.buttonRevertRight.TabIndex = 7;
         this.buttonRevertRight.Text = "Revert";
         this.buttonRevertRight.UseVisualStyleBackColor = true;
         this.buttonRevertRight.Click += new System.EventHandler(this.buttonRevertRight_Click);
         // 
         // buttonCompareRight
         // 
         this.buttonCompareRight.Location = new System.Drawing.Point(184, 7);
         this.buttonCompareRight.Name = "buttonCompareRight";
         this.buttonCompareRight.Size = new System.Drawing.Size(107, 23);
         this.buttonCompareRight.TabIndex = 6;
         this.buttonCompareRight.Text = "Compare to Left";
         this.buttonCompareRight.UseVisualStyleBackColor = true;
         this.buttonCompareRight.Click += new System.EventHandler(this.buttonCompareRight_Click);
         // 
         // buttonCopyRight
         // 
         this.buttonCopyRight.Location = new System.Drawing.Point(103, 7);
         this.buttonCopyRight.Name = "buttonCopyRight";
         this.buttonCopyRight.Size = new System.Drawing.Size(75, 23);
         this.buttonCopyRight.TabIndex = 5;
         this.buttonCopyRight.Text = "Copy";
         this.buttonCopyRight.UseVisualStyleBackColor = true;
         this.buttonCopyRight.Click += new System.EventHandler(this.buttonCopyRight_Click);
         // 
         // buttonPasteRight
         // 
         this.buttonPasteRight.Location = new System.Drawing.Point(22, 7);
         this.buttonPasteRight.Name = "buttonPasteRight";
         this.buttonPasteRight.Size = new System.Drawing.Size(75, 23);
         this.buttonPasteRight.TabIndex = 4;
         this.buttonPasteRight.Text = "Paste";
         this.buttonPasteRight.UseVisualStyleBackColor = true;
         this.buttonPasteRight.Click += new System.EventHandler(this.buttonPasteRight_Click);
         // 
         // labelLeftMessage
         // 
         this.labelLeftMessage.AutoSize = true;
         this.labelLeftMessage.Dock = System.Windows.Forms.DockStyle.Fill;
         this.labelLeftMessage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelLeftMessage.Location = new System.Drawing.Point(3, 405);
         this.labelLeftMessage.Name = "labelLeftMessage";
         this.labelLeftMessage.Size = new System.Drawing.Size(394, 45);
         this.labelLeftMessage.TabIndex = 4;
         this.labelLeftMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // Compare
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.tableMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Compare";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Compare";
         this.tableMain.ResumeLayout(false);
         this.tableMain.PerformLayout();
         this.panelLeftTop.ResumeLayout(false);
         this.panelRightTop.ResumeLayout(false);
         this.panelLeftBottom.ResumeLayout(false);
         this.panelRightBottom.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableMain;
      private System.Windows.Forms.Panel panelLeftTop;
      private System.Windows.Forms.Panel panelRightTop;
      private System.Windows.Forms.Panel panelLeftBottom;
      private System.Windows.Forms.Panel panelRightBottom;
      private System.Windows.Forms.ListBox listLeft;
      private System.Windows.Forms.ListBox listRight;
      private System.Windows.Forms.Button buttonCopyLeft;
      private System.Windows.Forms.Button buttonPasteLeft;
      private System.Windows.Forms.Button buttonRevertLeft;
      private System.Windows.Forms.Button buttonCompareLeft;
      private System.Windows.Forms.Button buttonRevertRight;
      private System.Windows.Forms.Button buttonCompareRight;
      private System.Windows.Forms.Button buttonCopyRight;
      private System.Windows.Forms.Button buttonPasteRight;
      private System.Windows.Forms.Label labelRightMessage;
      private System.Windows.Forms.Label labelLeftMessage;
   }
}