
namespace ReleasePalette
{
   partial class AddWorkItems
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
         this.labelPullRequestId = new System.Windows.Forms.Label();
         this.listViewExisting = new System.Windows.Forms.ListView();
         this.columnWorkItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.tableLayoutPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel
         // 
         this.tableLayoutPanel.ColumnCount = 3;
         this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
         this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel.Controls.Add(this.labelPullRequestId, 0, 0);
         this.tableLayoutPanel.Controls.Add(this.listViewExisting, 0, 1);
         this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel.Name = "tableLayoutPanel";
         this.tableLayoutPanel.RowCount = 3;
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel.Size = new System.Drawing.Size(1102, 579);
         this.tableLayoutPanel.TabIndex = 0;
         // 
         // labelPullRequestId
         // 
         this.tableLayoutPanel.SetColumnSpan(this.labelPullRequestId, 3);
         this.labelPullRequestId.Dock = System.Windows.Forms.DockStyle.Fill;
         this.labelPullRequestId.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelPullRequestId.Location = new System.Drawing.Point(3, 0);
         this.labelPullRequestId.Name = "labelPullRequestId";
         this.labelPullRequestId.Size = new System.Drawing.Size(1096, 32);
         this.labelPullRequestId.TabIndex = 0;
         this.labelPullRequestId.Text = "Pull Request ####";
         this.labelPullRequestId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // listViewExisting
         // 
         this.listViewExisting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWorkItemId,
            this.columnTitle});
         this.listViewExisting.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewExisting.FullRowSelect = true;
         this.listViewExisting.HideSelection = false;
         this.listViewExisting.Location = new System.Drawing.Point(3, 35);
         this.listViewExisting.Name = "listViewExisting";
         this.listViewExisting.Size = new System.Drawing.Size(513, 267);
         this.listViewExisting.TabIndex = 1;
         this.listViewExisting.UseCompatibleStateImageBehavior = false;
         this.listViewExisting.View = System.Windows.Forms.View.Details;
         // 
         // columnWorkItemId
         // 
         this.columnWorkItemId.Text = "Work Item Id";
         // 
         // columnTitle
         // 
         this.columnTitle.Text = "Title";
         // 
         // AddWorkItems
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1102, 579);
         this.Controls.Add(this.tableLayoutPanel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AddWorkItems";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Add Work Items to Pull Request";
         this.Load += new System.EventHandler(this.AddWorkItems_Load);
         this.tableLayoutPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
      private System.Windows.Forms.Label labelPullRequestId;
      private System.Windows.Forms.ListView listViewExisting;
      private System.Windows.Forms.ColumnHeader columnWorkItemId;
      private System.Windows.Forms.ColumnHeader columnTitle;
   }
}