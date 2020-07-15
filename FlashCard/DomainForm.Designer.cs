using System;
using Telerik.WinControls.UI;

namespace FlashCard
{
    partial class DomainForm
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
            this.components = new System.ComponentModel.Container();
            this.radCheckedListBox1 = new Telerik.WinControls.UI.RadCheckedListBox();
            this.object_154fef01_891f_453a_8e0f_1a6876aea589 = new Telerik.WinControls.RootRadElement();
            this.nextBtn = new Telerik.WinControls.UI.RadButton();
            this.roundRectShape1 = new Telerik.WinControls.RoundRectShape(this.components);
            this.radCheckAllButton = new Telerik.WinControls.UI.RadButton();
            this.radCheckSelectedButton = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.circleShape1 = new Telerik.WinControls.CircleShape();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.selectedDomainLbl = new Telerik.WinControls.UI.RadLabel();
            this.countAllDomainLbl = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckAllButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckSelectedButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDomainLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countAllDomainLbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCheckedListBox1
            // 
            this.radCheckedListBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radCheckedListBox1.CheckBoxesAlignment = Telerik.WinControls.UI.CheckBoxesAlignment.Near;
            this.radCheckedListBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radCheckedListBox1.ItemSize = new System.Drawing.Size(0, 20);
            this.radCheckedListBox1.Location = new System.Drawing.Point(6, 42);
            this.radCheckedListBox1.Margin = new System.Windows.Forms.Padding(5);
            this.radCheckedListBox1.MultiSelect = true;
            this.radCheckedListBox1.Name = "radCheckedListBox1";
            this.radCheckedListBox1.Size = new System.Drawing.Size(370, 304);
            this.radCheckedListBox1.TabIndex = 2;
            this.radCheckedListBox1.ItemCheckedChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radCheckedListBox1_ItemCheckedChanged);
            // 
            // object_154fef01_891f_453a_8e0f_1a6876aea589
            // 
            this.object_154fef01_891f_453a_8e0f_1a6876aea589.Name = "object_154fef01_891f_453a_8e0f_1a6876aea589";
            this.object_154fef01_891f_453a_8e0f_1a6876aea589.StretchHorizontally = true;
            this.object_154fef01_891f_453a_8e0f_1a6876aea589.StretchVertically = true;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextBtn.ForeColor = System.Drawing.Color.White;
            this.nextBtn.Location = new System.Drawing.Point(632, 354);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(131, 28);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "START";
            this.nextBtn.TextWrap = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.nextBtn.GetChildAt(0))).UseDefaultDisabledPaint = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.nextBtn.GetChildAt(0))).Text = "START";
            ((Telerik.WinControls.UI.RadButtonElement)(this.nextBtn.GetChildAt(0))).ShouldPaint = true;
            ((Telerik.WinControls.UI.RadButtonElement)(this.nextBtn.GetChildAt(0))).Shape = null;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(57)))), ((int)(((byte)(77)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(250)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).CustomFontSize = 16F;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).CustomFontStyle = System.Drawing.FontStyle.Italic;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(0))).AngleTransform = 2F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(2))).BottomWidth = 3F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(2))).BottomColor = System.Drawing.Color.Red;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(2))).BottomShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(32)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(2))).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.nextBtn.GetChildAt(0).GetChildAt(2))).CanFocus = true;
            // 
            // roundRectShape1
            // 
            this.roundRectShape1.IsRightToLeft = true;
            // 
            // radCheckAllButton
            // 
            this.radCheckAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radCheckAllButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.radCheckAllButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radCheckAllButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radCheckAllButton.ForeColor = System.Drawing.Color.White;
            this.radCheckAllButton.Location = new System.Drawing.Point(12, 354);
            this.radCheckAllButton.Name = "radCheckAllButton";
            this.radCheckAllButton.Size = new System.Drawing.Size(85, 24);
            this.radCheckAllButton.TabIndex = 2;
            this.radCheckAllButton.Text = "Check all";
            this.radCheckAllButton.Click += new System.EventHandler(this.radCheckAllButton_Click);
            // 
            // radCheckSelectedButton
            // 
            this.radCheckSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radCheckSelectedButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.radCheckSelectedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radCheckSelectedButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radCheckSelectedButton.ForeColor = System.Drawing.Color.White;
            this.radCheckSelectedButton.Location = new System.Drawing.Point(113, 354);
            this.radCheckSelectedButton.Name = "radCheckSelectedButton";
            this.radCheckSelectedButton.Size = new System.Drawing.Size(115, 24);
            this.radCheckSelectedButton.TabIndex = 3;
            this.radCheckSelectedButton.Text = "Check select";
            this.radCheckSelectedButton.Click += new System.EventHandler(this.radCheckSelectedButton_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(449, 357);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(74, 25);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Selected";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radLabel2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(269, 10);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(212, 32);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Select the domain(s)";
            // 
            // circleShape1
            // 
            this.circleShape1.IsRightToLeft = false;
            // 
            // radListView1
            // 
            this.radListView1.AllowEdit = false;
            this.radListView1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radListView1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radListView1.ItemSpacing = -1;
            this.radListView1.Location = new System.Drawing.Point(386, 42);
            this.radListView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.radListView1.MultiSelect = true;
            this.radListView1.Name = "radListView1";
            this.radListView1.ShowColumnHeaders = false;
            this.radListView1.ShowGridLines = true;
            this.radListView1.Size = new System.Drawing.Size(377, 304);
            this.radListView1.TabIndex = 3;
            this.radListView1.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel3.ForeColor = System.Drawing.Color.White;
            this.radLabel3.Location = new System.Drawing.Point(551, 357);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(24, 25);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "of";
            // 
            // selectedDomainLbl
            // 
            this.selectedDomainLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedDomainLbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectedDomainLbl.ForeColor = System.Drawing.Color.White;
            this.selectedDomainLbl.Location = new System.Drawing.Point(525, 357);
            this.selectedDomainLbl.Name = "selectedDomainLbl";
            this.selectedDomainLbl.Size = new System.Drawing.Size(19, 25);
            this.selectedDomainLbl.TabIndex = 7;
            this.selectedDomainLbl.Text = "0";
            // 
            // countAllDomainLbl
            // 
            this.countAllDomainLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.countAllDomainLbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countAllDomainLbl.ForeColor = System.Drawing.Color.White;
            this.countAllDomainLbl.Location = new System.Drawing.Point(579, 357);
            this.countAllDomainLbl.Name = "countAllDomainLbl";
            this.countAllDomainLbl.Size = new System.Drawing.Size(19, 25);
            this.countAllDomainLbl.TabIndex = 8;
            this.countAllDomainLbl.Text = "6";
            // 
            // DomainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(762, 388);
            this.Controls.Add(this.countAllDomainLbl);
            this.Controls.Add(this.selectedDomainLbl);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radListView1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radCheckSelectedButton);
            this.Controls.Add(this.radCheckAllButton);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.radCheckedListBox1);
            this.Name = "DomainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckAllButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckSelectedButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedDomainLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countAllDomainLbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCheckedListBox radCheckedListBox1;
        private Telerik.WinControls.RootRadElement object_154fef01_891f_453a_8e0f_1a6876aea589;
        private Telerik.WinControls.UI.RadButton nextBtn;
        private Telerik.WinControls.UI.RadButton radCheckAllButton;
        private Telerik.WinControls.UI.RadButton radCheckSelectedButton;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.RoundRectShape roundRectShape1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.CircleShape circleShape1;
        private RadListView radListView1;
        private RadLabel radLabel3;
        private RadLabel selectedDomainLbl;
        private RadLabel countAllDomainLbl;
    }
}