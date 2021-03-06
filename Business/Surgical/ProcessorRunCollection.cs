﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace YellowstonePathology.Business.Surgical
{
    public class ProcessorRunCollection : ObservableCollection<ProcessorRun>
    {
        public ProcessorRunCollection()
        {

        }

        public ProcessorRun Get(YellowstonePathology.Business.User.UserPreference userPreference)
        {            
            YellowstonePathology.Business.Surgical.ProcessorRunCollection processorRunCollection = YellowstonePathology.Business.Surgical.ProcessorRunCollection.GetAll(true);
            YellowstonePathology.Business.Surgical.ProcessorRun result = null;

            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
					result = processorRunCollection.Get(YellowstonePathology.Business.User.UserPreferenceInstance.Instance.UserPreference.WeekdayProcessorRunId);
                    break;
                case DayOfWeek.Friday:
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
					result = processorRunCollection.Get(YellowstonePathology.Business.User.UserPreferenceInstance.Instance.UserPreference.WeekendProcessorRunId);
                    break;
            }
            
            return result;
        }

        public ProcessorRun Get(string processorRunId)
        {
            ProcessorRun result = null;
            foreach (ProcessorRun processorRun in this)
            {
                if (processorRun.ProcessorRunId == processorRunId)
                {
                    result = processorRun;
                    break;
                }
            }
            return result;
        }

        public static ProcessorRunCollection GetAll(bool includeNullProcessorRun)
        {
            ProcessorRunCollection result = new ProcessorRunCollection();

            if (includeNullProcessorRun == true)
            {
                NullProcessor nullProcessor = new NullProcessor();
                foreach (ProcessorRun processorRun in nullProcessor.ProcessorRunCollection)
                {
                    result.Add(processorRun);
                }
            }

            BigBirtha bigBirtha = new BigBirtha();
            foreach (ProcessorRun processorRun in bigBirtha.ProcessorRunCollection)
            {
                result.Add(processorRun);
            }

            DrFez drFez = new DrFez();
            foreach (ProcessorRun processorRun in drFez.ProcessorRunCollection)
            {
                result.Add(processorRun);
            }            

            return result;
        }
    }
}
