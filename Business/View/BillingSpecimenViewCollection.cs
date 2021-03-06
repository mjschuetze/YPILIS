﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace YellowstonePathology.Business.View
{
	public class BillingSpecimenViewCollection : ObservableCollection<BillingSpecimenView>
	{
		public BillingSpecimenViewCollection()
		{
		}

		public BillingSpecimenViewCollection(YellowstonePathology.Business.Test.Surgical.SurgicalSpecimenCollection surgicalSpecimenCollection,
			YellowstonePathology.Business.Specimen.Model.SpecimenOrderCollection specimenOrderCollection,
			YellowstonePathology.Business.Test.PanelSetOrderCPTCodeCollection panelSetOrderCPTCodeCollection,
			YellowstonePathology.Business.Billing.ICD9BillingCodeCollection icd9BillingCodeCollection)
		{
			this.Refresh(surgicalSpecimenCollection, specimenOrderCollection, panelSetOrderCPTCodeCollection, icd9BillingCodeCollection);
		}

		public void Refresh(YellowstonePathology.Business.Test.Surgical.SurgicalSpecimenCollection surgicalSpecimenCollection,
			YellowstonePathology.Business.Specimen.Model.SpecimenOrderCollection specimenOrderCollection,
			YellowstonePathology.Business.Test.PanelSetOrderCPTCodeCollection panelSetOrderCPTCodeCollection,
			YellowstonePathology.Business.Billing.ICD9BillingCodeCollection icd9BillingCodeCollection)
		{
			this.Clear();
			foreach (YellowstonePathology.Business.Test.Surgical.SurgicalSpecimen surgicalSpecimen in surgicalSpecimenCollection)
			{
				YellowstonePathology.Business.Specimen.Model.SpecimenOrder specimenOrder = specimenOrderCollection.GetSpecimenOrderById(surgicalSpecimen.SpecimenOrderId);
				YellowstonePathology.Business.Test.PanelSetOrderCPTCodeCollection codeCollection = panelSetOrderCPTCodeCollection.GetSpecimenOrderCollection(specimenOrder.SpecimenOrderId);
				YellowstonePathology.Business.Billing.ICD9BillingCodeCollection icd9Collection = icd9BillingCodeCollection.GetSurgicalSpecimenCollection(surgicalSpecimen.SurgicalSpecimenId);
				BillingSpecimenView billingSpecimenView = new BillingSpecimenView(surgicalSpecimen, specimenOrder, codeCollection, icd9Collection);
				this.Add(billingSpecimenView);
			}
		}
	}
}
