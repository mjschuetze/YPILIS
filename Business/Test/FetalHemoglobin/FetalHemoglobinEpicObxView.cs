﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace YellowstonePathology.Business.Test.FetalHemoglobin
{
	public class FetalHemoglobinEpicObxView : YellowstonePathology.Business.HL7View.EPIC.EpicObxView
	{
		public FetalHemoglobinEpicObxView(YellowstonePathology.Business.Test.AccessionOrder accessionOrder, string reportNo, int obxCount)
			: base(accessionOrder, reportNo, obxCount)
		{

		}

		public override void ToXml(XElement document)
		{
			throw new Exception("Not Implemented.");
		}
	}
}
