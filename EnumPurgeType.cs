using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System;
namespace Akamai
{
    [Serializable]
    public enum PurgeType
    {
        [XmlEnum("CPCode")]
        CPCode = 1,
        [XmlEnum("ARL")]
        ARL = 2
    };
}

