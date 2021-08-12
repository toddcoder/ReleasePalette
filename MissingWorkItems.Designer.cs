
namespace ReleasePalette
{
   partial class MissingWorkItems
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
         this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
         this.viewMissing = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.panelBottom = new System.Windows.Forms.Panel();
         this.webProgress = new Core.WinForms.Controls.WebProgress();
         this.labelStatus = new System.Windows.Forms.Label();
         this.buttonClose = new System.Windows.Forms.Button();
         this.buttonAdd = new System.Windows.Forms.Button();
         this.viewExisting = new System.Windows.Forms.ListView();
         this.columnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.panelTop = new System.Windows.Forms.Panel();
         this.labelPullRequestId = new System.Windows.Forms.Label();
         this.buttonInvertSelection = new System.Windows.Forms.Button();
         this.buttonUnselectAll = new System.Windows.Forms.Button();
         this.buttonSelectAll = new System.Windows.Forms.Button();
         this.tableLayoutPanel.SuspendLayout();
         this.panelBottom.SuspendLayout();
         this.panelTop.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel
         // 
         this.tableLayoutPanel.ColumnCount = 2;
         this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel.Controls.Add(this.viewMissing, 1, 1);
         this.tableLayoutPanel.Controls.Add(this.panelBottom, 0, 2);
         this.tableLayoutPanel.Controls.Add(this.viewExisting, 0, 1);
         this.tableLayoutPanel.Controls.Add(this.panelTop, 0, 0);
         this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel.Name = "tableLayoutPanel";
         this.tableLayoutPanel.RowCount = 3;
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel.Size = new System.Drawing.Size(1268, 525);
         this.tableLayoutPanel.TabIndex = 0;
         // 
         // viewMissing
         // 
         this.viewMissing.CheckBoxes = true;
         this.viewMissing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
         this.viewMissing.Dock = System.Windows.Forms.DockStyle.Fill;
         this.viewMissing.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.viewMissing.FullRowSelect = true;
         this.viewMissing.GridLines = true;
         this.viewMissing.HideSelection = false;
         this.viewMissing.Location = new System.Drawing.Point(637, 35);
         this.viewMissing.Name = "viewMissing";
         this.viewMissing.Size = new System.Drawing.Size(628, 455);
         this.viewMissing.TabIndex = 4;
         this.viewMissing.UseCompatibleStateImageBehavior = false;
         this.viewMissing.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "ID";
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Title";
         // 
         // panelBottom
         // 
         this.tableLayoutPanel.SetColumnSpan(this.panelBottom, 2);
         this.panelBottom.Controls.Add(this.webProgress);
         this.panelBottom.Controls.Add(this.labelStatus);
         this.panelBottom.Controls.Add(this.buttonClose);
         this.panelBottom.Controls.Add(this.buttonAdd);
         this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelBottom.Location = new System.Drawing.Point(3, 496);
         this.panelBottom.Name = "panelBottom";
         this.panelBottom.Size = new System.Drawing.Size(1262, 26);
         this.panelBottom.TabIndex = 2;
         // 
         // webProgress
         // 
         this.webProgress.Color = System.Drawing.Color.ForestGreen;
         this.webProgress.Location = new System.Drawing.Point(90, 0);
         this.webProgress.Name = "webProgress";
         this.webProgress.Size = new System.Drawing.Size(22, 22);
         this.webProgress.TabIndex = 3;
         this.webProgress.Visible = false;
         // 
         // labelStatus
         // 
         this.labelStatus.AutoEllipsis = true;
         this.labelStatus.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelStatus.Location = new System.Drawing.Point(90, 0);
         this.labelStatus.Name = "labelStatus";
         this.labelStatus.Size = new System.Drawing.Size(1095, 23);
         this.labelStatus.TabIndex = 2;
         this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // buttonClose
         // 
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.Location = new System.Drawing.Point(1184, 0);
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size(75, 23);
         this.buttonClose.TabIndex = 1;
         this.buttonClose.Text = "Close";
         this.buttonClose.UseVisualStyleBackColor = true;
         this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
         // 
         // buttonAdd
         // 
         this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonAdd.Location = new System.Drawing.Point(9, 0);
         this.buttonAdd.Name = "buttonAdd";
         this.buttonAdd.Size = new System.Drawing.Size(75, 23);
         this.buttonAdd.TabIndex = 0;
         this.buttonAdd.Text = "Add";
         this.buttonAdd.UseVisualStyleBackColor = true;
         this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
         // 
         // viewExisting
         // 
         this.viewExisting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnTitle});
         this.viewExisting.Dock = System.Windows.Forms.DockStyle.Fill;
         this.viewExisting.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.viewExisting.FullRowSelect = true;
         this.viewExisting.GridLines = true;
         this.viewExisting.HideSelection = false;
         this.viewExisting.Location = new System.Drawing.Point(3, 35);
         this.viewExisting.Name = "viewExisting";
         this.viewExisting.Size = new System.Drawing.Size(628, 455);
         this.viewExisting.TabIndex = 3;
         this.viewExisting.UseCompatibleStateImageBehavior = false;
         this.viewExisting.View = System.Windows.Forms.View.Details;
         // 
         // columnId
         // 
         this.columnId.Text = "ID";
         // 
         // columnTitle
         // 
         this.columnTitle.Text = "Title";
         // 
         // panelTop
         // 
         this.tableLayoutPanel.SetColumnSpan(this.panelTop, 2);
         this.panelTop.Controls.Add(this.buttonInvertSelection);
         this.panelTop.Controls.Add(this.buttonUnselectAll);
         this.panelTop.Controls.Add(this.buttonSelectAll);
         this.panelTop.Controls.Add(this.labelPullRequestId);
         this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelTop.Location = new System.Drawing.Point(3, 3);
         this.panelTop.Name = "panelTop";
         this.panelTop.Size = new System.Drawing.Size(1262, 26);
         this.panelTop.TabIndex = 5;
         // 
         // labelPullRequestId
         // 
         this.labelPullRequestId.AutoSize = true;
         this.labelPullRequestId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelPullRequestId.Location = new System.Drawing.Point(9, 6);
         this.labelPullRequestId.Name = "labelPullRequestId";
         this.labelPullRequestId.Size = new System.Drawing.Size(139, 20);
         this.labelPullRequestId.TabIndex = 1;
         this.labelPullRequestId.Text = "Pull Request ####";
         this.labelPullRequestId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // buttonInvertSelection
         // 
         this.buttonInvertSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonInvertSelection.Location = new System.Drawing.Point(1152, 3);
         this.buttonInvertSelection.Name = "buttonInvertSelection";
         this.buttonInvertSelection.Size = new System.Drawing.Size(101, 23);
         this.buttonInvertSelection.TabIndex = 5;
         this.buttonInvertSelection.Text = "Invert Selection";
         this.buttonInvertSelection.UseVisualStyleBackColor = true;
         this.buttonInvertSelection.Click += new System.EventHandler(this.buttonInvertSelection_Click);
         // 
         // buttonUnselectAll
         // 
         this.buttonUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonUnselectAll.Location = new System.Drawing.Point(1045, 3);
         this.buttonUnselectAll.Name = "buttonUnselectAll";
         this.buttonUnselectAll.Size = new System.Drawing.Size(101, 23);
         this.buttonUnselectAll.TabIndex = 4;
         this.buttonUnselectAll.Text = "Unselect All";
         this.buttonUnselectAll.UseVisualStyleBackColor = true;
         this.buttonUnselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
         // 
         // buttonSelectAll
         // 
         this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSelectAll.Location = new System.Drawing.Point(938, 3);
         this.buttonSelectAll.Name = "buttonSelectAll";
         this.buttonSelectAll.Size = new System.Drawing.Size(101, 23);
         this.buttonSelectAll.TabIndex = 3;
         this.buttonSelectAll.Text = "SelectAll";
         this.buttonSelectAll.UseVisualStyleBackColor = true;
         this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
         // 
         // MissingWorkItems
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1268, 525);
         this.Controls.Add(this.tableLayoutPanel);
         this.Name = "MissingWorkItems";
         this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
         this.Text = "Missing Work Items";
         this.Load += new System.EventHandler(this.MissingWorkItems_Load);
         this.Resize += new System.EventHandler(this.MissingWorkItems_Resize);
         this.tableLayoutPanel.ResumeLayout(false);
         this.panelBottom.ResumeLayout(false);
         this.panelTop.ResumeLayout(false);
         this.panelTop.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
      private System.Windows.Forms.Panel panelBottom;
      private System.Windows.Forms.Button buttonClose;
      private System.Windows.Forms.Button buttonAdd;
      private System.Windows.Forms.ListView viewExisting;
      private System.Windows.Forms.ColumnHeader columnId;
      private System.Windows.Forms.ColumnHeader columnTitle;
      private System.Windows.Forms.ListView viewMissing;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.Label labelStatus;
      private Core.WinForms.Controls.WebProgress webProgress;
      private System.Windows.Forms.Panel panelTop;
      private System.Windows.Forms.Label labelPullRequestId;
      private System.Windows.Forms.Button buttonInvertSelection;
      private System.Windows.Forms.Button buttonUnselectAll;
      private System.Windows.Forms.Button buttonSelectAll;
   }
}