﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Linq;


namespace YellowstonePathology.Business.Test.Model
{
	public class TestOrderCollection : TestOrderCollection_Base
	{
		public const string PREFIXID = "TO";

		public TestOrderCollection()
		{
            
		}

        public TestOrder GetTestOrder(int testId)
        {
            foreach (TestOrder item in this)
            {
                if (item.TestId == testId)
                {
                    return item;
                }
            }
            return null;
        }

        public TestOrder Get(string testOrderId)
        {
            foreach (TestOrder item in this)
            {
                if (item.TestOrderId == testOrderId)
                {
                    return item;
                }
            }
            return null;
        }	                  

        public int GetChargeableIHCTestOrderCount()
        {
            int result = 0;
            YellowstonePathology.Business.Test.Model.TestCollection ihcTestCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetIHCTests();

            foreach (YellowstonePathology.Business.Test.Model.TestOrder testOrder in this)
            {
                if (testOrder.NoCharge == false)
                {
                    if (ihcTestCollection.Exists(testOrder.TestId) == true)
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }

        public int GetOrderedAsDualCount()
        {
            int result = 0;
            YellowstonePathology.Business.Test.Model.TestCollection ihcTestCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetIHCTests();

            foreach (YellowstonePathology.Business.Test.Model.TestOrder testOrder in this)
            {
                if (testOrder.NoCharge == false)
                {
                    if (testOrder.OrderedAsDual == true)
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }

        public int GetBillableDualStainCount(bool includeDualsWithGradedStains)
        {
            int result = 0;
            YellowstonePathology.Business.Test.Model.DualStainCollection dualStainCollection = YellowstonePathology.Business.Test.Model.DualStainCollection.GetCollection(this);
            result = dualStainCollection.StainCount(includeDualsWithGradedStains);
            return result;
        }

        public YellowstonePathology.Business.Test.Model.TestOrderCollection GetBillableGradeStains(bool includeOrderedAsDual)
        {
            YellowstonePathology.Business.Test.Model.TestOrderCollection result = new TestOrderCollection();
            YellowstonePathology.Business.Test.Model.TestCollection gradedTestCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetGradedTests();

            foreach (YellowstonePathology.Business.Test.Model.TestOrder testOrder in this)
            {
                if (gradedTestCollection.Exists(testOrder.TestId) == true && testOrder.OrderedAsDual == includeOrderedAsDual)
                {
                    result.Add(testOrder);
                }
            }

            return result;
        }

        public YellowstonePathology.Business.Test.Model.TestOrderCollection GetBillableCytochemicalStains(bool includeOrderedAsDual)
        {
            YellowstonePathology.Business.Test.Model.TestOrderCollection result = new TestOrderCollection();
            YellowstonePathology.Business.Test.Model.TestCollection resultTestCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetCytochemicalTests();

            foreach (YellowstonePathology.Business.Test.Model.TestOrder testOrder in this)
            {
                if (resultTestCollection.Exists(testOrder.TestId) == true && testOrder.OrderedAsDual == includeOrderedAsDual)
                {
                    result.Add(testOrder);
                }
            }

            return result;
        }

        public YellowstonePathology.Business.Test.Model.TestOrderCollection GetBillableCytochemicalStainsForMicroorganisms(bool includeOrderedAsDual)
        {
            YellowstonePathology.Business.Test.Model.TestOrderCollection result = new TestOrderCollection();
            YellowstonePathology.Business.Test.Model.TestCollection resultTestCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetCytochemicalForMicroorganismsTests();

            foreach (YellowstonePathology.Business.Test.Model.TestOrder testOrder in this)
            {
                if (resultTestCollection.Exists(testOrder.TestId) == true && testOrder.OrderedAsDual == includeOrderedAsDual)
                {
                    result.Add(testOrder);
                }
            }

            return result;
        }  

        public YellowstonePathology.Business.Test.Model.TestOrderCollection GetBillableSinglePlexIHCTestOrders()
        {
            YellowstonePathology.Business.Test.Model.TestOrderCollection result = new TestOrderCollection();
            YellowstonePathology.Business.Test.Model.TestCollection ihcTestCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetIHCTests();

            foreach (YellowstonePathology.Business.Test.Model.TestOrder testOrder in this)
            {                
                if (testOrder.OrderedAsDual == false)
                {
                    if (testOrder.NoCharge == false)
                    {
                        if (ihcTestCollection.Exists(testOrder.TestId) == true)
                        {
                            result.Add(testOrder);                            
                        }
                    }
                }                
            }

            return result;
        }        

		public YellowstonePathology.Business.Test.Model.TestOrder Add(string panelOrderId, string objectId, string aliquotOrderId, YellowstonePathology.Business.Test.Model.Test test, string comment)
        {            
            TestOrder testOrder = this.GetNextItem(panelOrderId, objectId, aliquotOrderId, test, comment);
            this.Add(testOrder);
			return testOrder;
        }

		public YellowstonePathology.Business.Test.Model.TestOrder GetNextItem(string panelOrderId, string objectId, string aliquotOrderId, YellowstonePathology.Business.Test.Model.Test test, string comment)
		{
			string testOrderId = YellowstonePathology.Business.OrderIdParser.GetNextTestOrderId(this, panelOrderId);
			YellowstonePathology.Business.Test.Model.TestOrder testOrder = new TestOrder(testOrderId, objectId, panelOrderId, aliquotOrderId, test, comment);			
			return testOrder;
		}

        public int GetHandECount()
        {
            int result = 0;
            foreach (TestOrder item in this)
            {
                if (item.TestId == 49)
                {
                    result++;
                }
            }
            return result;
        }

        public bool HasTestWithNoResult()
        {
            bool result = false;
            foreach (TestOrder testOrder in this)
            {
                if (string.IsNullOrEmpty(testOrder.Result) == true)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool HasTestRequiringAcknowledgement()
        {
            bool result = false;
            YellowstonePathology.Business.Test.Model.TestCollection testCollection = YellowstonePathology.Business.Test.Model.TestCollection.GetAllTests();
            foreach (TestOrder testOrder in this)
            {
                YellowstonePathology.Business.Test.Model.Test test = testCollection.GetTest(testOrder.TestId);
                if (test.NeedsAcknowledgement == true)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool Exists(TestOrderCollection testOrderCollection)
        {
            bool result = false;
            foreach (TestOrder testOrder in testOrderCollection)
            {
                foreach (TestOrder existingTestOrder in this)
                {
                    if (testOrder.TestOrderId == existingTestOrder.TestOrderId)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public int GetUniqueTestOrderCount()
        {
            int result = 0;

            var query = this.GroupBy(x => x.TestId);
            foreach (var testOrder in query)
            {
                result += 1;
            }

            return result;
        }     
	}
}
