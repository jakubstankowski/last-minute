using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Itaka
    {

        public class RetrieveMultipleItakaResponse
        {
            public List<Datum> Data { get; set; }
        }

        public class Photos
        {
            public string main { get; set; }
            public string tiny { get; set; }
        }


        public class Datum
        {
            public int price { get; set; }
            public string currency { get; set; }
            public string dateFrom { get; set; }
            public string dateTo { get; set; }
            public int duration { get; set; }
            public int oldPrice { get; set; }
            public string meal { get; set; }

            public object canonicalDestinationTitle { get; set; }
            public Photos photos { get; set; }

            public string title { get; set; }

            public string url { get; set; }
            public bool totalPrice { get; set; }
        }

    }
}
