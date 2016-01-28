﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.UI.Billing
{
    public class BillingPath
    {
        private BillingWindowPrimary m_BillingWindowPrimary;
        private BillingWindowSecondary m_BillingWindowSecondary;
		private TifDocumentViewer m_TifDocumentViewer;

		private Business.Search.ReportSearchList m_ReportSearchList;
        private Business.User.SystemIdentity m_SystemIdentity;        
        private BillingPage m_BillingPage;
		private YellowstonePathology.Business.Test.AccessionOrder m_AccessionOrder;

		public BillingPath(Business.Search.ReportSearchList reportSearchList, Business.User.SystemIdentity systemIdentity)
        {            
            this.m_ReportSearchList = reportSearchList;
            this.m_SystemIdentity = systemIdentity;            
        }       

        private void GetAccessionOrder(string reportNo)
        {
			this.m_AccessionOrder = YellowstonePathology.Business.Gateway.AccessionOrderGateway.GetAccessionOrderByReportNo(reportNo);
		}

        public void Start()
        {
            if (this.m_ReportSearchList.CurrentReportSearchItem != null)
            {
                this.m_BillingWindowPrimary = new BillingWindowPrimary(this.m_SystemIdentity);                
                this.m_BillingWindowPrimary.Show();

                if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == true)
                {
                    this.m_BillingWindowSecondary = new BillingWindowSecondary();                    
                    this.m_BillingWindowPrimary.PageNavigator.ShowSecondMonitorWindow(this.m_BillingWindowSecondary);
                }

				this.GetAccessionOrder(this.m_ReportSearchList.CurrentReportSearchItem.ReportNo);
				this.ShowBillingPage(this.m_AccessionOrder);                
			}
        }        

        private void ShowBillingPage(YellowstonePathology.Business.Test.AccessionOrder accessionOrder)
        {            
            this.m_BillingPage = new BillingPage(this.m_ReportSearchList.CurrentReportSearchItem.ReportNo, accessionOrder, this.m_SystemIdentity);
            this.m_BillingPage.Next += new BillingPage.NextEventHandler(BillingPage_Next);
            this.m_BillingPage.Back += new BillingPage.BackEventHandler(BillingPage_Back);
            this.m_BillingPage.Close += new BillingPage.CloseEventHandler(BillingPage_Close);
            this.m_BillingPage.ShowXPSDocument += new BillingPage.ShowXPSDocumentEventHandler(BillingPage_ShowXPSDocument);
            this.m_BillingPage.ShowTIFDocument += new BillingPage.ShowTIFDocumentEventHandler(BillingPage_ShowTIFDocument);
            this.m_BillingPage.ShowICDCodeEntry += new BillingPage.ShowICDCodeEntryEventHandler(BillingPage_ShowICDCodeEntry);
            this.m_BillingPage.ShowCPTCodeEntry += new BillingPage.ShowCPTCodeEntryEventHandler(BillingPage_ShowCPTCodeEntry);
			this.m_BillingPage.ShowPatientDetailPage += new BillingPage.ShowPatientDetailPageEventHandler(BillingPage_ShowPatientDetailPage);

            if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == true)
            {
                this.m_BillingWindowSecondary.PageNavigator.ClearCurrentPage();                
            }                                                  
         
            this.m_BillingWindowPrimary.PageNavigator.Navigate(this.m_BillingPage);
        }

		private void BillingPage_ShowPatientDetailPage(object sender, EventArgs e)
		{
            if (string.IsNullOrEmpty(this.m_AccessionOrder.SvhMedicalRecord) == false)
            {
                YellowstonePathology.Business.Patient.Model.SVHBillingDataCollection svhBillingDataCollection = YellowstonePathology.Business.Gateway.AccessionOrderGateway.GetSVHBillingDataCollection(this.m_AccessionOrder.SvhMedicalRecord);
                if (svhBillingDataCollection.Count > 0)
                {
                    YellowstonePathology.Business.Patient.Model.SVHBillingData svhBillingDate = svhBillingDataCollection.GetMostRecent();
                    YellowstonePathology.UI.Billing.PatientDetailPage patientDetailPage = new PatientDetailPage(svhBillingDate);
                    patientDetailPage.Back += new Billing.PatientDetailPage.BackEventHandler(PatientDetailPage_Back);
                    patientDetailPage.Next += new Billing.PatientDetailPage.NextEventHandler(PatientDetailPage_Next);

                    if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == false)
                    {
                        this.m_BillingWindowSecondary = new BillingWindowSecondary();
                        this.m_BillingWindowSecondary.Show();
                    }
                    this.m_BillingWindowSecondary.PageNavigator.Navigate(patientDetailPage);
                }
                else
                {
                    System.Windows.MessageBox.Show("No additional data to show.");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("The Medical Record Number is blank. No additional data to show.");
            }
		}

		private void PatientDetailPage_Back(object sender, EventArgs e)
		{
			YellowstonePathology.Business.Document.CaseDocumentCollection caseDocumentCollection = new Business.Document.CaseDocumentCollection(this.m_ReportSearchList.CurrentReportSearchItem.ReportNo);
			YellowstonePathology.Business.Document.CaseDocument firstRequisition = caseDocumentCollection.GetFirstRequisition();
			if (this.m_TifDocumentViewer != null) this.m_TifDocumentViewer.Close();
			if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == false)
			{
				this.m_BillingWindowSecondary.Close();
			}
			if (firstRequisition != null)
			{
				this.BillingPage_ShowTIFDocument(this, new CustomEventArgs.FileNameReturnEventArgs(firstRequisition.FullFileName));
			}
		}

		private void PatientDetailPage_Next(object sender, EventArgs e)
		{
			YellowstonePathology.Business.Document.CaseDocumentCollection caseDocumentCollection = new Business.Document.CaseDocumentCollection(this.m_ReportSearchList.CurrentReportSearchItem.ReportNo);
			YellowstonePathology.Business.Document.CaseDocument firstRequisition = caseDocumentCollection.GetFirstRequisition();
			if (this.m_TifDocumentViewer != null) this.m_TifDocumentViewer.Close();
			if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == false)
			{
				this.m_BillingWindowSecondary.Close();
			}
			if (firstRequisition != null)
			{
				this.BillingPage_ShowTIFDocument(this, new CustomEventArgs.FileNameReturnEventArgs(firstRequisition.FullFileName));
			}
		}

        private void BillingPage_ShowCPTCodeEntry(object sender, CustomEventArgs.PanelSetOrderReturnEventArgs e)
        {
            YellowstonePathology.UI.Billing.PanelSetOrderCPTCodeEntryPage panelSetOrderCPTCodeEntryPage = new PanelSetOrderCPTCodeEntryPage(e.PanelSetOrder, this.m_AccessionOrder.ClientId);
            panelSetOrderCPTCodeEntryPage.Next += new PanelSetOrderCPTCodeEntryPage.NextEventHandler(PanelSetOrderCPTCodeEntryPage_Next);
			panelSetOrderCPTCodeEntryPage.Back += new PanelSetOrderCPTCodeEntryPage.BackEventHandler(PanelSetOrderCPTCodeEntryPage_Back);
            this.m_BillingWindowPrimary.PageNavigator.Navigate(panelSetOrderCPTCodeEntryPage);            
        }

        private void PanelSetOrderCPTCodeEntryPage_Next(object sender, EventArgs e)
        {
            this.m_BillingWindowPrimary.PageNavigator.Navigate(this.m_BillingPage);
        }

		private void PanelSetOrderCPTCodeEntryPage_Back(object sender, EventArgs e)
		{
			this.m_BillingWindowPrimary.PageNavigator.Navigate(this.m_BillingPage);
		}

        private void BillingPage_ShowICDCodeEntry(object sender, CustomEventArgs.AccessionOrderWithTrackerReturnEventArgs e)
        {
			YellowstonePathology.UI.Login.ICDEntryPage icdEntryPage = new YellowstonePathology.UI.Login.ICDEntryPage(e.AccessionOrder, this.m_ReportSearchList.CurrentReportSearchItem.ReportNo, this.m_SystemIdentity);
            icdEntryPage.Next += new Login.ICDEntryPage.NextEventHandler(IcdEntryPage_Next);
            this.m_BillingWindowPrimary.PageNavigator.Navigate(icdEntryPage);            
        }

        private void IcdEntryPage_Next(object sender, EventArgs e)
        {
            this.m_BillingWindowPrimary.PageNavigator.Navigate(this.m_BillingPage);
        }

        private void BillingPage_ShowTIFDocument(object sender, CustomEventArgs.FileNameReturnEventArgs e)
        {
            if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == false)
            {
                this.ShowTIFDocumentSingleMonitor(e.FileName);
            }
            else
            {
                this.ShowTIFDocumentDualMonitor(e.FileName);
            }
        }

        private void BillingPage_ShowXPSDocument(object sender, CustomEventArgs.FileNameReturnEventArgs e)
        {
            if (this.m_BillingWindowPrimary.PageNavigator.HasDualMonitors() == false)
            {
                this.ShowXPSDocumentSingleMonitor(e.FileName);
            }
            else
            {
                this.ShowXPSDocumentDualMonitor(e.FileName);
            }
        }        

        private void ShowXPSDocumentDualMonitor(string fileName)
        {            
            XpsDocumentViewerPage xpsDocumentViewerPage = new XpsDocumentViewerPage(System.Windows.Visibility.Collapsed, System.Windows.Visibility.Collapsed);
            xpsDocumentViewerPage.ViewDocument(fileName);
            this.m_BillingWindowSecondary.PageNavigator.Navigate(xpsDocumentViewerPage);
        }

        private void ShowTIFDocumentDualMonitor(string fileName)
        {
            TifDocumentViewerPage tifDocumentViewerPage = new TifDocumentViewerPage();
            tifDocumentViewerPage.Load(fileName);
            this.m_BillingWindowSecondary.PageNavigator.Navigate(tifDocumentViewerPage);
        }

        private void ShowXPSDocumentSingleMonitor(string fileName)
        {                        
            XpsDocumentViewer xpsDocumentViewer = new XpsDocumentViewer();
            xpsDocumentViewer.ViewDocument(fileName);
            xpsDocumentViewer.Show();            
        }

        private void ShowTIFDocumentSingleMonitor(string fileName)
        {
			this.m_TifDocumentViewer = new TifDocumentViewer();
			this.m_TifDocumentViewer.Load(fileName);
			this.m_TifDocumentViewer.Show();
		}

        private void BillingPage_Close(object sender, EventArgs e)
        {
            this.m_BillingWindowPrimary.Close();
        }

        private void BillingPage_Back(object sender, EventArgs e)
        {
            this.m_ReportSearchList.MoveBack();
            if (this.m_ReportSearchList.BeginningOfList == false)
            {
				if (this.m_TifDocumentViewer != null) this.m_TifDocumentViewer.Close();
				this.GetAccessionOrder(this.m_ReportSearchList.CurrentReportSearchItem.ReportNo);
				this.ShowBillingPage(this.m_AccessionOrder);
			}
            else
            {
                System.Windows.MessageBox.Show("You have reached the beginning of the list.");
            }
        }

        private void BillingPage_Next(object sender, EventArgs e)
        {
            this.m_ReportSearchList.MoveNext();
            if (this.m_ReportSearchList.EndOfList == false)
            {
				if (this.m_TifDocumentViewer != null) this.m_TifDocumentViewer.Close();
				this.GetAccessionOrder(this.m_ReportSearchList.CurrentReportSearchItem.ReportNo);
				this.ShowBillingPage(this.m_AccessionOrder);
			}
            else
            {
                System.Windows.MessageBox.Show("You have reached the end of the list.");
            }
        }        
    }
}
