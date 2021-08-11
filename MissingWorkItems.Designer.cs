
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
         this.labelPullRequestId = new System.Windows.Forms.Label();
         this.listWorkItems = new System.Windows.Forms.ListBox();
         this.panelBottom = new System.Windows.Forms.Panel();
         this.buttonAdd = new System.Windows.Forms.Button();
         this.buttonClose = new System.Windows.Forms.Button();
         this.tableLayoutPanel.SuspendLayout();
         this.panelBottom.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel
         // 
         this.tableLayoutPanel.ColumnCount = 1;
         this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel.Controls.Add(this.labelPullRequestId, 0, 0);
         this.tableLayoutPanel.Controls.Add(this.listWorkItems, 0, 1);
         this.tableLayoutPanel.Controls.Add(this.panelBottom, 0, 2);
         this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel.Name = "tableLayoutPanel";
         this.tableLayoutPanel.RowCount = 3;
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
         this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
         this.tableLayoutPanel.TabIndex = 0;
         // 
         // labelPullRequestId
         // 
         this.labelPullRequestId.Dock = System.Windows.Forms.DockStyle.Fill;
         this.labelPullRequestId.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelPullRequestId.Location = new System.Drawing.Point(3, 0);
         this.labelPullRequestId.Name = "labelPullRequestId";
         this.labelPullRequestId.Size = new System.Drawing.Size(794, 32);
         this.labelPullRequestId.TabIndex = 0;
         this.labelPullRequestId.Text = "Pull Request ####";
         this.labelPullRequestId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // listWorkItems
         // 
         this.listWorkItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listWorkItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.listWorkItems.FormattingEnabled = true;
         this.listWorkItems.Location = new System.Drawing.Point(3, 35);
         this.listWorkItems.Name = "listWorkItems";
         this.listWorkItems.Size = new System.Drawing.Size(794, 380);
         this.listWorkItems.TabIndex = 1;
         // 
         // panelBottom
         // 
         this.panelBottom.Controls.Add(this.buttonClose);
         this.panelBottom.Controls.Add(this.buttonAdd);
         this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelBottom.Location = new System.Drawing.Point(3, 421);
         this.panelBottom.Name = "panelBottom";
         this.panelBottom.Size = new System.Drawing.Size(794, 26);
         this.panelBottom.TabIndex = 2;
         // 
         // buttonAdd
         // 
         this.buttonAdd.Location = new System.Drawing.Point(9, 0);
         this.buttonAdd.Name = "buttonAdd";
         this.buttonAdd.Size = new System.Drawing.Size(75, 23);
         this.buttonAdd.TabIndex = 0;
         this.buttonAdd.Text = "Add";
         this.buttonAdd.UseVisualStyleBackColor = true;
         // 
         // buttonClose
         // 
         this.buttonClose.Location = new System.Drawing.Point(716, 0);
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size(75, 23);
         this.buttonClose.TabIndex = 1;
         this.buttonClose.Text = "Close";
         this.buttonClose.UseVisualStyleBackColor = true;
         // 
         // MissingWorkItems
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.tableLayoutPanel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MissingWorkItems";
         this.Text = "Missing Work Items";
         this.tableLayoutPanel.ResumeLayout(false);
         this.panelBottom.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
      private System.Windows.Forms.Label labelPullRequestId;
      private System.Windows.Forms.ListBox listWorkItems;
      private System.Windows.Forms.Panel panelBottom;
      private System.Windows.Forms.Button buttonClose;
      private System.Windows.Forms.Button buttonAdd;
   }
}