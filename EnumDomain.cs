using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System;
namespace Akamai
{
    [Serializable]
    public enum Domain
    {
        [XmlEnum("Production")]
        Production = 1,
        [XmlEnum("Staging")]
        Staging = 2
    };
}
