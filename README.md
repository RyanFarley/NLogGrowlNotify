<h1>Growl for Windows Target for NLog</h1>

<b>NLog GrowlNotify</b> is a custom target for <a href="http://nlog-project.org/">NLog</a> allowing you to send logging messages to <a href="http://www.growlforwindows.com/">Growl for Windows</a>.

To use NLog GrowlNotify, you simply wire it up as an extension in the NLog.config file and place the NLog.Targets.GrowlNotify.dll, Growl.CoreLibrary.dll, and Growl.Connector.dll (<a href="http://github.com/downloads/RyanFarley/NLogGrowlNotify/NLog.Targets.GrowlNotify_Binaries.zip">download</a>) in the same location as the NLog.dll & NLog.config files. Then use as you would any NLog target. Below is a sample NLog.config file:

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

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/962f51eb-cd31-4709-a65b-1f6022a55d69/GrowlNotify_Registration.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/c8a86dc6-9c34-4e0c-9f0f-b8c14128d59f/GrowlNotify_Trace.png">  <img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/13ee68e1-a0cc-4ccb-9bba-fac7eb70c9df/GrowlNotify_Debug.png">

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/999a3bda-1179-405b-b8bb-20f361f2bc94/GrowlNotify_Info.png">  <img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/ea2ca174-7614-4d36-ad1b-50f2d73d73c6/GrowlNotify_Warn.png">  

<img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/6f76b7b8-2299-49cd-bbe9-07fb9cf17a9d/GrowlNotify_Error.png">  <img src="http://content.screencast.com/users/RyanFarley/folders/Private/media/de35365a-cd2b-4ecd-9635-76e37ebab9ae/GrowlNotify_Fatal.png">

See more about NLog at: <a href="http://nlog-project.org/">http://nlog-project.org/</a>
See more about Growl for Windows at: <a href="http://growlforwindows.com/">http://growlforwindows.com/</a>