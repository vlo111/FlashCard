namespace FlashCard
{
    partial class RatingModalForm
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
            this.radRating1 = new Telerik.WinControls.UI.RadRating();
            this.ratingStarVisualElement1 = new Telerik.WinControls.UI.RatingStarVisualElement();
            this.ratingStarVisualElement2 = new Telerik.WinControls.UI.RatingStarVisualElement();
            this.ratingStarVisualElement3 = new Telerik.WinControls.UI.RatingStarVisualElement();
            this.ratingStarVisualElement4 = new Telerik.WinControls.UI.RatingStarVisualElement();
            this.ratingStarVisualElement5 = new Telerik.WinControls.UI.RatingStarVisualElement();
            this.RatingMessageLbl = new Telerik.WinControls.UI.RadLabel();
            this.scoreNormalLbl = new Telerik.WinControls.UI.RadLabel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radRating1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingMessageLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreNormalLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radRating1
            // 
            this.radRating1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ratingStarVisualElement1,
            this.ratingStarVisualElement2,
            this.ratingStarVisualElement3,
            this.ratingStarVisualElement4,
            this.ratingStarVisualElement5});
            this.radRating1.Location = new System.Drawing.Point(74, 88);
            this.radRating1.Name = "radRating1";
            this.radRating1.ReadOnly = true;
            this.radRating1.Size = new System.Drawing.Size(249, 56);
            this.radRating1.TabIndex = 0;
            // 
            // ratingStarVisualElement1
            // 
            this.ratingStarVisualElement1.Name = "ratingStarVisualElement1";
            // 
            // ratingStarVisualElement2
            // 
            this.ratingStarVisualElement2.Name = "ratingStarVisualElement2";
            // 
            // ratingStarVisualElement3
            // 
            this.ratingStarVisualElement3.Name = "ratingStarVisualElement3";
            // 
            // ratingStarVisualElement4
            // 
            this.ratingStarVisualElement4.Name = "ratingStarVisualElement4";
            // 
            // ratingStarVisualElement5
            // 
            this.ratingStarVisualElement5.Name = "ratingStarVisualElement5";
            // 
            // RatingMessageLbl
            // 
            this.RatingMessageLbl.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RatingMessageLbl.ForeColor = System.Drawing.Color.LimeGreen;
            this.RatingMessageLbl.Location = new System.Drawing.Point(167, 44);
            this.RatingMessageLbl.Name = "RatingMessageLbl";
            this.RatingMessageLbl.Size = new System.Drawing.Size(2, 2);
            this.RatingMessageLbl.TabIndex = 1;
            // 
            // scoreNormalLbl
            // 
            this.scoreNormalLbl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreNormalLbl.Location = new System.Drawing.Point(104, 167);
            this.scoreNormalLbl.Name = "scoreNormalLbl";
            this.scoreNormalLbl.Size = new System.Drawing.Size(188, 22);
            this.scoreNormalLbl.TabIndex = 2;
            this.scoreNormalLbl.Text = "You scored 70 score of 100";
            // 
            // radButton1
            // 
            this.radButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radButton1.Location = new System.Drawing.Point(144, 223);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(115, 24);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "OK";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // RatingModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 278);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.scoreNormalLbl);
            this.Controls.Add(this.RatingMessageLbl);
            this.Controls.Add(this.radRating1);
            this.MaximumSize = new System.Drawing.Size(410, 308);
            this.MinimumSize = new System.Drawing.Size(410, 308);
            this.Name = "RatingModalForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(410, 308);
            this.Text = "RatingModalForm";
            ((System.ComponentModel.ISupportInitialize)(this.radRating1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RatingMessageLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreNormalLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRating radRating1;
        private Telerik.WinControls.UI.RatingStarVisualElement ratingStarVisualElement1;
        private Telerik.WinControls.UI.RatingStarVisualElement ratingStarVisualElement2;
        private Telerik.WinControls.UI.RatingStarVisualElement ratingStarVisualElement3;
        private Telerik.WinControls.UI.RatingStarVisualElement ratingStarVisualElement4;
        private Telerik.WinControls.UI.RatingStarVisualElement ratingStarVisualElement5;
        private Telerik.WinControls.UI.RadLabel RatingMessageLbl;
        private Telerik.WinControls.UI.RadLabel scoreNormalLbl;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
