using System;
namespace Common.Helper
{
    public class FilterBase
    {
        public int Page { get; set; } = 1;

        public int Size { get; set; } = 10;

        public int From => (Page - 1) * Size;

        public int Take => Size;
    }
}

