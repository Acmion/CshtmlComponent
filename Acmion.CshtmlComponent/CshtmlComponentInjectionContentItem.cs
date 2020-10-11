using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public class CshtmlComponentInjectionContentItem : IComparable<CshtmlComponentInjectionContentItem>
    {
        public int ContentOrder { get; set; }
        public string PostContent { get; set; }

        public CshtmlComponentInjectionContentItem(int contentOrder, string postContent) 
        {
            ContentOrder = contentOrder;
            PostContent = postContent;
        }

        public int CompareTo(CshtmlComponentInjectionContentItem other)
        {
            return ContentOrder.CompareTo(other.ContentOrder);
        }
    }
}
