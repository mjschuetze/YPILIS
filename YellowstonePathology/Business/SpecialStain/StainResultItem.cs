using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using YellowstonePathology.Business.Persistence;

namespace YellowstonePathology.Business.SpecialStain
{
	[PersistentClass("tblStainResult", true, "YPIDATA")]
	public class StainResultItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string m_ObjectId;
		private string m_StainResultId;
		private string m_SurgicalSpecimenId;
		private bool m_Billable;
		private bool m_Reportable;
		private string m_TestOrderId;
		private string m_Result;
		private string m_ProcedureName;
		private string m_ProcedureComment;
		private string m_ReportComment;
		private string m_ControlComment;
		private string m_CptCode;
		private int m_CptCodeQuantity;
		private string m_ImmunoComment;
		private int m_ImmunoCommentRptSeq;
		private string m_StainType;
		private bool m_NoCharge;
		private bool m_OrderedAsDual;
		private bool m_IsGraded;
        private bool m_ClientAccessioned;

		private StainResultOptionList m_ResultList;		

		public StainResultItem()
        {            
			this.m_ResultList = new StainResultOptionList();			
		}

		public StainResultItem(string objectId, string stainResultId, string surgicalSpecimenId)
		{
			this.m_ObjectId = objectId;
			this.m_StainResultId = stainResultId;
			this.m_SurgicalSpecimenId = surgicalSpecimenId;
			this.m_ResultList = new StainResultOptionList();
		}

		[PersistentDocumentIdProperty(50)]
		public string ObjectId
		{
			get { return this.m_ObjectId; }
			set
			{
				if (this.m_ObjectId != value)
				{
					this.m_ObjectId = value;
					this.NotifyPropertyChanged("ObjectId");
				}
			}
		}

		[PersistentPrimaryKeyProperty(false, 50)]
		public string StainResultId
		{
			get { return this.m_StainResultId; }
			set
			{
				if (this.m_StainResultId != value)
				{
					this.m_StainResultId = value;
					this.NotifyPropertyChanged("StainResultId");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string SurgicalSpecimenId
		{
			get { return this.m_SurgicalSpecimenId; }
			set
			{
				if (this.m_SurgicalSpecimenId != value)
				{
					this.m_SurgicalSpecimenId = value;
					this.NotifyPropertyChanged("SurgicalSpecimenId");
				}
			}
		}

		[PersistentProperty("1")]
		public bool Billable
		{
			get { return this.m_Billable; }
			set
			{
				if (this.m_Billable != value)
				{
					this.m_Billable = value;
					this.NotifyPropertyChanged("Billable");
				}
			}
		}

		[PersistentProperty("1")]
		public bool Reportable
		{
			get { return this.m_Reportable; }
			set
			{
				if (this.m_Reportable != value)
				{
					this.m_Reportable = value;
					this.NotifyPropertyChanged("Reportable");
				}
			}
		}

		[PersistentStringProperty(100)]
		public string TestOrderId
		{
			get { return this.m_TestOrderId; }
			set
			{
				if (this.m_TestOrderId != value)
				{
					this.m_TestOrderId = value;
					this.NotifyPropertyChanged("TestOrderId");
				}
			}
		}

		[PersistentStringProperty(1000)]
		public string Result
		{
			get { return this.m_Result; }
			set
			{
				if (this.m_Result != value)
				{
					this.m_Result = value;
					this.NotifyPropertyChanged("Result");
				}
			}
		}

		[PersistentStringProperty(200)]
		public string ProcedureName
		{
			get { return this.m_ProcedureName; }
			set
			{
				if (this.m_ProcedureName != value)
				{
					this.m_ProcedureName = value;
					this.NotifyPropertyChanged("ProcedureName");
				}
			}
		}

		[PersistentStringProperty(500)]
		public string ProcedureComment
		{
			get { return this.m_ProcedureComment; }
			set
			{
				if (this.m_ProcedureComment != value)
				{
					this.m_ProcedureComment = value;
					this.NotifyPropertyChanged("ProcedureComment");
				}
			}
		}

		[PersistentStringProperty(5000)]
		public string ReportComment
		{
			get { return this.m_ReportComment; }
			set
			{
				if (this.m_ReportComment != value)
				{
					this.m_ReportComment = value;
					this.NotifyPropertyChanged("ReportComment");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string ControlComment
		{
			get { return this.m_ControlComment; }
			set
			{
				if (this.m_ControlComment != value)
				{
					this.m_ControlComment = value;
					this.NotifyPropertyChanged("ControlComment");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string CptCode
		{
			get { return this.m_CptCode; }
			set
			{
				if (this.m_CptCode != value)
				{
					this.m_CptCode = value;
					this.NotifyPropertyChanged("CptCode");
				}
			}
		}

		[PersistentProperty("0")]
		public int CptCodeQuantity
		{
			get { return this.m_CptCodeQuantity; }
			set
			{
				if (this.m_CptCodeQuantity != value)
				{
					this.m_CptCodeQuantity = value;
					this.NotifyPropertyChanged("CptCodeQuantity");
				}
			}
		}

		[PersistentStringProperty(1000)]
		public string ImmunoComment
		{
			get { return this.m_ImmunoComment; }
			set
			{
				if (this.m_ImmunoComment != value)
				{
					this.m_ImmunoComment = value;
					this.NotifyPropertyChanged("ImmunoComment");
				}
			}
		}

		[PersistentProperty("0")]
		public int ImmunoCommentRptSeq
		{
			get { return this.m_ImmunoCommentRptSeq; }
			set
			{
				if (this.m_ImmunoCommentRptSeq != value)
				{
					this.m_ImmunoCommentRptSeq = value;
					this.NotifyPropertyChanged("ImmunoCommentRptSeq");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string StainType
		{
			get { return this.m_StainType; }
			set
			{
				if (this.m_StainType != value)
				{
					this.m_StainType = value;
					this.NotifyPropertyChanged("StainType");
				}
			}
		}

		[PersistentProperty("0")]
		public bool NoCharge
		{
			get { return this.m_NoCharge; }
			set
			{
				if (this.m_NoCharge != value)
				{
					this.m_NoCharge = value;
					this.NotifyPropertyChanged("NoCharge");
				}
			}
		}

		[PersistentProperty("0")]
		public bool OrderedAsDual
		{
			get { return this.m_OrderedAsDual; }
			set
			{
				if (this.m_OrderedAsDual != value)
				{
					this.m_OrderedAsDual = value;
					this.NotifyPropertyChanged("OrderedAsDual");
				}
			}
		}

		[PersistentProperty("0")]
		public bool IsGraded
		{
			get { return this.m_IsGraded; }
			set
			{
				if (this.m_IsGraded != value)
				{
					this.m_IsGraded = value;
					this.NotifyPropertyChanged("IsGraded");
				}
			}
		}

        [PersistentProperty("0")]
        public bool ClientAccessioned
        {
            get { return this.m_ClientAccessioned; }
            set
            {
                if (this.m_ClientAccessioned != value)
                {
                    this.m_ClientAccessioned = value;
                    this.NotifyPropertyChanged("ClientAccessioned");
                }
            }
        }

		public StainResultOptionList ResultList
        {
			get
			{
				this.m_ResultList = YellowstonePathology.Business.Gateway.AccessionOrderGateway.GetStainResultOptionListByStainResultId(this.m_StainResultId);
				return this.m_ResultList;
			}
        }

        public bool IsResultPositive()
        {
            bool result = false;
            if (string.IsNullOrEmpty(this.m_Result) == false)
            {
                if (this.m_Result.ToUpper().Contains("POSITIVE") == true)
                {
                    result = true;
                }
            }
            return result;
        }

		public bool ReportCommentContainsNumber()
		{
			bool result = false;

            if (string.IsNullOrEmpty(this.m_ReportComment) == false)
            {
                foreach (Char c in this.m_ReportComment)
                {
                    if (Char.IsDigit(c) == true)
                    {
                        result = true;
                        break;
                    }
                }
            }
			return result;
		}

        public virtual void PullOver(YellowstonePathology.Business.Visitor.AccessionTreeVisitor accessionTreeVisitor)
        {
            accessionTreeVisitor.Visit(this);
        }

		public void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
	}
}
