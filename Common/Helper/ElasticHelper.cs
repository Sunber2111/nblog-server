using System;
namespace Common.Helper
{
    public static class ElasticHelper
    {
        public static string GetIndexName(this object data)
        {
            return data.GetType().Name.ToString().ToLower();
        }
    }
}

