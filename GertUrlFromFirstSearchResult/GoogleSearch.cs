using System;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace GertUrlFromFirstSearchResult
{
    public class GoogleSearch
    {
        //API Key
        private static string API_KEY = "";

        //The custom search engine identifier
        private static string cx = "";

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
            {
                ApiKey = API_KEY,
            });

        public static IList<Result> Search(string query)
        {
            CseResource.ListRequest listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;

            Search search = listRequest.Execute();
            return search.Items;
        }
    }
}
