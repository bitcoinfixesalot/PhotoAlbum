using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace DataTablesParser
{
    public class TestHelper
    {
        public static Dictionary<string, StringValues> Params = new Dictionary<string, StringValues>();

        static TestHelper()
        {
            Params.Add(Constants.DRAW, "1");
            Params.Add(Constants.DISPLAY_START, "0");
            Params.Add(Constants.DISPLAY_LENGTH, "10");
            Params.Add(Constants.GetKey(Constants.DATA_PROPERTY_FORMAT, "0"), "PhotoTitle");
            Params.Add(Constants.GetKey(Constants.SEARCHABLE_PROPERTY_FORMAT, "0"), "true");
            Params.Add(Constants.GetKey(Constants.SEARCH_VALUE_PROPERTY_FORMAT, "0"), "");
            Params.Add(Constants.GetKey(Constants.SEARCH_REGEX_PROPERTY_FORMAT, "0"), "false");

            Params.Add(Constants.GetKey(Constants.DATA_PROPERTY_FORMAT, "1"), "AlbumTitle");
            Params.Add(Constants.GetKey(Constants.SEARCHABLE_PROPERTY_FORMAT, "1"), "true");
            Params.Add(Constants.GetKey(Constants.SEARCH_VALUE_PROPERTY_FORMAT, "1"), "");
            Params.Add(Constants.GetKey(Constants.SEARCH_REGEX_PROPERTY_FORMAT, "1"), "false");

            Params.Add(Constants.GetKey(Constants.DATA_PROPERTY_FORMAT, "2"), "ThumbnailUrl");
            Params.Add(Constants.GetKey(Constants.SEARCHABLE_PROPERTY_FORMAT, "2"), "true");
            Params.Add(Constants.GetKey(Constants.SEARCH_VALUE_PROPERTY_FORMAT, "2"), "");
            Params.Add(Constants.GetKey(Constants.SEARCH_REGEX_PROPERTY_FORMAT, "2"), "false");

          

            Params.Add(Constants.SEARCH_KEY, "");
            Params.Add(Constants.SEARCH_REGEX_KEY, "false");

            Params.Add(Constants.GetKey(Constants.ORDER_COLUMN_FORMAT, "0"), "0");
            Params.Add(Constants.GetKey(Constants.ORDER_DIRECTION_FORMAT, "0"), "0");

        }


    }
}
