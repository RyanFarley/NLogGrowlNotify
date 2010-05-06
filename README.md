<h1>Growl for Windows Target for NLog</h1>

<b>NLog GrowlNotify</b> is a custom target for <a href="http://nlog-project.org/">NLog</a> allowing you to send logging messages to <a href="http://www.growlforwindows.com/">Growl for Windows</a>.

To use NLog GrowlNotify, you simply wire it up as an extension in the NLog.config file and place the NLog.Targets.GrowlNotify.dll, Growl.CoreLibrary.dll, and Growl.Connector.dll in the same location as the NLog.dll & NLog.config files. Then use as you would any NLog target. Below is a sample NLog.config file:

<pre>&lt;?xml version=<span style="color: #008080; ">"1.0"</span> encoding=<span style="color: #008080; ">"utf-8"</span> ?&gt;
&lt;nlog xmlns=<span style="color: #008080; ">"http://www.nlog-project.org/schemas/NLog.xsd"</span>
      xmlns:xsi=<span style="color: #008080; ">"http://www.w3.org/2001/XMLSchema-instance"</span>&gt;

    &lt;extensions&gt;
        &lt;add assembly=<span style="color: #008080; ">"NLog.Targets.GrowlNotify"</span> <span style="color: Navy; ">/</span>&gt;
    &lt;/extensions&gt;
    
    &lt;targets&gt;
        &lt;target name=<span style="color: #008080; ">"growl"</span> type=<span style="color: #008080; ">"GrowlNotify"</span> growlpassword=<span style="color: #008080; ">""</span> <span style="color: Navy; ">/</span>&gt;
    &lt;/targets&gt;

    &lt;rules&gt;
        &lt;logger name=<span style="color: #008080; ">"*"</span> minLevel=<span style="color: #008080; ">"Trace"</span> appendTo=<span style="color: #008080; ">"growl"</span><span style="color: Navy; ">/</span>&gt;
    &lt;/rules&gt;

&lt;/nlog&gt;</pre>

The following are some sample screenshots of NLog GrowlNotify in action:

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/556f5107-a84e-44b7-8614-cdfd02e32e15/GrowlNotify_Registration.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/4a99959d-488d-4107-a07d-40ba7817610d/GrowlNotify_Info.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/27ec4242-01d4-400e-8447-8891491c0e79/GrowlNotify_Warn.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/b9cf3540-2848-40e7-a1a1-295e273ab045/GrowlNotify_Fatal.png">

See more about NLog at: <a href="http://nlog-project.org/">http://nlog-project.org/</a>
See more about Growl for Windows at: <a href="http://growlforwindows.com/">http://growlforwindows.com/</a>