using System;
using System.Collections.Generic;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public interface ICshtmlComponentInjectionContentStore
    {
        void AddHeadInjectionContentItem(CshtmlComponentInjectionContentItem postBodyContentItem);
        void AddBodyInjectionContentItem(CshtmlComponentInjectionContentItem postBodyContentItem);

        List<CshtmlComponentInjectionContentItem> HeadInjectionContentItems { get; }
        List<CshtmlComponentInjectionContentItem> BodyInjectionContentItems { get; }
    }

    public class CshtmlComponentInjectionContentStore : ICshtmlComponentInjectionContentStore
    {
        public static int HeadInjectionInitialCapacity { get; set; } = 10;
        public static int BodyInjectionInitialCapacity { get; set; } = 10;

        public List<CshtmlComponentInjectionContentItem> HeadInjectionContentItems { get; } = new List<CshtmlComponentInjectionContentItem>(HeadInjectionInitialCapacity);
        public List<CshtmlComponentInjectionContentItem> BodyInjectionContentItems { get; } = new List<CshtmlComponentInjectionContentItem>(BodyInjectionInitialCapacity);

        public void AddHeadInjectionContentItem(CshtmlComponentInjectionContentItem headInjectionContentItem)
        {
            HeadInjectionContentItems.Add(headInjectionContentItem);
        }
        public void AddBodyInjectionContentItem(CshtmlComponentInjectionContentItem bodyInjectionContentItem)
        {
            BodyInjectionContentItems.Add(bodyInjectionContentItem);
        }
    }
}
