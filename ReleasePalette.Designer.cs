
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
         this.listViewItems = new System.Windows.Forms.ListView();
         this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.panelControls = new System.Windows.Forms.Panel();
         this.buttonOpen = new System.Windows.Forms.Button();
         this.buttonApply = new System.Windows.Forms.Button();
         this.labelMessage = new System.Windows.Forms.Label();
         this.buttonCopyToClipboard = new System.Windows.Forms.Button();
         this.buttonPasteFromClipboard = new System.Windows.Forms.Button();
         this.textValue = new System.Windows.Forms.TextBox();
         this.labelName = new System.Windows.Forms.Label();
         this.panelBrowser = new System.Windows.Forms.Panel();
         this.webBrowser = new System.Windows.Forms.WebBrowser();
         this.tableMain.SuspendLayout();
         this.panelItems.SuspendLayout();
         this.panelControls.SuspendLayout();
         this.panelBrowser.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableMain
         // 
         this.tableMain.ColumnCount = 2;
         this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableMain.Controls.Add(this.panelItems, 0, 0);
         this.tableMain.Controls.Add(this.panelControls, 0, 1);
         this.tableMain.Controls.Add(this.panelBrowser, 1, 0);
         this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableMain.Location = new System.Drawing.Point(0, 0);
         this.tableMain.Name = "tableMain";
         this.tableMain.RowCount = 2;
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
         this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
         this.tableMain.Size = new System.Drawing.Size(1128, 493);
         this.tableMain.TabIndex = 1;
         // 
         // panelItems
         // 
         this.panelItems.Controls.Add(this.listViewItems);
         this.panelItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelItems.Location = new System.Drawing.Point(3, 3);
         this.panelItems.Name = "panelItems";
         this.panelItems.Size = new System.Drawing.Size(558, 289);
         this.panelItems.TabIndex = 0;
         // 
         // listViewItems
         // 
         this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnValue});
         this.listViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewItems.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.listViewItems.FullRowSelect = true;
         this.listViewItems.GridLines = true;
         this.listViewItems.HideSelection = false;
         this.listViewItems.Location = new System.Drawing.Point(0, 0);
         this.listViewItems.MultiSelect = false;
         this.listViewItems.Name = "listViewItems";
         this.listViewItems.Size = new System.Drawing.Size(558, 289);
         this.listViewItems.TabIndex = 1;
         this.listViewItems.UseCompatibleStateImageBehavior = false;
         this.listViewItems.View = System.Windows.Forms.View.Details;
         this.listViewItems.SelectedIndexChanged += new System.EventHandler(this.listViewItems_SelectedIndexChanged);
         // 
         // columnName
         // 
         this.columnName.Text = "Name";
         // 
         // columnValue
         // 
         this.columnValue.Text = "Value";
         // 
         // panelControls
         // 
         this.panelControls.Controls.Add(this.buttonOpen);
         this.panelControls.Controls.Add(this.buttonApply);
         this.panelControls.Controls.Add(this.labelMessage);
         this.panelControls.Controls.Add(this.buttonCopyToClipboard);
         this.panelControls.Controls.Add(this.buttonPasteFromClipboard);
         this.panelControls.Controls.Add(this.textValue);
         this.panelControls.Controls.Add(this.labelName);
         this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelControls.Location = new System.Drawing.Point(3, 298);
         this.panelControls.Name = "panelControls";
         this.panelControls.Size = new System.Drawing.Size(558, 192);
         this.panelControls.TabIndex = 1;
         // 
         // buttonOpen
         // 
         this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonOpen.Location = new System.Drawing.Point(414, 76);
         this.buttonOpen.Name = "buttonOpen";
         this.buttonOpen.Size = new System.Drawing.Size(129, 23);
         this.buttonOpen.TabIndex = 6;
         this.buttonOpen.Text = "Open";
         this.buttonOpen.UseVisualStyleBackColor = true;
         this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
         // 
         // buttonApply
         // 
         this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonApply.Location = new System.Drawing.Point(279, 76);
         this.buttonApply.Name = "buttonApply";
         this.buttonApply.Size = new System.Drawing.Size(129, 23);
         this.buttonApply.TabIndex = 5;
         this.buttonApply.Text = "Apply";
         this.buttonApply.UseVisualStyleBackColor = true;
         this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
         // 
         // labelMessage
         // 
         this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelMessage.Location = new System.Drawing.Point(9, 160);
         this.labelMessage.Name = "labelMessage";
         this.labelMessage.Size = new System.Drawing.Size(540, 23);
         this.labelMessage.TabIndex = 4;
         this.labelMessage.Text = "Ready";
         this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // buttonCopyToClipboard
         // 
         this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonCopyToClipboard.Location = new System.Drawing.Point(144, 76);
         this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
         this.buttonCopyToClipboard.Size = new System.Drawing.Size(129, 23);
         this.buttonCopyToClipboard.TabIndex = 3;
         this.buttonCopyToClipboard.Text = "Copy To Clipboard";
         this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
         this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonPasteToClipboard_Click);
         // 
         // buttonPasteFromClipboard
         // 
         this.buttonPasteFromClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonPasteFromClipboard.Location = new System.Drawing.Point(9, 76);
         this.buttonPasteFromClipboard.Name = "buttonPasteFromClipboard";
         this.buttonPasteFromClipboard.Size = new System.Drawing.Size(129, 23);
         this.buttonPasteFromClipboard.TabIndex = 2;
         this.buttonPasteFromClipboard.Text = "Paste From Clipboard";
         this.buttonPasteFromClipboard.UseVisualStyleBackColor = true;
         this.buttonPasteFromClipboard.Click += new System.EventHandler(this.buttonPasteFromClipboard_Click);
         // 
         // textValue
         // 
         this.textValue.AllowDrop = true;
         this.textValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textValue.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textValue.Location = new System.Drawing.Point(9, 26);
         this.textValue.Name = "textValue";
         this.textValue.Size = new System.Drawing.Size(540, 26);
         this.textValue.TabIndex = 1;
         this.textValue.Text = "<value>";
         this.textValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.textValue.TextChanged += new System.EventHandler(this.textValue_TextChanged);
         this.textValue.DragDrop += new System.Windows.Forms.DragEventHandler(this.textValue_DragDrop);
         this.textValue.DragOver += new System.Windows.Forms.DragEventHandler(this.textValue_DragOver);
         // 
         // labelName
         // 
         this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelName.Location = new System.Drawing.Point(9, 0);
         this.labelName.Name = "labelName";
         this.labelName.Size = new System.Drawing.Size(540, 23);
         this.labelName.TabIndex = 0;
         this.labelName.Text = "<name>";
         this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // panelBrowser
         // 
         this.panelBrowser.Controls.Add(this.webBrowser);
         this.panelBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelBrowser.Location = new System.Drawing.Point(567, 3);
         this.panelBrowser.Name = "panelBrowser";
         this.tableMain.SetRowSpan(this.panelBrowser, 2);
         this.panelBrowser.Size = new System.Drawing.Size(558, 487);
         this.panelBrowser.TabIndex = 2;
         // 
         // webBrowser
         // 
         this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.webBrowser.Location = new System.Drawing.Point(0, 0);
         this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.webBrowser.Name = "webBrowser";
         this.webBrowser.Size = new System.Drawing.Size(558, 487);
         this.webBrowser.TabIndex = 0;
         this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
         // 
         // ReleasePalette
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1128, 493);
         this.Controls.Add(this.tableMain);
         this.Name = "ReleasePalette";
         this.Text = "Release Palette";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReleasePalette_FormClosing);
         this.Load += new System.EventHandler(this.ReleasePalette_Load);
         this.tableMain.ResumeLayout(false);
         this.panelItems.ResumeLayout(false);
         this.panelControls.ResumeLayout(false);
         this.panelControls.PerformLayout();
         this.panelBrowser.ResumeLayout(false);
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
      private System.Windows.Forms.Button buttonCopyToClipboard;
      private System.Windows.Forms.Button buttonPasteFromClipboard;
      private System.Windows.Forms.Label labelMessage;
      private System.Windows.Forms.Panel panelBrowser;
      private System.Windows.Forms.WebBrowser webBrowser;
      private System.Windows.Forms.Button buttonApply;
      private System.Windows.Forms.Button buttonOpen;
   }
}

