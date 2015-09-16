﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.OptimusPrime
{
    public class HPVPositiveResult : HPVResult
    {
        public HPVPositiveResult()
        {
            this.m_ResultCode = "HPVTWPSTV";
            this.m_Result = HPVResult.PositiveResult;
        }
    }
}
