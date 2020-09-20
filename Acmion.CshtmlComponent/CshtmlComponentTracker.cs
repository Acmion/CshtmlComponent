using System;
using System.Collections.Generic;
using System.Text;

namespace Acmion.CshtmlComponent
{
    public interface ICshtmlComponentTracker
    {
        void AddInstantiatedComponentType(Type type);
        bool HasComponentTypeBeenInstantiated(Type type);
    }

    public class CshtmlComponentTracker : ICshtmlComponentTracker
    {
        public HashSet<Type> InstantiatedComponentTypeSet { get; set; } = new HashSet<Type>();

        public CshtmlComponentTracker() 
        {

        }

        public void AddInstantiatedComponentType(Type type) 
        {
            InstantiatedComponentTypeSet.Add(type);
        }

        public bool HasComponentTypeBeenInstantiated(Type type) 
        {
            return !InstantiatedComponentTypeSet.Contains(type);
        }

    }
}
