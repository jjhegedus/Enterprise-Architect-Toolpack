﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace GlossaryManager.GUI
{
    /// <summary>
    /// Description of EDD_MainControl.
    /// </summary>
    public partial class EDD_MainControl : UserControl
    {
        public List<Domain> domains { get; set; }
        public List<String> statusses { get; set; }
        public EDD_MainControl()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            enableDisable();

        }
        private void enableDisable()
        {
            bool itemSelected = (this.selectedBusinessItem != null
                                && this.DetailsTabControl.SelectedTab == this.BusinessItemsTabPage)
                                || (this.selectedDataItem != null
                                && this.DetailsTabControl.SelectedTab == this.DataItemsTabPage);
            this.openPropertiesButton.Enabled = itemSelected;
            this.navigateProjectBrowserButton.Enabled = itemSelected;
        }
        public List<BusinessItem> getBusinessItems()
        {
            return this.BusinessItemsListView.Objects.Cast<BusinessItem>().ToList();
        }

        public void setBusinessItems(IEnumerable<BusinessItem> businessItems, Domain domain)
        {
            this.BusinessItemsListView.Objects = businessItems;
            if (domain != null)
            {
                //select corresponding domain item
                this.domainBreadCrumb.SelectedItem = getBreadCrumbSubItem(this.domainBreadCrumb.RootItem, domain) ?? this.domainBreadCrumb.RootItem;
            }
            this.BusinessItemsListView.SelectedObject = businessItems.FirstOrDefault();
        }
        public void setDataItems(IEnumerable<DataItem> dataItems, Domain domain)
        {
            this.dataItemsListView.Objects = dataItems;
            if (domain != null)
            {
                //select corresponding domain item
                this.domainBreadCrumb.SelectedItem = getBreadCrumbSubItem(this.domainBreadCrumb.RootItem, domain) ?? this.domainBreadCrumb.RootItem;
            }
            this.dataItemsListView.SelectedObject = dataItems.FirstOrDefault();
        }
        internal void addItem(GlossaryItem newItem)
        {
            if (newItem is BusinessItem)
            {
                //add item to top of  list
                this.BusinessItemsListView.InsertObjects(0, new List<BusinessItem>() { (BusinessItem)newItem });
                //select it
                this.BusinessItemsListView.SelectObject(newItem);
            }
            else if (newItem is DataItem)
            {
                //add item to top of  list
                this.dataItemsListView.InsertObjects(0, new List<DataItem>() { (DataItem)newItem });
                //select it
                this.dataItemsListView.SelectObject(newItem);
            }
        }
        private KryptonBreadCrumbItem getBreadCrumbSubItem(KryptonBreadCrumbItem parentItem, Domain domain)
        {
            foreach (var subItem in parentItem.Items)
            {
                var foundDomain = (Domain)subItem.Tag;
                if (foundDomain.uniqueID == domain.uniqueID)
                    return subItem; //found it
                //not found, look deeper
                var foundItem = getBreadCrumbSubItem(subItem, domain);
                if (foundItem != null)
                    return foundItem;
            }
            //not found, return null
            return null;
        }
        public void setStatusses(List<String> statusses)
        {
            this.statusses = statusses;
            BU_StatusCombobox.DataSource = this.statusses;
            DI_StatusComboBox.DataSource = this.statusses;
        }
        public void setDomains(List<Domain> domains)
        {
            this.domains = domains;
            BU_DomainComboBox.DataSource = this.domains;
            BU_DomainComboBox.DisplayMember = "displayName";
            DI_DomainComboBox.DataSource = this.domains;
            DI_DomainComboBox.DisplayMember = "displayName";

            //set the domains breadcrumb
            foreach (var domain in domains)
            {
                if (domain.parentDomain == null) //only process top level domains
                {
                    domainBreadCrumb.RootItem.Items.Add(createDomainBreadCrumbItem(domain));
                }
            }
        }



        public KryptonBreadCrumbItem createDomainBreadCrumbItem(Domain domain)
        {
            var breadCrumbItem = new KryptonBreadCrumbItem(domain.name);
            breadCrumbItem.Tag = domain;
            foreach (var subDomain in domain.subDomains)
            {
                breadCrumbItem.Items.Add(createDomainBreadCrumbItem(subDomain));
            }
            return breadCrumbItem;
        }
        private BusinessItem previousBusinessItem { get; set; }
        private BusinessItem selectedBusinessItem
        {
            get
            {
                return this.BusinessItemsListView.SelectedObject as BusinessItem;
            }
        }
        private DataItem previousDataItem { get; set; }
        private DataItem selectedDataItem
        {
            get
            {
                return this.dataItemsListView.SelectedObject as DataItem;
            }
        }
        private GlossaryItem selectedItem
        {
            get
            {
                if (this.selectedBusinessItem != null
                && this.DetailsTabControl.SelectedTab == this.BusinessItemsTabPage)
                {
                    return this.selectedBusinessItem;
                }
                else
                {
                    return this.selectedDataItem;
                }
            }
        }

        private void BusinessItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if the previous item has been changed
            if (this.previousBusinessItem != null)
            {
                if (this.hasBusinessitemChanged(this.previousBusinessItem))
                {
                    var response = MessageBox.Show(this, string.Format("Save changes to {0}?", this.previousBusinessItem.Name)
                                                     , "Unsaved changes!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (response == DialogResult.Yes)
                    {
                        this.unloadBusinessItemData(this.previousBusinessItem);
                        this.saveBusinessItem(this.previousBusinessItem);
                    }
                }
            }
            //then load the next item
            loadSelectedItemData();
            enableDisable();
            //set the previous business item
            this.previousBusinessItem = this.selectedBusinessItem;
        }
        private bool hasBusinessitemChanged(BusinessItem businessItem)
        {
            return businessItem.Name != this.BU_NameTextBox.Text
                    || businessItem.domain?.domainPath != ((Domain)this.BU_DomainComboBox.SelectedItem)?.domainPath
                    || businessItem.Description != this.BU_DescriptionTextBox.Text
                    || businessItem.Status != this.BU_StatusCombobox.Text
                    || businessItem.Version != this.BU_VersionTextBox.Text
                    || string.Join(",", businessItem.Keywords) != this.BU_KeywordsTextBox.Text;
        }
        private bool hasDataItemChanged(DataItem dataItem)
        {
            return dataItem.Name != this.DI_NameTextBox.Text
                    || dataItem.domain?.domainPath != ((Domain)this.DI_DomainComboBox.SelectedItem)?.domainPath
                    || dataItem.Description != this.DI_DescriptionTextBox.Text
                    || dataItem.Status != this.DI_StatusComboBox.Text
                    || dataItem.Version != this.DI_VersionTextBox.Text
                    || string.Join(",", dataItem.Keywords) != this.DI_KeywordsTextBox.Text
                    || dataItem.businessItem?.GUID != ((BusinessItem)DI_BusinessItemTextBox.Tag)?.GUID
                    || dataItem.Label != this.DI_LabelTextBox.Text
                    || dataItem.logicalDatatype?.GUID != ((LogicalDatatype)DI_DatatypeTextBox.Tag)?.GUID
                    || !dataItem.Size.HasValue && !string.IsNullOrEmpty(DI_SizeNumericUpDown.Text)
                    || dataItem.Size.HasValue && string.IsNullOrEmpty(DI_SizeNumericUpDown.Text)
                    || dataItem.Size.HasValue && dataItem.Size.Value != decimal.ToInt32(DI_SizeNumericUpDown.Value)
                    || !dataItem.precision.HasValue && !string.IsNullOrEmpty(DI_PrecisionUpDown.Text)
                    || dataItem.precision.HasValue && string.IsNullOrEmpty(DI_PrecisionUpDown.Text)
                    || dataItem.precision.HasValue && dataItem.precision.Value != decimal.ToInt32(DI_PrecisionUpDown.Value)
                    || dataItem.Format != DI_FormatTextBox.Text
                    || dataItem.InitialValue != DI_InitialValueTextBox.Text;

        }

        private void loadSelectedItemData()
        {
            if (this.selectedBusinessItem != null
                && this.DetailsTabControl.SelectedTab == this.BusinessItemsTabPage)
            {
                this.BU_NameTextBox.Text = selectedBusinessItem.Name;
                this.BU_DomainComboBox.SelectedItem = selectedBusinessItem.domain;
                this.BU_DescriptionTextBox.Text = selectedBusinessItem.Description;
                this.BU_StatusCombobox.Text = selectedBusinessItem.Status;
                this.BU_VersionTextBox.Text = selectedBusinessItem.Version;
                this.BU_KeywordsTextBox.Text = string.Join(",", selectedBusinessItem.Keywords);
                this.BU_CreatedTextBox.Text = selectedBusinessItem.CreateDate.ToString("G");
                this.BU_CreatedByTextBox.Text = selectedBusinessItem.Author;
                this.BU_ModifiedDateTextBox.Text = selectedBusinessItem.UpdateDate.ToString("G");
                this.BU_ModifiedByTextBox.Text = selectedBusinessItem.UpdatedBy;
            }
            else if (this.selectedDataItem != null
                && this.DetailsTabControl.SelectedTab == this.DataItemsTabPage)
            {
                this.DI_NameTextBox.Text = selectedDataItem.Name;
                this.DI_DescriptionTextBox.Text = selectedDataItem.Description;
                this.DI_DomainComboBox.SelectedItem = selectedDataItem.domain;
                this.DI_BusinessItemTextBox.Text = selectedDataItem.businessItem?.Name;
                this.DI_BusinessItemTextBox.Tag = selectedDataItem.businessItem;
                this.DI_LabelTextBox.Text = selectedDataItem.Label;
                this.DI_DatatypeTextBox.Text = this.selectedDataItem.logicalDatatype?.name;
                this.DI_DatatypeTextBox.Tag = this.selectedDataItem.logicalDatatype;
                this.DI_SizeNumericUpDown.Value = this.selectedDataItem.Size.HasValue ? this.selectedDataItem.Size.Value : 0;
                this.DI_SizeNumericUpDown.Text = this.selectedDataItem.Size.HasValue ? this.selectedDataItem.Size.ToString() : string.Empty;
                this.DI_PrecisionUpDown.Value = this.selectedDataItem.precision.HasValue ? this.selectedDataItem.precision.Value : 0;
                this.DI_PrecisionUpDown.Text = this.selectedDataItem.precision.HasValue ? this.selectedDataItem.precision.ToString() : string.Empty;
                this.DI_FormatTextBox.Text = this.selectedDataItem.Format;
                this.DI_InitialValueTextBox.Text = this.selectedDataItem.InitialValue;
                this.DI_StatusComboBox.Text = selectedDataItem.Status;
                this.DI_VersionTextBox.Text = selectedDataItem.Version;
                this.DI_KeywordsTextBox.Text = string.Join(",", selectedDataItem.Keywords);
                this.DI_CreationDateTextBox.Text = selectedDataItem.CreateDate.ToString("G");
                this.DI_CreatedUserTextBox.Text = selectedDataItem.Author;
                this.DI_ModifiedDateTextBox.Text = selectedDataItem.UpdateDate.ToString("G");
                this.DI_ModifiedUserTextBox.Text = selectedDataItem.UpdatedBy;
            }
        }

        internal void setColumns(List<EDDColumn> columns)
        {
            this.columnsListView.AlwaysGroupByColumn = C_TableColumn;
            this.columnsListView.AlwaysGroupBySortOrder = SortOrder.Ascending;
            this.columnsListView.ShowGroups = true;
            this.columnsListView.Objects = columns;
            //this.columnsListView.BuildList();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (selectedBusinessItem != null
                && this.DetailsTabControl.SelectedTab == this.BusinessItemsTabPage)
            {
                saveBusinessItem(this.selectedBusinessItem);
                //refresh listview
                this.BusinessItemsListView.RefreshSelectedObjects();
            }
            else if (this.selectedDataItem != null
               && this.DetailsTabControl.SelectedTab == this.DataItemsTabPage)
            {
                this.saveDataItem(this.selectedDataItem);
                //refresh listview
                this.dataItemsListView.RefreshSelectedObjects();
            }
        }
        private void unloadBusinessItemData(BusinessItem item)
        {
            item.Name = this.BU_NameTextBox.Text;
            item.domain = (Domain)this.BU_DomainComboBox.SelectedItem;
            item.Description = this.BU_DescriptionTextBox.Text;
            item.Status = this.BU_StatusCombobox.Text;
            item.Version = this.BU_VersionTextBox.Text;
            item.Keywords = this.BU_KeywordsTextBox.Text.Split(',')
                                                .Select(x => x.Trim())
                                                .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
        private void saveBusinessItem(BusinessItem item)
        {
            unloadBusinessItemData(item);
            item.Save();
        }
        private void saveDataItem(DataItem item)
        {
            this.unloadDataItem(item);
            item.Save();
        }

        private void unloadDataItem(DataItem item)
        {
            item.Name = this.DI_NameTextBox.Text;
            item.businessItem = (BusinessItem)this.DI_BusinessItemTextBox.Tag;
            item.Description = this.DI_DescriptionTextBox.Text;
            item.domain = (Domain)this.DI_DomainComboBox.SelectedItem;
            item.Label = this.DI_LabelTextBox.Text;
            item.logicalDatatype = (LogicalDatatype)this.DI_DatatypeTextBox.Tag;
            if (string.IsNullOrEmpty(this.DI_SizeNumericUpDown.Text))
                item.Size = null;
            else
                item.Size = decimal.ToInt32(this.DI_SizeNumericUpDown.Value);
            if (string.IsNullOrEmpty(DI_PrecisionUpDown.Text))
                item.precision = null;
            else
                item.precision = decimal.ToInt32(this.DI_PrecisionUpDown.Value);
            item.Format = this.DI_FormatTextBox.Text;
            item.InitialValue = this.DI_InitialValueTextBox.Text;
            item.Status = this.DI_StatusComboBox.Text;
            item.Version = this.DI_VersionTextBox.Text;
            item.Keywords = this.DI_KeywordsTextBox.Text.Split(',')
                                                .Select(x => x.Trim())
                                                .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            loadSelectedItemData();
        }
        public Domain selectedDomain
        {
            get { return domainBreadCrumb.SelectedItem.Tag as Domain; }
        }



        public event EventHandler selectedDomainChanged;
        private void domainBreadCrumb_SelectedItemChanged(object sender, EventArgs e)
        {
            this.selectedDomainChanged?.Invoke(this.selectedDomain, e);
        }

        private void navigateProjectBrowserButton_Click(object sender, EventArgs e)
        {
            this.selectedItem?.selectInProjectBrowser();
        }

        private void openPropertiesButton_Click(object sender, EventArgs e)
        {
            this.selectedItem?.openProperties();
        }

        private void BusinessItemsListView_DoubleClick(object sender, EventArgs e)
        {
            this.selectedBusinessItem?.openProperties();
        }
        public event EventHandler newButtonClick;
        private void newButton_Click(object sender, EventArgs e)
        {
            this.newButtonClick?.Invoke(sender, e);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.DetailsTabControl.SelectedTab == this.BusinessItemsTabPage)
            {
                var businessItemToDelete = this.selectedBusinessItem;
                var index = this.BusinessItemsListView.SelectedIndex;
                if (businessItemToDelete != null)
                {
                    this.BusinessItemsListView.RemoveObject(businessItemToDelete);
                    businessItemToDelete.delete();
                    this.BusinessItemsListView.SelectedIndex = index > 0 ? index - 1 : 0;
                }
            }
            else if (this.DetailsTabControl.SelectedTab == this.DataItemsTabPage)
            {
                var dataItemToDelete = this.selectedDataItem;
                var index = this.dataItemsListView.SelectedIndex;
                if (dataItemToDelete != null)
                {
                    this.dataItemsListView.RemoveObject(dataItemToDelete);
                    dataItemToDelete.delete();
                    this.dataItemsListView.SelectedIndex = index > 0 ? index - 1 : 0;
                }
            }
        }
        public event EventHandler selectedTabChanged;
        private void DetailsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reset previous items
            switch (this.selectedTab)
            {
                case GlossaryTab.BusinessItems:
                    this.previousBusinessItem = null;
                    break;
                case GlossaryTab.DataItems:
                    this.previousDataItem = null;
                    break;
            }
            this.selectedTabChanged?.Invoke(sender, e);
        }
        public GlossaryTab selectedTab
        {
            get
            {
                if (this.DetailsTabControl.SelectedTab == this.BusinessItemsTabPage) return GlossaryTab.BusinessItems;
                if (this.DetailsTabControl.SelectedTab == this.DataItemsTabPage) return GlossaryTab.DataItems;
                else return GlossaryTab.Columns;
            }
        }

        private void DI_BusinessItemSelectButton_Click(object sender, EventArgs e)
        {
            if (this.selectedDataItem != null)
            {
                var businessItem = this.selectedDataItem.selectBusinessItem();
                this.DI_BusinessItemTextBox.Text = businessItem?.Name;
                this.DI_BusinessItemTextBox.Tag = businessItem;
            }
        }
        private void dataItemsListView_DoubleClick(object sender, EventArgs e)
        {
            this.selectedDataItem?.openProperties();
        }

        private void dataItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if the previous item has been changed
            if (this.previousDataItem != null)
            {
                if (this.hasDataItemChanged(this.previousDataItem))
                {
                    var response = MessageBox.Show(this, string.Format("Save changes to {0}?", this.previousDataItem.Name)
                                                     , "Unsaved changes!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (response == DialogResult.Yes)
                    {
                        this.unloadDataItem(this.previousDataItem);
                        this.saveDataItem(this.previousDataItem);
                    }
                }
            }
            //then load the next item
            loadSelectedItemData();
            enableDisable();
            //set the previous business item
            this.previousDataItem = this.selectedDataItem;
        }

        private void DI_DatatypeSelectButton_Click(object sender, EventArgs e)
        {
            if (this.selectedDataItem != null)
            {
                var dataType = this.selectedDataItem.selectLogicalDataType();
                this.DI_DatatypeTextBox.Text = dataType?.name;
                this.DI_DatatypeTextBox.Tag = dataType;
            }
        }
    }
    public enum GlossaryTab
    {
        BusinessItems,
        DataItems,
        Columns
    }
}