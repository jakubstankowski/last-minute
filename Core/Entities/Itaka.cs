﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Itaka
    {

        public class RetrieveMultipleItakaResponse
        {
            public List<Data> Data { get; set; }
        }

        public class Photos
        {
            public string main { get; set; }
            public string tiny { get; set; }
        }


        public class Data
        {
            public int price { get; set; }

            public string meal { get; set; }
            public string dateFrom { get; set; }
            public string dateTo { get; set; }


            public object canonicalDestinationTitle { get; set; }
            public Photos photos { get; set; }

            public string title { get; set; }

            public string url { get; set; }

        }

    }
}
