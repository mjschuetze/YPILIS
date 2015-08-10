﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YellowstonePathology.Business.Test.NGCT
{
	public class NGCTCTNegativeResult : NGCTResult
	{
		public NGCTCTNegativeResult()
		{
			this.m_ResultCode = "CTNGTV";
			this.m_Result = "Negative";
		}
	}
}
