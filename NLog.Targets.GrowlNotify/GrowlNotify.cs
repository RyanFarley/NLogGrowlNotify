#region Licenses
//  GrowlNotify Target for NLog
//	-----------------------------------------------------------------------------------
//  Copyright 2010 Ryan Farley
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License. 
//
//	Growl.NET GNTP Connector Library
//	-----------------------------------------------------------------------------------
//	Copyright (c) 2008 - Growl for Windows
//	All rights reserved
//
//	Redistribution and use in source and binary forms, with or without modification,
//	are permitted provided that the following conditions are met:
//
//	1. Redistributions of source code must retain the above copyright
//	   notice, this list of conditions and the following disclaimer.
//	2. Redistributions in binary form must reproduce the above copyright
//	   notice, this list of conditions and the following disclaimer in the
//	   documentation and/or other materials provided with the distribution.
//
//	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
//	EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES 
//	OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
//	SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
//	INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
//	TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
//	BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
//	CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
//	ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH 
//	DAMAGE.
//
//	NLog - Advanced .NET and Silverlight Logging - http://nlog-project.org/
//	-----------------------------------------------------------------------------------
//	Copyright (c) 2004-2010 Jaroslaw Kowalski <jaak@jkowalski.net>
//
//	All rights reserved.
//
//	Redistribution and use in source and binary forms, with or without
//	modification, are permitted provided that the following conditions
//	are met:
//
//	* Redistributions of source code must retain the above copyright notice,
//	  this list of conditions and the following disclaimer.
//
//	* Redistributions in binary form must reproduce the above copyright notice,
//	  this list of conditions and the following disclaimer in the documentation
//	  and/or other materials provided with the distribution.
//
//	* Neither the name of Jaroslaw Kowalski nor the names of its
//	  contributors may be used to endorse or promote products derived from this
//	  software without specific prior written permission.
//
//	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
//	ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
//	LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
//	CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
//	SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
//	INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
//	CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
//	ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
//	THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Drawing;
using Growl.CoreLibrary;
using Growl.Connector;
	
namespace NLog.Targets
{
	[NLog.Targets.Target("GrowlNotify")]
	public class GrowlNotify : NLog.Targets.Target
	{
		// growl connector
		private GrowlConnector growl;

		// registered growl application
		private Application application;

		// NLog level notifications
		private NotificationType trace;
		private NotificationType debug;
		private NotificationType info;
		private NotificationType warn;
		private NotificationType error;
		private NotificationType fatal;

		public GrowlNotify()
		{
			Port = 23053;
		}

		public string Password { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }

		private void RegisterApplication()
		{
			if (string.IsNullOrEmpty(Host))
				growl = new GrowlConnector(Password);
			else
				growl = new GrowlConnector(Password, Host, Port);

			growl.EncryptionAlgorithm = Cryptography.SymmetricAlgorithmType.PlainText;

			application = new Application("NLog");
			application.Icon = GetIconData(GrowlNotifyResources.NLog);

			trace = new NotificationType("Trace", "NLog Trace", GetIconData(GrowlNotifyResources.Trace), true);
			debug = new NotificationType("Debug", "NLog Debug", GetIconData(GrowlNotifyResources.Debug), true);
			info = new NotificationType("Info", "NLog Info", GetIconData(GrowlNotifyResources.Info), true);
			warn = new NotificationType("Warn", "NLog Warn", GetIconData(GrowlNotifyResources.Warn), true);
			error = new NotificationType("Error", "NLog Error", GetIconData(GrowlNotifyResources.Error), true);
			fatal = new NotificationType("Fatal", "NLog Fatal", GetIconData(GrowlNotifyResources.Fatal), true);

			growl.Register(application, new NotificationType[] { trace, debug, info, warn, error, fatal });
		}

		protected override void Write(LogEventInfo logEvent)
		{
			if (growl == null) RegisterApplication();

			var notification = new Notification(application.Name, logEvent.Level.ToString(), null, string.Concat(logEvent.Level, ":", logEvent.LoggerName), (logEvent.FormattedMessage ?? string.Empty).Replace("\r\n", "\n"));
			growl.Notify(notification);
		}

		private BinaryData GetIconData(Bitmap Icon)
		{
			return new BinaryData((byte[])System.ComponentModel.TypeDescriptor.GetConverter(Icon).ConvertTo(Icon, typeof(byte[])));
		}
	}
}
