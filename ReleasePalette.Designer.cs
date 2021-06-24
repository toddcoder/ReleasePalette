
namespace ReleasePalette
{
   partial class ReleasePalette
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
         this.panelItems = new System.Windows.Forms.Panel();
         this.panelControls = new System.Windows.Forms.Panel();
         this.listViewItems = new System.Windows.Forms.ListView();
         this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.labelName = new System.Windows.Forms.Label();
         this.textValue = new System.Windows.Forms.TextBox();
         this.buttonPasteFromClipboard = new System.Windows.Forms.Button();
         this.buttonPasteToClipboard = new System.Windows.Forms.Button();
         this.tableMain.SuspendLayout();
         this.panelItems.SuspendLayout();
         this.panelControls.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableMain
         // 
         this.tableMain.ColumnCount = 1;
         this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableMain.Controls.Add(this.panelItems, 0, 0);
         this.tableMain.Controls.Add(this.panelControls, 0, 1);
         this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableMain.Location = new System.Drawing.Point(0, 0);
         this.tableMain.Name = "tableMain";
         this.tableMain.RowCount = 2;
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
         this.tableMain.Size = new System.Drawing.Size(800, 450);
         this.tableMain.TabIndex = 1;
         // 
         // panelItems
         // 
         this.panelItems.Controls.Add(this.listViewItems);
         this.panelItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelItems.Location = new System.Drawing.Point(3, 3);
         this.panelItems.Name = "panelItems";
         this.panelItems.Size = new System.Drawing.Size(794, 264);
         this.panelItems.TabIndex = 0;
         // 
         // panelControls
         // 
         this.panelControls.Controls.Add(this.buttonPasteToClipboard);
         this.panelControls.Controls.Add(this.buttonPasteFromClipboard);
         this.panelControls.Controls.Add(this.textValue);
         this.panelControls.Controls.Add(this.labelName);
         this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelControls.Location = new System.Drawing.Point(3, 273);
         this.panelControls.Name = "panelControls";
         this.panelControls.Size = new System.Drawing.Size(794, 174);
         this.panelControls.TabIndex = 1;
         // 
         // listViewItems
         // 
         this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});
         this.listViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewItems.HideSelection = false;
         this.listViewItems.Location = new System.Drawing.Point(0, 0);
         this.listViewItems.Name = "listViewItems";
         this.listViewItems.Size = new System.Drawing.Size(794, 264);
         this.listViewItems.TabIndex = 1;
         this.listViewItems.UseCompatibleStateImageBehavior = false;
         this.listViewItems.View = System.Windows.Forms.View.Details;
         // 
         // columnName
         // 
         this.columnName.Text = "Name";
         // 
         // columnValue
         // 
         this.columnValue.Text = "Value";
         // 
         // labelName
         // 
         this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelName.Location = new System.Drawing.Point(9, 0);
         this.labelName.Name = "labelName";
         this.labelName.Size = new System.Drawing.Size(776, 23);
         this.labelName.TabIndex = 0;
         this.labelName.Text = "<name>";
         this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // textValue
         // 
         this.textValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textValue.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textValue.Location = new System.Drawing.Point(9, 26);
         this.textValue.Name = "textValue";
         this.textValue.Size = new System.Drawing.Size(776, 26);
         this.textValue.TabIndex = 1;
         this.textValue.Text = "<value>";
         this.textValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // buttonPasteFromClipboard
         // 
         this.buttonPasteFromClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonPasteFromClipboard.Location = new System.Drawing.Point(9, 142);
         this.buttonPasteFromClipboard.Name = "buttonPasteFromClipboard";
         this.buttonPasteFromClipboard.Size = new System.Drawing.Size(129, 23);
         this.buttonPasteFromClipboard.TabIndex = 2;
         this.buttonPasteFromClipboard.Text = "Paste From Clipboard";
         this.buttonPasteFromClipboard.UseVisualStyleBackColor = true;
         // 
         // buttonPasteToClipboard
         // 
         this.buttonPasteToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonPasteToClipboard.Location = new System.Drawing.Point(144, 142);
         this.buttonPasteToClipboard.Name = "buttonPasteToClipboard";
         this.buttonPasteToClipboard.Size = new System.Drawing.Size(129, 23);
         this.buttonPasteToClipboard.TabIndex = 3;
         this.buttonPasteToClipboard.Text = "Paste To Clipboard";
         this.buttonPasteToClipboard.UseVisualStyleBackColor = true;
         // 
         // ReleasePalette
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.tableMain);
         this.Name = "ReleasePalette";
         this.Text = "Release Palette";
         this.Load += new System.EventHandler(this.ReleasePalette_Load);
         this.tableMain.ResumeLayout(false);
         this.panelItems.ResumeLayout(false);
         this.panelControls.ResumeLayout(false);
         this.panelControls.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableMain;
      private System.Windows.Forms.Panel panelItems;
      private System.Windows.Forms.ListView listViewItems;
      private System.Windows.Forms.ColumnHeader columnName;
      private System.Windows.Forms.ColumnHeader columnValue;
      private System.Windows.Forms.Panel panelControls;
      private System.Windows.Forms.Label labelName;
      private System.Windows.Forms.TextBox textValue;
      private System.Windows.Forms.Button buttonPasteToClipboard;
      private System.Windows.Forms.Button buttonPasteFromClipboard;
   }
}

