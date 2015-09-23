﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace YellowstonePathology.Business.Surgical
{
    public class KeyWordCollection : ObservableCollection<string>
    {
        public KeyWordCollection()
        {

        }

        public bool WordsExistIn(string text)
        {
            bool result = false;
            foreach (string keyWord in this)
            {
                if (string.IsNullOrEmpty(text) == false)
                {
                    if (text.ToUpper().Contains(keyWord.ToUpper()) == true)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
