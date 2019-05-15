////////////////////////////////////////////////////////////
// This software is solely the property of Karamasoft LLC. /
//   Copyright 2007 Karamasoft LLC. All rights reserved.   /
//                  www.karamasoft.com                     /
////////////////////////////////////////////////////////////

 document.write("<SCRIPT LANGUAGE=javascript SRC=\""); document.write(ScriptPath+"UltimatePanelUtility.js"); document.write("\"></SCRIPT>"); document.write("<SCRIPT LANGUAGE=javascript SRC=\""); if (document.all && !(document.getElementById)) { document.write(ScriptPath+"UltimatePanelScriptIE4.js"); } else if (document.all) { document.write(ScriptPath+"UltimatePanelScriptIE5p.js"); } else if (document.getElementById) { document.write(ScriptPath+"UltimatePanelScriptNS6p.js"); } else { document.write(ScriptPath+"UltimatePanelScriptUnknown.js"); } document.write("\"></SCRIPT>"); 