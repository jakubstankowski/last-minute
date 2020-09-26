using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interface;

namespace Infrastructure.Services
{
    public class WebscrapperService : IWebscrapperService
    {
        public int ParsePrice(string price, string stringToReplace)
        {
            string removeWhiteSpaceAndReplace = String.Concat(price.ToString()
                .Where(c => !Char.IsWhiteSpace(c)))
               .Replace(stringToReplace, "");

            return Int32.Parse(removeWhiteSpaceAndReplace);
        }
    }
}
