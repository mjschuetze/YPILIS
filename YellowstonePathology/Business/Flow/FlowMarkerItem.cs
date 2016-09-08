using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using YellowstonePathology.Business.Persistence;

namespace YellowstonePathology.Business.Flow
{
	[PersistentClass("tblFlowMarkers", "YPIDATA")]
	public partial class FlowMarkerItem : INotifyPropertyChanged, YellowstonePathology.Business.Interface.IFlowMarker
    {
		public event PropertyChangedEventHandler PropertyChanged;

		private string m_ObjectId;
		private string m_FlowMarkerId;
		private string m_ReportNo;
		private string m_Name;
		private double m_Percentage;
		private string m_Intensity;
		private bool m_Report;
		private bool m_MarkerUsed;
		private string m_MarkerType;
		private string m_Interpretation;
		private bool m_Predictive;
		private int m_Expresses;
		private int m_OrderFlag;
		private string m_Result;

		public FlowMarkerItem()
        {
        }

		public FlowMarkerItem(string flowMarkerId, string objectId, string reportNo, string name)
		{
			this.m_FlowMarkerId = flowMarkerId;
			this.m_ObjectId = objectId;
			this.m_ReportNo = reportNo;
			this.m_Name = name;
			this.m_MarkerUsed = true;
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
		public string FlowMarkerId
		{
			get { return this.m_FlowMarkerId; }
			set
			{
				if (this.m_FlowMarkerId != value)
				{
					this.m_FlowMarkerId = value;
					this.NotifyPropertyChanged("FlowMarkerId");
				}
			}
		}

		[PersistentStringProperty(20)]
		public string ReportNo
		{
			get { return this.m_ReportNo; }
			set
			{
				if (this.m_ReportNo != value)
				{
					this.m_ReportNo = value;
					this.NotifyPropertyChanged("ReportNo");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string Name
		{
			get { return this.m_Name; }
			set
			{
				if (this.m_Name != value)
				{
					this.m_Name = value;
					this.NotifyPropertyChanged("Name");
				}
			}
		}

		[PersistentProperty("0")]
		public double Percentage
		{
			get { return this.m_Percentage; }
			set
			{
				if (this.m_Percentage != value)
				{
					this.m_Percentage = value;
					this.NotifyPropertyChanged("Percentage");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string Intensity
		{
			get { return this.m_Intensity; }
			set
			{
				if (this.m_Intensity != value)
				{
					this.m_Intensity = value;
					this.NotifyPropertyChanged("Intensity");
				}
			}
		}

		[PersistentProperty("0")]
		public bool Report
		{
			get { return this.m_Report; }
			set
			{
				if (this.m_Report != value)
				{
					this.m_Report = value;
					this.NotifyPropertyChanged("Report");
				}
			}
		}

		[PersistentProperty("0")]
		public bool MarkerUsed
		{
			get { return this.m_MarkerUsed; }
			set
			{
				if (this.m_MarkerUsed != value)
				{
					this.m_MarkerUsed = value;
					this.NotifyPropertyChanged("MarkerUsed");
				}
			}
		}

		[PersistentStringProperty(20)]
		public string MarkerType
		{
			get { return this.m_MarkerType; }
			set
			{
				if (this.m_MarkerType != value)
				{
					this.m_MarkerType = value;
					this.NotifyPropertyChanged("MarkerType");
				}
			}
		}

		[PersistentStringProperty(50)]
		public string Interpretation
		{
			get { return this.m_Interpretation; }
			set
			{
				if (this.m_Interpretation != value)
				{
					this.m_Interpretation = value;
					this.NotifyPropertyChanged("Interpretation");
				}
			}
		}

		[PersistentProperty("0")]
		public bool Predictive
		{
			get { return this.m_Predictive; }
			set
			{
				if (this.m_Predictive != value)
				{
					this.m_Predictive = value;
					this.NotifyPropertyChanged("Predictive");
				}
			}
		}

		[PersistentProperty("0")]
		public int Expresses
		{
			get { return this.m_Expresses; }
			set
			{
				if (this.m_Expresses != value)
				{
					this.m_Expresses = value;
					this.NotifyPropertyChanged("Expresses");
				}
			}
		}

		[PersistentProperty("0")]
		public int OrderFlag
		{
			get { return this.m_OrderFlag; }
			set
			{
				if (this.m_OrderFlag != value)
				{
					this.m_OrderFlag = value;
					this.NotifyPropertyChanged("OrderFlag");
				}
			}
		}

		[PersistentStringProperty(50)]
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

		public string InterpretationProxy
        {
            get { return this.Interpretation; }
            set
            {
                if (value != this.Interpretation)
                {
                    this.Interpretation = value;
                    this.NotifyPropertyChanged("InterpretationProxy");
                    switch (value)
                    {
                        case "Negative":
                        case "Equivocal":
                            this.Intensity = string.Empty;
                            break;
                    }
                }
            }
        }

		public void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

		public bool HasQuestionMarks()
		{
			bool result = false;
			if (string.IsNullOrEmpty(this.Intensity) == false && this.Intensity.Contains("???") == true)
			{
				result = true;
			}

			if (string.IsNullOrEmpty(this.Interpretation) == false && this.Interpretation.Contains("???") == true)
			{
				result = true;
			}

			return result;
		}
	}
}
