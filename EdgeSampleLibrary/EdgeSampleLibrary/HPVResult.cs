﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdgeSampleLibrary
{
    public class HPVResult
    {        
        public static string PositiveResult = "Positive";
        public static string NegativeResult = "Negative";        
        
        protected string m_ResultCode;
        protected string m_Result;        

        public HPVResult()
        {

        } 
        
        public string ResultCode
        {
            get { return this.m_ResultCode; }
        }              

        public string Result
        {
            get { return this.m_Result; }
        }
    }
}
