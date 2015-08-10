﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YellowstonePathology.Business.Persistence;

namespace YellowstonePathology.Business.Test
{
	[PersistentClass("tblFNAAdequacyAssessmentResult", "tblPanelSetOrder", "YPIDATA")]
    public partial class FNAAdequacyAssessmentResult : PanelSetOrder
	{
        private Nullable<DateTime> m_StartDate;
        private Nullable<DateTime> m_EndDate;

        public FNAAdequacyAssessmentResult()
        {

        }

		public FNAAdequacyAssessmentResult(string masterAccessionNo, string reportNo, string objectId,
            YellowstonePathology.Business.PanelSet.Model.PanelSet panelSet,
            YellowstonePathology.Business.Interface.IOrderTarget orderTarget,
			bool distribute,
			YellowstonePathology.Business.User.SystemIdentity systemIdentity)
            : base(masterAccessionNo, reportNo, objectId, panelSet, orderTarget, distribute, systemIdentity)
		{
            this.m_StartDate = DateTime.Now;
            this.m_EndDate = DateTime.Now;
		}        

        [PersistentProperty()]
        public Nullable<DateTime> StartDate
        {
            get { return this.m_StartDate; }
            set 
            {
                if (this.m_StartDate != value)
                {
                    this.m_StartDate = value;
                    this.NotifyPropertyChanged("StartDate");
                }
            }
        }

        [PersistentProperty()]
        public Nullable<DateTime> EndDate
        {
            get { return this.m_EndDate; }
            set 
            {
                if (this.m_EndDate != value)
                {
                    this.m_EndDate = value;
                    this.NotifyPropertyChanged("EndDate");
                }
            }
        }
	}
}
