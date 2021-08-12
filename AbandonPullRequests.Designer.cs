
namespace ReleasePalette
{
   partial class AbandonPullRequests
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
         this.labelPullRequestId = new System.Windows.Forms.Label();
         this.treeViewPullRequests = new System.Windows.Forms.TreeView();
         this.buttonClose = new System.Windows.Forms.Button();
         this.buttonAbandon = new System.Windows.Forms.Button();
         this.progressBar = new System.Windows.Forms.ProgressBar();
         this.buttonSelectAll = new System.Windows.Forms.Button();
         this.buttonUnselectAll = new System.Windows.Forms.Button();
         this.buttonInvertSelection = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // labelPullRequestId
         // 
         this.labelPullRequestId.AutoSize = true;
         this.labelPullRequestId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelPullRequestId.Location = new System.Drawing.Point(12, 9);
         this.labelPullRequestId.Name = "labelPullRequestId";
         this.labelPullRequestId.Size = new System.Drawing.Size(139, 20);
         this.labelPullRequestId.TabIndex = 0;
         this.labelPullRequestId.Text = "Pull Request ####";
         // 
         // treeViewPullRequests
         // 
         this.treeViewPullRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.treeViewPullRequests.CheckBoxes = true;
         this.treeViewPullRequests.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.treeViewPullRequests.Location = new System.Drawing.Point(12, 32);
         this.treeViewPullRequests.Name = "treeViewPullRequests";
         this.treeViewPullRequests.Size = new System.Drawing.Size(870, 401);
         this.treeViewPullRequests.TabIndex = 3;
         this.treeViewPullRequests.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPullRequests_AfterCheck);
         // 
         // buttonClose
         // 
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonClose.Location = new System.Drawing.Point(807, 440);
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size(75, 23);
         this.buttonClose.TabIndex = 5;
         this.buttonClose.Text = "Close";
         this.buttonClose.UseVisualStyleBackColor = true;
         this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
         // 
         // buttonAbandon
         // 
         this.buttonAbandon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonAbandon.Location = new System.Drawing.Point(12, 440);
         this.buttonAbandon.Name = "buttonAbandon";
         this.buttonAbandon.Size = new System.Drawing.Size(75, 23);
         this.buttonAbandon.TabIndex = 4;
         this.buttonAbandon.Text = "Abandon";
         this.buttonAbandon.UseVisualStyleBackColor = true;
         this.buttonAbandon.Click += new System.EventHandler(this.buttonAbandon_Click);
         // 
         // progressBar
         // 
         this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.progressBar.Location = new System.Drawing.Point(93, 440);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(708, 23);
         this.progressBar.TabIndex = 4;
         this.progressBar.Visible = false;
         // 
         // buttonSelectAll
         // 
         this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSelectAll.Location = new System.Drawing.Point(567, 6);
         this.buttonSelectAll.Name = "buttonSelectAll";
         this.buttonSelectAll.Size = new System.Drawing.Size(101, 23);
         this.buttonSelectAll.TabIndex = 0;
         this.buttonSelectAll.Text = "SelectAll";
         this.buttonSelectAll.UseVisualStyleBackColor = true;
         this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
         // 
         // buttonUnselectAll
         // 
         this.buttonUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonUnselectAll.Location = new System.Drawing.Point(674, 6);
         this.buttonUnselectAll.Name = "buttonUnselectAll";
         this.buttonUnselectAll.Size = new System.Drawing.Size(101, 23);
         this.buttonUnselectAll.TabIndex = 1;
         this.buttonUnselectAll.Text = "Unselect All";
         this.buttonUnselectAll.UseVisualStyleBackColor = true;
         this.buttonUnselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
         // 
         // buttonInvertSelection
         // 
         this.buttonInvertSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonInvertSelection.Location = new System.Drawing.Point(781, 6);
         this.buttonInvertSelection.Name = "buttonInvertSelection";
         this.buttonInvertSelection.Size = new System.Drawing.Size(101, 23);
         this.buttonInvertSelection.TabIndex = 2;
         this.buttonInvertSelection.Text = "Invert Selection";
         this.buttonInvertSelection.UseVisualStyleBackColor = true;
         this.buttonInvertSelection.Click += new System.EventHandler(this.buttonInvertSelection_Click);
         // 
         // AbandonPullRequests
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(894, 474);
         this.Controls.Add(this.buttonInvertSelection);
         this.Controls.Add(this.buttonUnselectAll);
         this.Controls.Add(this.buttonSelectAll);
         this.Controls.Add(this.progressBar);
         this.Controls.Add(this.buttonAbandon);
         this.Controls.Add(this.buttonClose);
         this.Controls.Add(this.treeViewPullRequests);
         this.Controls.Add(this.labelPullRequestId);
         this.Name = "AbandonPullRequests";
         this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
         this.Text = "Abandon Pull Requests";
         this.Load += new System.EventHandler(this.AbandonPullRequests_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelPullRequestId;
      private System.Windows.Forms.TreeView treeViewPullRequests;
      private System.Windows.Forms.Button buttonClose;
      private System.Windows.Forms.Button buttonAbandon;
      private System.Windows.Forms.ProgressBar progressBar;
      private System.Windows.Forms.Button buttonSelectAll;
      private System.Windows.Forms.Button buttonUnselectAll;
      private System.Windows.Forms.Button buttonInvertSelection;
   }
}