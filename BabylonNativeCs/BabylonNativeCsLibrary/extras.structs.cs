using System;
using Web;

namespace BABYLON
{
    public struct MinMax
    {
        public Vector3 minimum
        {
            get;
            set;
        }

        public Vector3 maximum
        {
            get;
            set;
        }
    }

    public struct EventDts
    {
        public string name
        {
            get;
            set;
        }
        public EventListener handler
        {
            get;
            set;
        }
    }

    public struct Cache
    {
        public object parent
        {
            get;
            set;
        }
    }
}
