/*
Copyright 2015 Upper Setting Corporation

This file is part of DotNetOpenServer SDK.

DotNetOpenServer SDK is free software: you can redistribute it and/or modify it
under the terms of the GNU General Public License as published by the Free
Software Foundation, either version 3 of the License, or (at your option) any
later version.

DotNetOpenServer SDK is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
details.

You should have received a copy of the GNU General Public License along with
DotNetOpenServer SDK. If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Xml;

namespace US.OpenServer.Protocols
{
    /// <summary>
    /// Class that reads the 'protocols' XML section node within the app.config file.
    /// </summary>
    public class ProtocolConfigurationSectionHandler : IConfigurationSectionHandler
    {
        /// <summary>
        /// Creates a <see cref="ProtocolConfigurationEx"/> object.
        /// </summary>
        /// <remarks>
        /// To configure the framework to extend a protocol configuration add
        /// 'configSectionAssemply' and 'configSectionClassPath' to the app.config's
        /// 'protocols/item' section. Use the XML interior to configure your own
        /// configuration properties.
        /// </remarks>
        /// <param name="parent">The parent object. This parameter is not used.</param>
        /// <param name="configContext">The Configuration context object. This parameter
        /// is not used.</param>
        /// <param name="section">The XML section node.</param>
        /// <returns>A ProtocolConfigurationEx that contains the properties necessary
        /// for Reflection to load the protocol implementation and, if extended,
        /// properties read by the parent class.</returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            Dictionary<ushort, ProtocolConfiguration> retVal = new Dictionary<ushort, ProtocolConfiguration>();
            foreach (XmlNode node in section.ChildNodes)
            {
                ushort id = ushort.Parse(node.Attributes["id"].Value);
                string asm = node.Attributes["assembly"].Value;
                string classPath = node.Attributes["classPath"].Value;
                XmlNode csaNode = node.Attributes["configSectionAssembly"];
                XmlNode cscpNode = node.Attributes["configSectionClassPath"];

                ProtocolConfigurationEx plc;
                if (csaNode != null && cscpNode != null)
                {
                    Assembly assembly = Assembly.LoadFrom(csaNode.Value);
                    plc = (ProtocolConfigurationEx)assembly.CreateInstance(cscpNode.Value);
                    plc.Initialize(id, asm, classPath, node);
                }
                else
                {
                    plc = new ProtocolConfigurationEx(id, asm, classPath);
                }
                
                retVal.Add(plc.Id, plc);
            }
            return retVal;
        }
    }
}
