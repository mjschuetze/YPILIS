﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace YellowstonePathology.Business.Test.ComprehensiveColonCancerProfile
{
	public class ComprehensiveColonCancerProfileWordDocument : YellowstonePathology.Business.Document.CaseReportV2
	{
        public ComprehensiveColonCancerProfileWordDocument(Business.Test.AccessionOrder accessionOrder, Business.Test.PanelSetOrder panelSetOrder, YellowstonePathology.Business.Document.ReportSaveModeEnum reportSaveMode) 
            : base(accessionOrder, panelSetOrder, reportSaveMode)
        {

        }

        public override void Render()
		{			
			this.m_TemplateName = @"\\CFileServer\Documents\ReportTemplates\XmlTemplates\ComprehensiveColonCancerProfile.1.xml";
			this.OpenTemplate();
			this.SetDemographicsV2();
			this.SetReportDistribution();

			ComprehensiveColonCancerProfile comprehensiveColonCancerProfile = (ComprehensiveColonCancerProfile)this.m_AccessionOrder.PanelSetOrderCollection.GetPanelSetOrder(this.m_PanelSetOrder.ReportNo);
			ComprehensiveColonCancerProfileResult comprehensiveColonCancerProfileResult = new ComprehensiveColonCancerProfileResult(this.m_AccessionOrder, comprehensiveColonCancerProfile);

			YellowstonePathology.Business.Specimen.Model.SpecimenOrder specimenOrder = this.m_AccessionOrder.SpecimenOrderCollection.GetSpecimenOrderByOrderTarget(comprehensiveColonCancerProfile.OrderedOnId);
            YellowstonePathology.Business.Test.AliquotOrder aliquotOrder = this.m_AccessionOrder.SpecimenOrderCollection.GetAliquotOrder(comprehensiveColonCancerProfile.OrderedOnId);
            string specimenDescription = specimenOrder.Description;
            if (aliquotOrder != null) specimenDescription += ": " + aliquotOrder.Label;

			base.ReplaceText("report_interpretation", comprehensiveColonCancerProfile.Interpretation);
            base.ReplaceText("specimen_description", specimenDescription);
			base.ReplaceText("surgical_reportno", comprehensiveColonCancerProfileResult.PanelSetOrderSurgical.ReportNo);
			base.ReplaceText("specimen_diagnosis", comprehensiveColonCancerProfileResult.SurgicalSpecimen.Diagnosis);
			base.ReplaceText("ajcc_stage", comprehensiveColonCancerProfileResult.PanelSetOrderSurgical.AJCCStage);

            if (comprehensiveColonCancerProfileResult.IHCResult != null)
            {
                base.ReplaceText("mlh1_result", comprehensiveColonCancerProfileResult.IHCResult.MLH1Result.Description);
                base.ReplaceText("msh2_result", comprehensiveColonCancerProfileResult.IHCResult.MSH2Result.Description);
                base.ReplaceText("msh6_result", comprehensiveColonCancerProfileResult.IHCResult.MSH6Result.Description);
                base.ReplaceText("pms2_result", comprehensiveColonCancerProfileResult.IHCResult.PMS2Result.Description);
            }
            else
            {
                base.ReplaceText("mlh1_result", "Not Included");
                base.ReplaceText("msh2_result", "Not Included");
                base.ReplaceText("msh6_result", "Not Included");
                base.ReplaceText("pms2_result", "Not Included");
            }
            if (comprehensiveColonCancerProfileResult.PanelSetOrderLynchSyndromeIHC != null)
            {
                base.ReplaceText("ihc_reportno", comprehensiveColonCancerProfileResult.PanelSetOrderLynchSyndromeIHC.ReportNo);
            }
            else
            {
                base.ReplaceText("ihc_reportno", "Not Included");
            }
            
            if (comprehensiveColonCancerProfileResult.RASRAFIsOrdered == true)
            {
                base.ReplaceText("braf_result", comprehensiveColonCancerProfileResult.RASRAFTestOrder.BRAFResult);
                base.ReplaceText("braf_reportno", comprehensiveColonCancerProfile.ReportNo);

                base.ReplaceText("kras_result", comprehensiveColonCancerProfileResult.RASRAFTestOrder.KRASResult);
                base.ReplaceText("kras_reportno", comprehensiveColonCancerProfile.ReportNo);

                base.ReplaceText("nras_result", comprehensiveColonCancerProfileResult.RASRAFTestOrder.NRASResult);
                base.ReplaceText("nras_reportno", comprehensiveColonCancerProfile.ReportNo);

                base.ReplaceText("hras_result", comprehensiveColonCancerProfileResult.RASRAFTestOrder.HRASResult);
                base.ReplaceText("hras_reportno", comprehensiveColonCancerProfile.ReportNo);

            }                        

            
            if (comprehensiveColonCancerProfileResult.PanelSetOrderMLH1MethylationAnalysis != null)
			{
				base.ReplaceText("mlh1promoter_result", comprehensiveColonCancerProfileResult.PanelSetOrderMLH1MethylationAnalysis.Result);
				base.ReplaceText("mlh1promoter_reportno", comprehensiveColonCancerProfileResult.PanelSetOrderMLH1MethylationAnalysis.ReportNo);
			}
			else
			{
				this.DeleteRow("mlh1promoter_result");
			}

            /*
            if (comprehensiveColonCancerProfileResult.KRASStandardIsOrderd == true)
            {
                base.ReplaceText("kras_result", comprehensiveColonCancerProfileResult.KRASStandardTestOrder.Result);
                base.ReplaceText("kras_report_no", comprehensiveColonCancerProfileResult.KRASStandardTestOrder.ReportNo);
            }
            else
            {
                this.DeleteRow("kras_result");
            }

            if (comprehensiveColonCancerProfileResult.BRAFV600EKIsOrdered == true)
            {
                base.ReplaceText("braf_result", comprehensiveColonCancerProfileResult.BRAFV600EKTestOrder.Result);
                base.ReplaceText("braf_report_no", comprehensiveColonCancerProfileResult.BRAFV600EKTestOrder.ReportNo);
            }
            else
            {
                this.DeleteRow("braf_result");
            }

            if (comprehensiveColonCancerProfileResult.KRASExon23MutationIsOrdered == true)
            {
                base.ReplaceText("kras23_result", comprehensiveColonCancerProfileResult.KRASExon23MutationTestOrder.Result);
                base.ReplaceText("kras23_report_no", comprehensiveColonCancerProfileResult.KRASExon23MutationTestOrder.ReportNo);
            }
            else
            {
                this.DeleteRow("kras23_result");
            }

            if (comprehensiveColonCancerProfileResult.KRASExon4MutationIsOrdered == true)
            {
                base.ReplaceText("kras4_result", comprehensiveColonCancerProfileResult.KRASExon4MutationTestOrder.Result);
                base.ReplaceText("kras4_report_no", comprehensiveColonCancerProfileResult.KRASExon4MutationTestOrder.ReportNo);
            }
            else
            {
                this.DeleteRow("kras4_result");
            }

            if (comprehensiveColonCancerProfileResult.NRASMutationAnalysisIsOrdered == true)
            {
                base.ReplaceText("nras_result", comprehensiveColonCancerProfileResult.NRASMutationAnalysisTestOrder.Result);
                base.ReplaceText("nras_report_no", comprehensiveColonCancerProfileResult.NRASMutationAnalysisTestOrder.ReportNo);
            }
            else
            {
                this.DeleteRow("nras_result");
            }    
            */

            base.ReplaceText("pathologist_signature", comprehensiveColonCancerProfile.Signature);

			this.SaveReport();
		}

		public override void Publish()
		{
			base.Publish();
		}
	}
}
