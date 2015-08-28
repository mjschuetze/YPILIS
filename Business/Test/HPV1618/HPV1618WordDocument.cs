﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.Business.Test.HPV1618
{
	public class HPV1618WordDocument : YellowstonePathology.Business.Document.CaseReportV2
	{
		public override void Render(string masterAccessionNo, string reportNo, YellowstonePathology.Business.Document.ReportSaveModeEnum reportSaveEnum)
		{
			this.m_ReportNo = reportNo;
			this.m_ReportSaveEnum = reportSaveEnum;
			this.m_AccessionOrder = YellowstonePathology.Business.Gateway.AccessionOrderGateway.GetAccessionOrderByMasterAccessionNo(masterAccessionNo);

			this.m_PanelSetOrder = this.m_AccessionOrder.PanelSetOrderCollection.GetPanelSetOrder(reportNo);
			YellowstonePathology.Business.Test.HPV1618.PanelSetOrderHPV1618 panelSetOrderHPV1618 = (YellowstonePathology.Business.Test.HPV1618.PanelSetOrderHPV1618)this.m_PanelSetOrder;

			this.m_TemplateName = @"\\CFileServer\Documents\ReportTemplates\XmlTemplates\HPV1618Genotyping.6.xml";
			base.OpenTemplate();

			base.SetDemographicsV2();

			YellowstonePathology.Business.Specimen.Model.SpecimenOrder specimenOrder = this.m_AccessionOrder.SpecimenOrderCollection.GetSpecimenOrder(this.m_PanelSetOrder.OrderedOn, this.m_PanelSetOrder.OrderedOnId);
			base.ReplaceText("specimen_description", specimenOrder.Description);            

			string collectionDateTimeString = YellowstonePathology.Business.Helper.DateTimeExtensions.CombineDateAndTime(specimenOrder.CollectionDate, specimenOrder.CollectionTime);
			this.SetXmlNodeData("date_time_collected", collectionDateTimeString);

			YellowstonePathology.Business.Document.AmendmentSection amendmentSection = new YellowstonePathology.Business.Document.AmendmentSection();
			amendmentSection.SetAmendment(this.m_PanelSetOrder.AmendmentCollection, this.m_ReportXml, this.m_NameSpaceManager, false);

			base.ReplaceText("hpv16_result", panelSetOrderHPV1618.HPV16Result);
			base.ReplaceText("hpv18_result", panelSetOrderHPV1618.HPV18Result);

            if (panelSetOrderHPV1618.Indication == YellowstonePathology.Business.Test.HPV1618.HPV1618Indication.SquamousCellCarcinoma)
            {
                base.ReplaceText("report_interpretation_header", "Interpretation");
                base.ReplaceText("report_interpretation", panelSetOrderHPV1618.Interpretation);
				base.ReplaceText("pathologist_signature", panelSetOrderHPV1618.Signature);

                if (panelSetOrderHPV1618.FinalTime.HasValue == true)
                {
                    string esignedHeader = "*** E-signed " + panelSetOrderHPV1618.FinalTime.Value.ToString("MM/dd/yyyy HH:mm") + "***";
                    base.ReplaceText("esigned_header", esignedHeader);
                }
            }
            else
            {
                base.DeleteRow("report_interpretation_header");
                base.DeleteRow("report_interpretation");
                base.DeleteRow("pathologist_signature");
                base.DeleteRow("esigned_header");
            }

            if (string.IsNullOrEmpty(panelSetOrderHPV1618.Comment) == false)
            {
                base.ReplaceText("report_comment", panelSetOrderHPV1618.Comment);
            }
            else
            {
                base.DeleteRow("report_comment");
            }
            
            base.ReplaceText("report_method", panelSetOrderHPV1618.Method);

			this.ReplaceText("report_date", BaseData.GetShortDateString(this.m_PanelSetOrder.FinalDate));
			this.SetXmlNodeData("pathologist_signature", this.m_PanelSetOrder.Signature);

			this.SetReportDistribution();
			this.SetCaseHistory();

			this.SaveReport();
		}

		public override void Publish()
		{
			base.Publish();
		}
	}
}
