using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSStoUserScript
{
    class Constants {
        // String constants for the head of the userscript
        public static String SCRIPT_HEADING = "// ==UserScript==";
        public static String SCRIPT_NAME = "// @name          ";
        public static String SCRIPT_DESCRIPTION = "// @description	  ";
        public static String SCRIPT_AUTHOR = "// @author        ";
        public static String SCRIPT_HOMEPAGE = "// @homepage      ";
        public static String SCRIPT_INCLUDE = "// @include       ";
        public static String SCRIPT_VERSION = "// @version       ";
        public static String SCRIPT_END_HEADING = "// ==/UserScript==" + Environment.NewLine + "(function() {var css = [";
        public static String SCRIPT_CHECK = Environment.NewLine + "if (typeof GM_addStyle != 'undefined') {\n GM_addStyle(css);\n } else if (typeof PRO_addStyle != 'undefined') {\n PRO_addStyle(css);\n } else if (typeof addStyle != 'undefined') {\n addStyle(css);\n } else {\n var node = document.createElement('style');\n node.type = 'text/css';\n node.appendChild(document.createTextNode(css));\n var heads = document.getElementsByTagName('head');\n if (heads.length > 0) { heads[0].appendChild(node);\n } else {\n // no head yet, stick it whereever\n document.documentElement.appendChild(node);\n }\n}})();";
    }
}
