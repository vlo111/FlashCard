namespace FlashCard
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using DataAccess;

    using Telerik.WinControls;
    using Telerik.WinControls.UI;

    public partial class DomainForm : RadForm
    {
        #region Title bar

        public void TitleBarSetting()
        {
            RadTitleBarElement titleBar = this.FormElement.TitleBar;

            titleBar.FillPrimitive.BackColor = Color.DodgerBlue;
            titleBar.BorderThickness = Padding.Empty;
            titleBar.BorderHighlightColor = Color.DodgerBlue;
            titleBar.FillPrimitive.GradientStyle = GradientStyles.Solid;
            titleBar.MaxSize = new Size(0, 30);
            titleBar.Children[1].Visibility = ElementVisibility.Hidden;
            titleBar.AllowResize = false;

            titleBar.CloseButton.Parent.PositionOffset = new SizeF(0, 0);
            titleBar.CloseButton.MinSize = new Size(10, 10);
            titleBar.CloseButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;

            titleBar.MinimizeButton.MinSize = new Size(10, 10);
            titleBar.MinimizeButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;

            titleBar.MaximizeButton.MinSize = new Size(10, 10);
            titleBar.MaximizeButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;
        }

        #endregion

        public DomainForm()
        {
            this.InitializeComponent();

            this.InitializeData();
            var nameColumn = new ListViewDetailColumn("Domain");
            nameColumn.Width = 132;
            this.radListView1.Columns.Add(nameColumn);

            this.radCheckedListBox1.SelectedItemsChanged += radCheckedListBox1_SelectedItemsChanged;
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            // this.TitleBarSetting();
        }

        private void InitializeData()
        {
            IEnumerable domains = this.GetDomains();

            foreach (DomainDto domain in domains)
            {
                this.radCheckedListBox1.Items.Add(this.CreateItem(domain));
            }
        }

        private IEnumerable GetDomains()
        {
            var domains = GetDB.GetAllDomains();

            this.countAllDomainLbl.Text = domains.Count().ToString();

            return domains.AsEnumerable();
        }

        private ListViewDataItem CreateItem(DomainDto domain)
        {
            ListViewDataItem item = new ListViewDataItem();
            item.Text = domain.Name;
            item.Tag = domain;

            return item;
        }

        private void radCheckedListBox1_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            DomainDto domain = e.Item.Tag as DomainDto;

            if (e.Item.CheckState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                ListViewDataItem item = new ListViewDataItem();
                item.Tag = domain;
                this.radListView1.Items.Add(item);

                item["Domain"] = domain.Name;
            }
            else
            {
                foreach (ListViewDataItem item in this.radListView1.Items)
                {
                    if (item["Domain"].ToString() == domain.Name)
                    {
                        this.radListView1.Items.Remove(item);
                        break;
                    }
                }
            }

            this.selectedDomainLbl.Text = this.radListView1.Items.Count.ToString();

            this.radCheckAllButton.Text =
                this.radCheckedListBox1.Items.Count == this.radCheckedListBox1.CheckedItems.Count
                    ? "Uncheck all"
                    : "Check all";

            this.UpdateSelectedButtonText();
        }

        public void radCheckedListBox1_SelectedItemsChanged(object sender, EventArgs e)
        {
            this.UpdateSelectedButtonText();
        }

        private void radCheckAllButton_Click(object sender, EventArgs e)
        {
            if (this.radCheckAllButton.Text == @"Check all")
            {
                this.radCheckedListBox1.CheckAllItems();
                this.radCheckAllButton.Text = @"Uncheck all";
            }
            else
            {
                this.radCheckedListBox1.UncheckAllItems();
                this.radCheckAllButton.Text = @"Check all";
            }
        }

        private void radCheckSelectedButton_Click(object sender, EventArgs e)
        {
            if (this.radCheckSelectedButton.Text == @"Check selected")
            {
                this.radCheckedListBox1.CheckSelectedItems();
                this.radCheckSelectedButton.Text = @"Uncheck selected";
            }
            else
            {
                this.radCheckedListBox1.UncheckSelectedItems();
                this.radCheckSelectedButton.Text = @"Check selected";
            }
        }

        private void UpdateSelectedButtonText()
        {
            foreach (ListViewDataItem item in this.radCheckedListBox1.SelectedItems)
            {
                if (item.CheckState != Telerik.WinControls.Enumerations.ToggleState.On)
                {
                    this.radCheckSelectedButton.Text = @"Check selected";
                    return;
                }
            }

            this.radCheckSelectedButton.Text = @"Uncheck selected";
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (this.radListView1.Items.Count > 0)
            {
                this.Hide();

                var domains = this.radListView1.Items.Select(p => p.Tag as DomainDto).ToList();

                var qa = new QA(domains);

                qa.ShowDialog();

                if (!this.IsDisposed)
                {
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show(@"Please check the domain(s)", @"Warning", MessageBoxButtons.OK);
            }
        }
    }
}