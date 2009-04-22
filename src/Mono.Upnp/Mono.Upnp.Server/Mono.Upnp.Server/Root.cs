// 
// Root.cs
//  
// Author:
//       Scott Peterson <lunchtimemama@gmail.com>
// 
// Copyright (c) 2009 Scott Peterson
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using Mono.Upnp.Server.Internal;
using Mono.Upnp.Server.Serialization;

namespace Mono.Upnp.Server
{
    [XmlType ("root", Protocol.DeviceUrn)]
    public class Root : XmlAutomatable
    {
        readonly RootDevice device;
        
        public Root (RootDevice device)
        {
            if (device == null) throw new ArgumentNullException ("device");
            
            this.device = device;
        }
        
        [XmlElement ("specVersion")]
        public virtual SpecVersion SpecVersion {
            get { return SpecVersion.OneOne; }
        }
        
        [XmlElement ("device")]
        public virtual RootDevice Device {
            get { return device; }
        }
        
        protected internal byte[] Serialize (XmlSerializer serializer)
        {
            return serializer.GetBytes (this);
        }
        
        protected override void SerializeSelfAndMembers (XmlSerializationContext context)
        {
            context.AutoSerializeObjectAndMembers (this);
        }
        
        protected override void SerializeMembersOnly (XmlSerializationContext context)
        {
            context.AutoSerializeMembersOnly (this);
        }
    }
}