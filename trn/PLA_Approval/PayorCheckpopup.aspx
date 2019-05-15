<%@ Page language="c#" Codebehind="PayorCheckpopup.aspx.cs" AutoEventWireup="false" Inherits="PLA_Approval.PayorCheckpopup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupChecker</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script>
		function IsPopupBlocker() {
			var strNewURL = "Dummy.htm"
			var Strfeature = "" ;
			var WindowOpen = window.open(strNewURL,"MainWindow","directories=no,height=100,width=100,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=0,location=no");
			try{
			var obj = WindowOpen.name;
			WindowOpen.close();	
			window.location.href="PayorPendingApprovals.aspx"	
			} 
			catch(e){ 
			alert('MyEnroll.com has detected your Internet Browser has one or more POPUP BLOCKERS turned on. MyEnroll.com’s programs utilize popup windows to display important information only, and DOES NOT present any advertisements or information not approved by your employer. Therefore, you will need to TURN OFF YOUR POPUP BLOCKERS (Symantec, Yahoo, Google, MSN, etc.) - at least temporarily - to be able to use MyEnroll.com.\n\n '+ 
			'Click the "OK" button below then turn off your POPUP BLOCKER(S) immediately. If you would like to avoid this message in the future while keeping your POPUP Blockers on, then you will need to add our websites (www.BASusa.com, www.MyEnroll.com, and www.COBRAControl.com) to your POPUP Blockers’ "allowed sites list.\n\n'+ 
			'If you need assistance in turning off your POPUP BLOCKER(S), you may reference our Popup Blocker help document at: https://www.myenroll.com/popupblockers. For further assistance, you may contact MyEnroll.com support 8:30 AM - 5:00 PM, ET, Mon-Fri at 1.877.334.2111');
			window.location.href="https://www.myenroll.com/popupblockers.htm";
			}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="IsPopupBlocker()">
		<form id="Form1" method="post" runat="server">
		</form>
	</body>
</HTML>
