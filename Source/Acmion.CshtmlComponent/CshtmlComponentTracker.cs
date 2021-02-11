using System;
using System.Collections.Generic;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public interface ICshtmlComponentTracker
    {
        IDictionary<string, int> InjectedInitialComponentCounter { get; }
        IDictionary<string, int> InjectedHeadComponentCounter { get; }
        IDictionary<string, int> InjectedBodyComponentCounter { get; }

        bool HasComponentTypeInjectedHeadContent(string cshtmlComponentTrackerKey);
        bool HasComponentTypeInjectedBodyContent(string cshtmlComponentTrackerKey);
        bool HasComponentTypeInjectedInitialContent(string cshtmlComponentTrackerKey);

        void AddInjectedHeadContentComponentType(string cshtmlComponentTrackerKey);
        void AddInjectedBodyContentComponentType(string cshtmlComponentTrackerKey);
        void AddInjectedInitialContentComponentType(string cshtmlComponentTrackerKey);
    }

    public class CshtmlComponentTracker : ICshtmlComponentTracker
    {
        public IDictionary<string, int> InjectedHeadComponentCounter { get; } = new Dictionary<string, int>();
        public IDictionary<string, int> InjectedBodyComponentCounter { get; } = new Dictionary<string, int>();
        public IDictionary<string, int> InjectedInitialComponentCounter { get; } = new Dictionary<string, int>();

        public void AddInjectedHeadContentComponentType(string cshtmlComponentTrackerKey)
        {
            if (!InjectedHeadComponentCounter.ContainsKey(cshtmlComponentTrackerKey))
            {
                InjectedHeadComponentCounter[cshtmlComponentTrackerKey] = 0;
            }

            InjectedHeadComponentCounter[cshtmlComponentTrackerKey]++;
        }
        public void AddInjectedBodyContentComponentType(string cshtmlComponentTrackerKey)
        {
            if (!InjectedBodyComponentCounter.ContainsKey(cshtmlComponentTrackerKey))
            {
                InjectedBodyComponentCounter[cshtmlComponentTrackerKey] = 0;
            }

            InjectedBodyComponentCounter[cshtmlComponentTrackerKey]++;
        }
        public void AddInjectedInitialContentComponentType(string cshtmlComponentTrackerKey)
        {
            if (!InjectedInitialComponentCounter.ContainsKey(cshtmlComponentTrackerKey))
            {
                InjectedInitialComponentCounter[cshtmlComponentTrackerKey] = 0;
            }

            InjectedInitialComponentCounter[cshtmlComponentTrackerKey]++;
        }

        public bool HasComponentTypeInjectedHeadContent(string cshtmlComponentTrackerKey)
        {
            return InjectedHeadComponentCounter.ContainsKey(cshtmlComponentTrackerKey);
        }
        public bool HasComponentTypeInjectedBodyContent(string cshtmlComponentTrackerKey)
        {
            return InjectedBodyComponentCounter.ContainsKey(cshtmlComponentTrackerKey);
        }
        public bool HasComponentTypeInjectedInitialContent(string cshtmlComponentTrackerKey)
        {
            return InjectedInitialComponentCounter.ContainsKey(cshtmlComponentTrackerKey);
        }

    }
}
