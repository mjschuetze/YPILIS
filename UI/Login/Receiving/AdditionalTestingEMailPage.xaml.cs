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
using System.ComponentModel;

namespace YellowstonePathology.UI.Login.Receiving
{
    /// <summary>
    /// Interaction logic for AdditionalTestingEMailPage.xaml
    /// </summary>
    public partial class AdditionalTestingEMailPage : UserControl, INotifyPropertyChanged, Business.Interface.IPersistPageChanges
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void BackEventHandler(object sender, EventArgs e);
        public event BackEventHandler Back;
        public delegate void NextEventHandler(object sender, EventArgs e);
        public event NextEventHandler Next;

        private YellowstonePathology.Business.Test.AccessionOrder m_AccessionOrder;
        private YellowstonePathology.Business.Test.PanelSetOrder m_PanelSetOrder;
        private YellowstonePathology.Business.Persistence.ObjectTracker m_ObjectTracker;
        private YellowstonePathology.Business.User.SystemIdentity m_SystemIdentity;

        public AdditionalTestingEMailPage(YellowstonePathology.Business.Test.PanelSetOrder panelSetOrder,
            YellowstonePathology.Business.Test.AccessionOrder accessionOrder,
            YellowstonePathology.Business.Persistence.ObjectTracker objectTracker,
            YellowstonePathology.Business.User.SystemIdentity systemIdentity)
        {
            this.m_PanelSetOrder = panelSetOrder;
            this.m_AccessionOrder = accessionOrder;
            this.m_ObjectTracker = objectTracker;
            this.m_SystemIdentity = systemIdentity;

            if (string.IsNullOrEmpty(this.m_PanelSetOrder.AdditionalTestingEmailAddress) == true)
            {
                YellowstonePathology.Business.Domain.Physician physician = YellowstonePathology.Business.Gateway.PhysicianClientGateway.GetPhysicianByPhysicianId(this.m_AccessionOrder.PhysicianId);
                this.m_PanelSetOrder.AdditionalTestingEmailAddress = physician.PublishNotificationEmailAddress;
            }

            if(string.IsNullOrEmpty(this.m_PanelSetOrder.AdditionalTestingEmailMessage) == true)
            {
                this.m_PanelSetOrder.AdditionalTestingEmailMessage = "Additional Testing is being performed.  Use YPI Connect to see details." + Environment.NewLine +
                    Environment.NewLine + Environment.NewLine + "If you don't have access to YPI Connect please call us at (406)238-6360.";
            }

            InitializeComponent();

            DataContext = this;
        }

        public YellowstonePathology.Business.Test.PanelSetOrder PanelSetOrder
        {
            get { return this.m_PanelSetOrder; }
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
            this.m_ObjectTracker.SubmitChanges(this.m_AccessionOrder);
        }

        public void UpdateBindingSources()
        {

        }

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Back != null) this.Back(this, new EventArgs());
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (this.Next != null) this.Next(this, new EventArgs());
        }

        private void HyperLinkSendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.m_PanelSetOrder.AdditionalTestingEmailAddress) == false)
            {
                if (string.IsNullOrEmpty(this.m_PanelSetOrder.AdditionalTestingEmailMessage) == false)
                {
                    YellowstonePathology.Business.PanelSet.Model.PanelSetCollection panelSetCollection = YellowstonePathology.Business.PanelSet.Model.PanelSetCollection.GetAll();
                    YellowstonePathology.Business.PanelSet.Model.PanelSet panelSet = panelSetCollection.GetPanelSet(this.m_PanelSetOrder.PanelSetId);
                    string subject = "Additional Testing has been ordered: " + panelSet.PanelSetName;

                    System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress("Results@YPII.com");
                    //System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(this.m_PanelSetOrder.AdditionalTestingEmailAddress);
                    System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress("sid.harder@YPII.com");
                    //System.Net.Mail.MailAddress bcc = new System.Net.Mail.MailAddress("Results@YPII.com");

                    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);
                    message.Subject = subject;
                    message.Body = this.m_PanelSetOrder.AdditionalTestingEmailMessage;
                    //message.Bcc.Add(bcc);

                    this.m_PanelSetOrder.AdditionalTestingEmailSent = true;
                    this.m_PanelSetOrder.TimeAdditionalTestingEmailSent = DateTime.Now;
                    this.m_PanelSetOrder.AdditionalTestingEmailSentBy = this.m_SystemIdentity.User.UserName;

                    this.NotifyPropertyChanged(string.Empty);

                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("10.1.2.111");
                    client.Credentials = new System.Net.NetworkCredential("Results", "p0046ep0046e");
                    client.Send(message);
                }
                else
                {
                    MessageBox.Show("The Email may not be sent without a message.", "Missing Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("The Email may not be sent without an address.", "Missing Address", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}