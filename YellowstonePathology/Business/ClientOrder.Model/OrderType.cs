using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using YellowstonePathology.Business.Persistence;

namespace YellowstonePathology.Business.ClientOrder.Model
{
	[DataContract]
	[PersistentClass("tblOrderType", "YPIDATA")]
	public class OrderType : INotifyPropertyChanged
	{
		protected delegate void PropertyChangedNotificationHandler(String info);
		public event PropertyChangedEventHandler PropertyChanged;

		private string m_ObjectId;
		private string m_OrderTypeId;
		private string m_OrderName;
		private string m_OrderCategoryId;
		private int m_Priority;

		public OrderType()
		{
		}

		public void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
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

		[DataMember]
		[PersistentPrimaryKeyProperty(false, 50)]
		public string OrderTypeId
		{
			get { return this.m_OrderTypeId; }
			set
			{
				if (this.m_OrderTypeId != value)
				{
					this.m_OrderTypeId = value;
					this.NotifyPropertyChanged("OrderTypeId");
				}
			}
		}

		[DataMember]
		[PersistentStringProperty(100)]
		public string OrderName
		{
			get { return this.m_OrderName; }
			set
			{
				if (this.m_OrderName != value)
				{
					this.m_OrderName = value;
					this.NotifyPropertyChanged("OrderName");
				}
			}
		}

		[DataMember]
		[PersistentStringProperty(50)]
		public string OrderCategoryId
		{
			get { return this.m_OrderCategoryId; }
			set
			{
				if (this.m_OrderCategoryId != value)
				{
					this.m_OrderCategoryId = value;
					this.NotifyPropertyChanged("OrderCategoryId");
				}
			}
		}

		[DataMember]
		[PersistentProperty("0")]
		public int Priority
		{
			get { return this.m_Priority; }
			set
			{
				if (this.m_Priority != value)
				{
					this.m_Priority = value;
					this.NotifyPropertyChanged("Priority");
				}
			}
		}
	}
}
