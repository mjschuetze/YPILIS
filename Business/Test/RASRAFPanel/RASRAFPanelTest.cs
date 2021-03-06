﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.Business.Test.RASRAFPanel
{
    public class RASRAFPanelTest : YellowstonePathology.Business.PanelSet.Model.PanelSet
    {
        public RASRAFPanelTest()
        {
            this.m_PanelSetId = 218;
            this.m_PanelSetName = "RAS/RAF Panel";
            this.m_Abbreviation = "RAS/RAF Panel";
            this.m_CaseType = YellowstonePathology.Business.CaseType.Molecular;
            this.m_HasTechnicalComponent = true;
            this.m_HasProfessionalComponent = false;
            this.m_ResultDocumentSource = YellowstonePathology.Business.PanelSet.Model.ResultDocumentSourceEnum.YPIDatabase;
            this.m_ReportNoLetter = new YellowstonePathology.Business.ReportNoLetterR();
            this.m_Active = true;


            this.m_PanelSetOrderClassName = typeof(YellowstonePathology.Business.Test.RASRAFPanel.RASRAFPanelTestOrder).AssemblyQualifiedName;

            this.m_AllowMultiplePerAccession = true;
            this.m_ExpectedDuration = TimeSpan.FromDays(10);

            string taskDescription = "Give block to molecular for sendout.";
			this.m_TaskCollection.Add(new YellowstonePathology.Business.Task.Model.TaskRefernceLabSendout(YellowstonePathology.Business.Task.Model.TaskAssignment.Histology, taskDescription));

            string task2Description = "Receive block from Histology and send to Neo for testing.";
			this.m_TaskCollection.Add(new YellowstonePathology.Business.Task.Model.TaskRefernceLabSendout(YellowstonePathology.Business.Task.Model.TaskAssignment.Molecular, task2Description));

            this.m_TechnicalComponentFacility = new YellowstonePathology.Business.Facility.Model.NeogenomicsIrvine();
            this.m_TechnicalComponentBillingFacility = new YellowstonePathology.Business.Facility.Model.YellowstonePathologyInstituteBillings();

            YellowstonePathology.Business.Task.Model.TaskSendBlockToNeogenomics taskSendBlockToNeogenomics = new YellowstonePathology.Business.Task.Model.TaskSendBlockToNeogenomics();
            this.m_TaskCollection.Add(taskSendBlockToNeogenomics);

            YellowstonePathology.Business.Billing.Model.PanelSetCptCode cpt81210 = new YellowstonePathology.Business.Billing.Model.PanelSetCptCode(new YellowstonePathology.Business.Billing.Model.CptCodeDefinition.CPT81210(), 1);
            YellowstonePathology.Business.Billing.Model.PanelSetCptCode cpt81275 = new YellowstonePathology.Business.Billing.Model.PanelSetCptCode(new YellowstonePathology.Business.Billing.Model.CptCodeDefinition.CPT81275(), 1);
            YellowstonePathology.Business.Billing.Model.PanelSetCptCode cpt81276 = new YellowstonePathology.Business.Billing.Model.PanelSetCptCode(new YellowstonePathology.Business.Billing.Model.CptCodeDefinition.CPT81276(), 1);
            YellowstonePathology.Business.Billing.Model.PanelSetCptCode cpt81311 = new YellowstonePathology.Business.Billing.Model.PanelSetCptCode(new YellowstonePathology.Business.Billing.Model.CptCodeDefinition.CPT81311(), 1);            
            YellowstonePathology.Business.Billing.Model.PanelSetCptCode cpt81403 = new YellowstonePathology.Business.Billing.Model.PanelSetCptCode(new YellowstonePathology.Business.Billing.Model.CptCodeDefinition.CPT81403(), 1);
            YellowstonePathology.Business.Billing.Model.PanelSetCptCode cpt81404 = new YellowstonePathology.Business.Billing.Model.PanelSetCptCode(new YellowstonePathology.Business.Billing.Model.CptCodeDefinition.CPT81404(), 1);

            this.m_PanelSetCptCodeCollection.Add(cpt81210);
            this.m_PanelSetCptCodeCollection.Add(cpt81275);
            this.m_PanelSetCptCodeCollection.Add(cpt81276);
            this.m_PanelSetCptCodeCollection.Add(cpt81311);
            this.m_PanelSetCptCodeCollection.Add(cpt81403);
            this.m_PanelSetCptCodeCollection.Add(cpt81404);

            this.m_UniversalServiceIdCollection.Add(new YellowstonePathology.Business.ClientOrder.Model.UniversalServiceDefinitions.UniversalServiceMiscellaneous());
        }
    }
}
