﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace YellowstonePathology.Business.Test.Surgical
{
	public class IntraoperativeConsultationResultCollection : ObservableCollection<IntraoperativeConsultationResult>
	{
		public const string PREFIXID = "IC";

		public IntraoperativeConsultationResultCollection()
        {

        }

		public IntraoperativeConsultationResult GetNextItem(string surgicalSpecimenId)
		{
			string intraoperativeConsultationResultId = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
			IntraoperativeConsultationResult intraoperativeConsultationResult = new IntraoperativeConsultationResult(intraoperativeConsultationResultId, intraoperativeConsultationResultId, surgicalSpecimenId);

			return intraoperativeConsultationResult;
		}

		public IntraoperativeConsultationResult GetCurrent()
		{
			return this.Count > 0 ? this[0] : null;
		}

		public IntraoperativeConsultationResult GetCurrent(string intraoperativeConsultationResultId)
		{
			foreach (IntraoperativeConsultationResult item in this)
			{
				if (item.IntraoperativeConsultationResultId == intraoperativeConsultationResultId)
				{
					return item;
				}
			}
			return null;
		}		

        public bool Exists(string testOrderId)
        {
            bool result = false;
            foreach (IntraoperativeConsultationResult icr in this)
            {
                if (icr.TestOrderId == testOrderId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public IntraoperativeConsultationResult GetIntraoperativeConsultationResult(string testOrderId)
        {
            IntraoperativeConsultationResult result = null;
            foreach (IntraoperativeConsultationResult icr in this)
            {
                if (icr.TestOrderId == testOrderId)
                {
                    result = icr;
                    break;
                }
            }
            return result;
        }

        public virtual void PullOver(YellowstonePathology.Business.Visitor.AccessionTreeVisitor accessionTreeVisitor)
        {
            accessionTreeVisitor.Visit(this);
        }
	}
}
