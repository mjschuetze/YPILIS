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

namespace YellowstonePathology.UI.Login.FinalizeAccession
{
	/// <summary>
	/// Interaction logic for AssignmentPage.xaml
	/// </summary>
	public partial class AssignmentPage : UserControl, YellowstonePathology.Business.Interface.IPersistPageChanges
	{
		public delegate void ReturnEventHandler(object sender, UI.Navigation.PageNavigationReturnEventArgs e);
		public event ReturnEventHandler Return;

        private bool m_IsLoaded;
		private YellowstonePathology.Business.Persistence.ObjectTracker m_ObjectTracker;
		private YellowstonePathology.Business.Test.AccessionOrder m_AccessionOrder;
		private string m_PageHeaderText = "Case Asssignment Page";
		private YellowstonePathology.Business.User.SystemUserCollection m_PathologistUsers;
        private YellowstonePathology.Business.Facility.Model.FacilityCollection m_FacilityCollection;

		public AssignmentPage(YellowstonePathology.Business.Test.AccessionOrder accessionOrder,
			YellowstonePathology.Business.Persistence.ObjectTracker objectTracker)
		{
            this.m_IsLoaded = false;
			this.m_ObjectTracker = objectTracker;
			this.m_AccessionOrder = accessionOrder;
            this.m_FacilityCollection = Business.Facility.Model.FacilityCollection.GetAllFacilities();

			this.m_PathologistUsers = YellowstonePathology.Business.User.SystemUserCollectionInstance.Instance.SystemUserCollection.GetUsersByRole(YellowstonePathology.Business.User.SystemUserRoleDescriptionEnum.Pathologist, true);
			
			InitializeComponent();

			DataContext = this;
            this.Loaded += new RoutedEventHandler(AssignmentPage_Loaded);
		}

        private void AssignmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.m_IsLoaded = true;
        }		

		public string PageHeaderText
		{
			get { return this.m_PageHeaderText; }
		}

		public YellowstonePathology.Business.User.SystemUserCollection PathologistUsers
		{
			get { return this.m_PathologistUsers; }
		}

		public YellowstonePathology.Business.Test.AccessionOrder AccessionOrder
		{
			get { return this.m_AccessionOrder; }
		}

        public YellowstonePathology.Business.Facility.Model.FacilityCollection FacilityCollection
        {
            get { return this.m_FacilityCollection; }
        }

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			UI.Navigation.PageNavigationReturnEventArgs args = new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Back, null);
			this.Return(this, args);
		}

		private void ButtonNext_Click(object sender, RoutedEventArgs e)
		{
			YellowstonePathology.Business.Test.TechnicalOnly.TechnicalOnlyTest panelSetTechnicalOnly = new Business.Test.TechnicalOnly.TechnicalOnlyTest();
            if (this.m_AccessionOrder.PanelSetOrderCollection.HasGrossBeenOrdered() == true)
            {
                YellowstonePathology.Business.Test.PanelSetOrder panelSetOrder = this.m_AccessionOrder.PanelSetOrderCollection.GetPanelSetOrderByTestId(48);
                if (panelSetOrder.AssignedToId == 0)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("A Gross Only has been ordered but the case has not been assigned.  Are you sure you want to continue?", "Assignement", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        UI.Navigation.PageNavigationReturnEventArgs args = new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Next, null);
                        this.Return(this, args);
                    }
                }
                else
                {
                    UI.Navigation.PageNavigationReturnEventArgs args = new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Next, null);
                    this.Return(this, args);
                }
            }
            else if (this.m_AccessionOrder.PanelSetOrderCollection.HasUnassignedPanelSetOrder(panelSetTechnicalOnly.PanelSetId) == true)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("There is an order that has not been assigned are you sure you want to continue?", "Assignement", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    UI.Navigation.PageNavigationReturnEventArgs args = new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Next, null);
                    this.Return(this, args);
                }
            }
            else
            {
                UI.Navigation.PageNavigationReturnEventArgs args = new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Next, null);
                this.Return(this, args);
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
			this.m_ObjectTracker.SubmitChanges(this.m_AccessionOrder);
		}

		public void UpdateBindingSources()
		{

		}

        private void ComboBoxUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.m_IsLoaded == true)
            {
                ComboBox comboBox = (ComboBox)sender;
                YellowstonePathology.Business.Test.PanelSetOrder panelSetOrder = (YellowstonePathology.Business.Test.PanelSetOrder)comboBox.Tag;
                YellowstonePathology.Business.User.SystemUser systemUser = (YellowstonePathology.Business.User.SystemUser)comboBox.SelectedItem;
                YellowstonePathology.Business.Facility.Model.YellowstonePathologyInstituteBillings ypiBLGS = new Business.Facility.Model.YellowstonePathologyInstituteBillings();
                YellowstonePathology.Business.Facility.Model.ButtePathology buttePathology = new Business.Facility.Model.ButtePathology();

                if (systemUser.UserId == 5132 || systemUser.UserId == 5133)
                {
                    panelSetOrder.TechnicalComponentFacilityId = ypiBLGS.FacilityId;
                    panelSetOrder.TechnicalComponentBillingFacilityId = ypiBLGS.FacilityId;
                    panelSetOrder.ProfessionalComponentFacilityId = buttePathology.FacilityId;
                    panelSetOrder.ProfessionalComponentBillingFacilityId = buttePathology.FacilityId;
                }
                else
                {
                    if (panelSetOrder.ProfessionalComponentFacilityId == buttePathology.FacilityId)
                    {
                        YellowstonePathology.Business.Facility.Model.YellowstonePathologistBillings ypBLGS = new YellowstonePathology.Business.Facility.Model.YellowstonePathologistBillings();
                        panelSetOrder.TechnicalComponentFacilityId = ypiBLGS.FacilityId;
                        panelSetOrder.TechnicalComponentBillingFacilityId = ypiBLGS.FacilityId;
                        panelSetOrder.ProfessionalComponentFacilityId = ypBLGS.FacilityId;
                        panelSetOrder.ProfessionalComponentBillingFacilityId = ypBLGS.FacilityId;
                    }
                }
            }
        }
	}
}
