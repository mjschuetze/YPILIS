﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace YellowstonePathology.Business.Test
{    
    public class PanelSetOrderCPTCodeCollection : ObservableCollection<PanelSetOrderCPTCode>
    {
        public const string PREFIXID = "CPT";

        public PanelSetOrderCPTCodeCollection()
        {

        }

        public bool HasCodesWithMedicareQuantityLimit()
        {
            bool result = false;
            YellowstonePathology.Business.Billing.Model.CptCodeCollection allCptCodes = YellowstonePathology.Business.Billing.Model.CptCodeCollection.GetAll();
            foreach (YellowstonePathology.Business.Test.PanelSetOrderCPTCode panelSetOrderCPTCode in this)
            {
                YellowstonePathology.Business.Billing.Model.CptCode cptCode = allCptCodes.GetCptCode(panelSetOrderCPTCode.CPTCode);
                if (cptCode.HasMedicareQuantityLimit == true)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public string GetCommaSeparatedList()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Count; i++ )
            {
                result.Append(this[i].CPTCode);
                if (i != this.Count - 1)
                {
                    result.Append(", ");
                }
            }
            return result.ToString();
        }        

        public PanelSetOrderCPTCode GetNextItem(string reportNo)
        {
			string objectId = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            string panelSetOrderCPTCodeId = YellowstonePathology.Business.OrderIdParser.GetNextPanelSetOrderCPTCodeId(this, reportNo);
			PanelSetOrderCPTCode panelSetOrderCPTCode = new PanelSetOrderCPTCode(reportNo, objectId, panelSetOrderCPTCodeId);
            return panelSetOrderCPTCode;
        }

        public bool Exists(string cptCode, int quantity)
        {
            bool result = false;
            foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
            {
                if (panelSetOrderCPTCode.Quantity == quantity && panelSetOrderCPTCode.CPTCode == cptCode)
                {
                    result = true;
                }
            }
            return result;
        }        

		public PanelSetOrderCPTCode GetPanelSetOrderCPTCode(string panelSetOrderCPTCodeId)
		{
			PanelSetOrderCPTCode result = null;
			foreach(PanelSetOrderCPTCode panelSetOrderCPTCode in this)
			{
				if(panelSetOrderCPTCode.PanelSetOrderCPTCodeId == panelSetOrderCPTCodeId)
				{
					result = panelSetOrderCPTCode;
					break;
				}
			}

			return result;
		}

        public PanelSetOrderCPTCode GetPanelSetOrderCPTCodeByCPTCode(string cptCode)
        {
            PanelSetOrderCPTCode result = null;
            foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
            {
                if (panelSetOrderCPTCode.CPTCode == cptCode)
                {
                    result = panelSetOrderCPTCode;
                    break;
                }
            }

            return result;
        }

		public int GetCodeQuantity(string cptCode)
		{
			int result = 0;
			foreach (YellowstonePathology.Business.Test.PanelSetOrderCPTCode panelSetOrderCPTCode in this)
			{
                if (panelSetOrderCPTCode.CPTCode == cptCode)
                {
                    result += panelSetOrderCPTCode.Quantity;
                }
			}
			return result;
		}

		public int GetCodeQuantity(string cptCode, string specimenOrderId)
		{
			int result = 0;
			foreach (YellowstonePathology.Business.Test.PanelSetOrderCPTCode panelSetOrderCPTCode in this)
			{
				if (panelSetOrderCPTCode.SpecimenOrderId == specimenOrderId)
				{
					if (panelSetOrderCPTCode.CPTCode == cptCode) result += panelSetOrderCPTCode.Quantity;
				}
			}
			return result;
		}

        public void Unpost()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                if (this[i].PostDate.HasValue == false || this[i].PostDate == DateTime.Today)
                {
                    this[i].PostDate = null;
                }
            }
        }

        public void Unset()
        {
            for(int i=this.Count-1; i>-1; i--)
            {
                if (this[i].EntryType == YellowstonePathology.Business.Billing.Model.PanelSetOrderCPTCodeEntryType.SystemGenerated)
                {
                    if (this[i].PostDate.HasValue == false || this[i].PostDate == DateTime.Today)
                    {
                        this.Remove(this[i]);
                    }
                }
            }
        }

        public PanelSetOrderCPTCodeCollection GetSummaryCollection()
        {
            PanelSetOrderCPTCodeCollection result = new PanelSetOrderCPTCodeCollection();

            var summary = from i in this
                          let j = new
                          {                       
                              ReportNo = i.ReportNo,
                              CPTCode = i.CPTCode,
                              Modifier = i.Modifier,                              
                              ClientId = i.ClientId,
                              Quantity = i.Quantity                              
                          }
                          group i by j into l
                          select new
                         {
                              ReportNo = l.Key.ReportNo,
                              CPTCode = l.Key.CPTCode,
                              Modifier = l.Key.Modifier,                              
                              Clientid = l.Key.ClientId,
                              Quantity = l.Sum(q => q.Quantity)
                          };

            foreach (var item in summary)
            {
                PanelSetOrderCPTCode panelSetOrderCPTCode = new PanelSetOrderCPTCode();
                panelSetOrderCPTCode.ReportNo = item.ReportNo;
                panelSetOrderCPTCode.CPTCode = item.CPTCode;
                panelSetOrderCPTCode.Modifier = item.Modifier;                
                panelSetOrderCPTCode.ClientId = item.Clientid;
                panelSetOrderCPTCode.Quantity = item.Quantity;
                result.Add(panelSetOrderCPTCode);
            }                

            return result;
        }

        public PanelSetOrderCPTCodeCollection GetManualEntrySummaryCollection()
        {
            PanelSetOrderCPTCodeCollection result = new PanelSetOrderCPTCodeCollection();

            var summary = from i in this where i.EntryType == "Manual Entry"
                          let j = new
                          {
                              ReportNo = i.ReportNo,
                              CPTCode = i.CPTCode,
                              Modifier = i.Modifier,                              
                              ClientId = i.ClientId,
                              Quantity = i.Quantity
                          }
                          group i by j into l
                          select new
                          {
                              ReportNo = l.Key.ReportNo,
                              CPTCode = l.Key.CPTCode,
                              Modifier = l.Key.Modifier,                              
                              ClientId = l.Key.ClientId,
                              Quantity = l.Sum(q => q.Quantity)
                          };

            foreach (var item in summary)
            {
                PanelSetOrderCPTCode panelSetOrderCPTCode = new PanelSetOrderCPTCode();
                panelSetOrderCPTCode.ReportNo = item.ReportNo;
                panelSetOrderCPTCode.CPTCode = item.CPTCode;
                panelSetOrderCPTCode.Modifier = item.Modifier;                
                panelSetOrderCPTCode.ClientId = item.ClientId;
                panelSetOrderCPTCode.Quantity = item.Quantity;
                result.Add(panelSetOrderCPTCode);
            }

            return result;
        }

		public PanelSetOrderCPTCodeCollection GetSpecimenOrderCollection(string specimenOrderId)
		{
			PanelSetOrderCPTCodeCollection result = new PanelSetOrderCPTCodeCollection();
			foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
			{
                if (panelSetOrderCPTCode.SpecimenOrderId == specimenOrderId)
                {
                    result.Add(panelSetOrderCPTCode);
                }
			}
			return result;
		}

		public int GetDualStainCount()
		{
			int result = 0;
			foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
			{
                if (panelSetOrderCPTCode.CodeableType == "IHCDUAL")
                {
                    result += 1;
                }
			}
			result = result / 2;
			return result;
		}

		public int Get88342Count()
		{
			int result = 0;
			foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
			{
                if (panelSetOrderCPTCode.CPTCode == "88342")
                {
                    result += 1;
                }
			}
			return result;
		}

        public List<string> GetUniqueSpecimenOrderIdList()
        {
            List<string> result = new List<string>();
            foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
            {
                if (result.Contains(panelSetOrderCPTCode.SpecimenOrderId) == false)
                {
                    result.Add(panelSetOrderCPTCode.SpecimenOrderId);
                }
            }
            return result;
        }

        public void SetPostDate(Nullable<DateTime> postDate)
        {
            foreach (PanelSetOrderCPTCode item in this)
            {
                if (item.PostDate.HasValue == false)
                {
                    item.PostDate = postDate;
                }
            }
        }

        public bool SystemGeneratedReferenceIdExists(string referenceId)
        {
            bool result = false;
            foreach (PanelSetOrderCPTCode panelSetOrderCPTCode in this)
            {
                if (panelSetOrderCPTCode.ReferenceId == referenceId && panelSetOrderCPTCode.EntryType == "System Generated")
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool DoesCollectionHaveCodes(YellowstonePathology.Business.Billing.Model.CptCodeCollection cptCodeCollection)
        {
            bool result = false;
            foreach (YellowstonePathology.Business.Test.PanelSetOrderCPTCode item in this)
            {
                foreach(YellowstonePathology.Business.Billing.Model.CptCode cptCode in cptCodeCollection)
                {
                    if (item.CPTCode == cptCode.Code)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public void UnSet()
        {

        }
	}
}
