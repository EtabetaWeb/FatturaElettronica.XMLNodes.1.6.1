using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Xml.Serialization;
using System.Xml;

[Serializable]
public class FatturaElettronicaXMLNodes
{
    [XmlAttribute("versione")]
    public string versione;
    public FatturaElettronicaHeader FatturaElettronicaHeader;
    public FatturaElettronicaBody FatturaElettronicaBody;
}
