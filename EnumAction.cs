using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System;
namespace Akamai
{
    [Serializable]
    public enum Action
    {
        [XmlEnum("Purge")]
        Purge = 1,
        [XmlEnum("Invalidate")]
        Invalidate = 2
    };
}

