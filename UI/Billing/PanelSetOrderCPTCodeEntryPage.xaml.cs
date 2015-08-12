﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace YellowstonePathology.UI.Billing
{	
	public partial class PanelSetOrderCPTCodeEntryPage : UserControl, INotifyPropertyChanged, Business.Interface.IPersistPageChanges
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public delegate void NextEventHandler(object sender, EventArgs e);
		public event NextEventHandler Next;

		public delegate void BackEventHandler(object sender, EventArgs e);
		public event BackEventHandler Back;

        private YellowstonePathology.Business.Test.PanelSetOrder m_PanelSetOrder;
        private YellowstonePathology.Business.Test.PanelSetOrderCPTCode m_PanelSetOrderCPTCode;

        public PanelSetOrderCPTCodeEntryPage(YellowstonePathology.Business.Test.PanelSetOrder panelSetOrder, int clientId)
		{
            this.m_PanelSetOrder = panelSetOrder;
            this.m_PanelSetOrderCPTCode = this.m_PanelSetOrder.PanelSetOrderCPTCodeCollection.GetNextItem(panelSetOrder.ReportNo);
            this.m_PanelSetOrderCPTCode.Quantity = 1;
            this.m_PanelSetOrderCPTCode.ClientId = clientId;
            this.m_PanelSetOrderCPTCode.EntryType = "Manual Entry";
            this.m_PanelSetOrderCPTCode.CodeableType = "Billable Test";

			InitializeComponent();			
			DataContext = this;
		}

        public YellowstonePathology.Business.Test.PanelSetOrderCPTCode PanelSetOrderCPTCode
        {
            get { return this.m_PanelSetOrderCPTCode; }
        }

		public void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}		

		public bool OkToSaveOnNavigation(Type pageNavigatingTo)
		{
			return true;
		}

		public bool OkToSaveOnClose()
		{
			return true;
		}

		public void Save()
		{
			
		}

		public void UpdateBindingSources()
		{
		}

		private void ButtonNext_Click(object sender, RoutedEventArgs e)
		{
            if (this.OkToAddPanelSetOrderCPTCode() == true)
            {
                this.m_PanelSetOrder.PanelSetOrderCPTCodeCollection.Add(this.m_PanelSetOrderCPTCode);
                if (this.Next != null) this.Next(this, new EventArgs());
            }			
		}

        private bool OkToAddPanelSetOrderCPTCode()
        {
            bool result = true;
            string message = null;

            if (this.m_PanelSetOrderCPTCode.Quantity < 1)
            {
                result = false;
                message = "The quantity is not valid.";
            }
            if (string.IsNullOrEmpty(this.m_PanelSetOrderCPTCode.CPTCode) == true)
            {
                result = false;
                message = "The CPT code cannot be blank";
            }

            if (result == false)
            {
                MessageBox.Show(message);
            }

            return result;
        }

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			if (this.Back != null) this.Back(this, new EventArgs());
		}		
	}
}
