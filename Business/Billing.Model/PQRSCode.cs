﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.Business.Billing.Model
{
    public class PQRSCode : CptCode
    {
        protected string m_ReportingDefinition;
		protected string m_Header;

        public PQRSCode()
        {

        }

        public string ReportingDefinition
        {
            get { return this.m_ReportingDefinition; }
        }

		public string Header
		{
			get { return this.m_Header; }
		}

		public string FormattedReportingDefinition
		{
			get
			{
				StringBuilder result = new StringBuilder(this.m_Code);
				if (this.m_Modifier != null) result.Append("-" + this.m_Modifier);
				result.Append(":  ");
				result.Append(this.m_ReportingDefinition);
				return result.ToString();
			}
		}

        public override string GetModifier(BillingComponentEnum billingComponent)
        {
            return this.m_Modifier;
        }
    }
}
