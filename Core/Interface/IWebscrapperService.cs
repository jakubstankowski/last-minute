using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface
{
    public interface IWebscrapperService
    {
        public int ParsePrice(string price, string stringToReplace);
    }
}
