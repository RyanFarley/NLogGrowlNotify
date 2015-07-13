<h1>Growl for Windows Target for NLog</h1>

[![Version](https://img.shields.io/nuget/v/NLog.Growl.svg)](https://www.nuget.org/packages/NLog.Growl)

<b>NLog GrowlNotify</b> is a custom target for <a href="http://nlog-project.org/">NLog</a> version 2.0 allowing you to send logging messages to <a href="http://www.growlforwindows.com/">Growl for Windows</a>.

To use NLog GrowlNotify, you simply wire it up as an extension in the NLog.config file and place the NLog.Targets.GrowlNotify.dll, Growl.CoreLibrary.dll, and Growl.Connector.dll (<a href="http://github.com/downloads/RyanFarley/NLogGrowlNotify/NLog.Targets.GrowlNotify_Binaries.zip">download</a>) in the same location as the NLog.dll & NLog.config files. Then use as you would any NLog target. Below is a sample NLog.config file:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

    <extensions>
        <add assembly="NLog.Targets.GrowlNotify" />
    </extensions>
    
    <targets>
        <target name="growl" type="GrowlNotify" password="" host="" port="" />
    </targets>

    <rules>
        <logger name="*" minLevel="Trace" appendTo="growl"/>
    </rules>

</nlog>
```

NLog GrowlNotify supports sending growl notifications locally as well as across the network. Simply include the "host", "password", and optional "port" parameters to send growl notifications to another computer.

The following are some sample screenshots of NLog GrowlNotify in action:

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/1a42ddb1-86c4-4a83-b91a-6b97d811ec40/GrowlNotify_Registration.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/fdabad11-7630-4af6-bda5-c928a8927d5e/GrowlNotify_Trace.png">  <img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/208edad0-e158-4fde-8c7b-d8cd180ffe3b/GrowlNotify_Debug.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/aad65380-0539-4b39-8982-17e60fb81bfe/GrowlNotify_Info.png">  <img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/2e4fe6a2-2954-4ad0-85c7-19397129f90b/GrowlNotify_Warn.png">  

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/0bc73285-487b-4c98-bad1-c5eeed7e4c04/GrowlNotify_Error.png">  <img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/17187701-1142-452a-a127-30a96ebfd7b9/GrowlNotify_Fatal.png">

See more about NLog at: <a href="http://nlog-project.org/">http://nlog-project.org/</a>
See more about Growl for Windows at: <a href="http://growlforwindows.com/">http://growlforwindows.com/</a>
