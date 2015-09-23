﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.UI.Login.FinalizeAccession
{
    public class AliquotAndStainOrderPath
    {
        public delegate void ReturnEventHandler(object sender, UI.Navigation.PageNavigationReturnEventArgs e);
        public event ReturnEventHandler Return;

		private YellowstonePathology.Business.Persistence.ObjectTracker m_ObjectTracker;
		private YellowstonePathology.Business.Test.AccessionOrder m_AccessionOrder;
		private YellowstonePathology.Business.User.SystemIdentity m_SystemIdentity;
        private YellowstonePathology.UI.Navigation.PageNavigator m_PageNavigator;
		private YellowstonePathology.Business.Test.PanelSetOrder m_PanelSetOrder;

		public AliquotAndStainOrderPath(YellowstonePathology.Business.Test.AccessionOrder accessionOrder,
			YellowstonePathology.Business.Persistence.ObjectTracker objectTracker,
			YellowstonePathology.Business.Test.PanelSetOrder panelSetOrder,
			YellowstonePathology.Business.User.SystemIdentity systemIdentity,
			YellowstonePathology.UI.Navigation.PageNavigator pageNavigator)
		{
			this.m_ObjectTracker = objectTracker;
			this.m_AccessionOrder = accessionOrder;
			this.m_PanelSetOrder = panelSetOrder;
			this.m_SystemIdentity = systemIdentity;
			this.m_PageNavigator = pageNavigator;
		}

		public void Start()
        {
            this.ShowAliquotAndStainOrderPage();            
		}

        private void ShowAliquotAndStainOrderPage()
        {
			FinalizeAccession.AliquotAndStainOrderPage aliquotAndStainOrderPage = new FinalizeAccession.AliquotAndStainOrderPage(this.m_AccessionOrder, this.m_ObjectTracker, this.m_PanelSetOrder, this.m_SystemIdentity);
            aliquotAndStainOrderPage.Return += new FinalizeAccession.AliquotAndStainOrderPage.ReturnEventHandler(AliquotAndStainOrderPage_Return);
			aliquotAndStainOrderPage.ShowTaskOrderPage += new AliquotAndStainOrderPage.ShowTaskOrderPageEventHandler(AliquotAndStainOrderPage_ShowTaskOrderPage);
            aliquotAndStainOrderPage.ShowSpecimenMappingPage += new AliquotAndStainOrderPage.ShowSpecimenMappingPageEventHandler(AliquotAndStainOrderPage_ShowSpecimenMappingPage);
            this.m_PageNavigator.Navigate(aliquotAndStainOrderPage);				
        }

        private void AliquotAndStainOrderPage_ShowSpecimenMappingPage(object sender, EventArgs e)
        {
            SpecimenMappingPage specimenMappingPage = new SpecimenMappingPage(this.m_AccessionOrder, this.m_ObjectTracker);
            specimenMappingPage.Next += new SpecimenMappingPage.NextEventHandler(SpecimenMappingPage_Next);
            specimenMappingPage.Back += new SpecimenMappingPage.BackEventHandler(SpecimenMappingPage_Back);
            this.m_PageNavigator.Navigate(specimenMappingPage);
        }

        private void SpecimenMappingPage_Next(object sender, EventArgs e)
        {
            this.ShowAliquotAndStainOrderPage();
        }

        private void SpecimenMappingPage_Back(object sender, EventArgs e)
        {
            this.ShowAliquotAndStainOrderPage();
        }

        private void AliquotAndStainOrderPage_Return(object sender, UI.Navigation.PageNavigationReturnEventArgs e)
        {
			YellowstonePathology.Business.Task.Model.TaskOrder taskOrder = (YellowstonePathology.Business.Task.Model.TaskOrder)e.Data;
			switch (e.PageNavigationDirectionEnum)
			{
				case UI.Navigation.PageNavigationDirectionEnum.Next:
					if (this.SpecialOrdersNeedHandled() == false)
					{
						this.Return(this, new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Next, null));
					}
					break;
				case UI.Navigation.PageNavigationDirectionEnum.Back:
					this.Return(this, new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Back, null));
					break;
			}
        }

		private void AliquotAndStainOrderPage_ShowTaskOrderPage(object sender, CustomEventArgs.AcknowledgeStainOrderEventArgs e)
		{
			if (this.SpecialOrdersNeedHandled() == false)
			{
				this.ShowTaskOrderPage(e.TaskOrderStainAcknowledgement);
			}
		}

		private void ShowTaskOrderPage(YellowstonePathology.Business.Task.Model.TaskOrder taskOrder)
		{
			YellowstonePathology.UI.Login.Receiving.TaskOrderPage taskOrderPage = new Receiving.TaskOrderPage(this.m_AccessionOrder, this.m_ObjectTracker, taskOrder, PageNavigationModeEnum.Inline, this.m_SystemIdentity);
			taskOrderPage.Back += new Receiving.TaskOrderPage.BackEventHandler(TaskOrderPage_Back);
			taskOrderPage.Next += new Receiving.TaskOrderPage.NextEventHandler(TaskOrderPage_Next);
			this.m_PageNavigator.Navigate(taskOrderPage);
		}

		private void TaskOrderPage_Next(object sender, EventArgs e)
		{
			this.Return(this, new UI.Navigation.PageNavigationReturnEventArgs(UI.Navigation.PageNavigationDirectionEnum.Next, null));
		}

		private void TaskOrderPage_Back(object sender, EventArgs e)
		{
			this.ShowAliquotAndStainOrderPage();
		}

		private bool SpecialOrdersNeedHandled()
		{
			YellowstonePathology.Business.Rules.Common.RulesAutomatedStainOrder rulesAutomatedStainOrder = new Business.Rules.Common.RulesAutomatedStainOrder();
			YellowstonePathology.Business.Rules.ExecutionStatus executionStatus = new Business.Rules.ExecutionStatus();
			rulesAutomatedStainOrder.Execute(executionStatus, this.m_AccessionOrder);

			if (executionStatus.Halted == false)
			{
				System.Windows.MessageBox.Show(executionStatus.ExecutionMessagesString);
			}

			return !executionStatus.Halted;
		}
	}
}
