// *SOURCE_FILE****************************************************************
//    Copyright (C) 2005 Novell Corp., All Rights Reserved
//
//    The sample code is provided 'as is' without warranty of any kind.
//    Novell, Inc. further disclaims all implied warranties including
//    without limitation any implied warranties of any merchantability
//    or of fitness for a particular purpose.  The entire risk arising out
//    of the use or performance of the software and documentation
//    remains with you.
//
//    To the maximum extent permitted by law, in no event shall Novell,
//    Inc. or its suppliers be liable for any damages whatsoever (including
//    without limitation, damages for loss of business profits, business
//    interruption, loss of business information, or any other pecuniary
//    loss) arising out of the use of or inability to use this Novell, Inc.
//    product, even if Novell, Inc. has been advised of the possibility
//    of such damages.  Because some states/jurisdictions do not
//    allow the exclusion or limitation of liability for consequential or
//    incidental damages, the above limitation may not apply to you.
// *END************************************************************************

using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace GWSaveToDB
{
    class GWSaveToDB
    {
        public const string eGW_CMDID_ACCEPT = "GW#C#ACCEPT";

        public const string eGW_CMDID_ARCHIVE = "GW#C#ARCHIVE";

        public const string eGW_CMDID_COMPLETE = "GW#C#COMPLETE";

        public const string eGW_CMDID_COMPOSE = "GW#C#COMPOSE";

        public const string eGW_CMDID_DECLINE = "GW#C#DECLINE";

        public const string eGW_CMDID_DELEGATE = "GW#C#DELEGATE";

        public const string eGW_CMDID_DELETE = "GW#C#DELETE";

        public const string eGW_CMDID_DOC_CHECKIN = "GW#C#DOC_CHECKIN";

        public const string eGW_CMDID_DOC_CHECKOUT = "GW#C#DOC_CHECKOUT";

        public const string eGW_CMDID_DOC_RESETINUSE = "GW#C#DOC_RESETINUSE";

        public const string eGW_CMDID_FORWARD = "GW#C#FORWARD";

        public const string eGW_CMDID_INFO = "GW#C#INFO";

        public const string eGW_CMDID_OPEN = "GW#C#OPEN";

        public const string eGW_CMDID_OPENFILEATTACH = "GW#C#OPENFILEATTACH";

        public const string eGW_CMDID_PRINT = "GW#C#PRINT";

        public const string eGW_CMDID_PROPERTIES = "GW#C#PROPERTIES";

        public const string eGW_CMDID_REPLY = "GW#C#REPLY";

        public const string eGW_CMDID_RESEND = "GW#C#RESEND";

        public const string eGW_CMDID_SAVE = "GW#C#SAVE";

        public const string eGW_CMDID_SAVEAS = "GW#C#SAVEAS";

        public const string eGW_CMDID_SAVEATTACHAS = "GW#C#SAVEATTACHAS";

        public const string eGW_CMDID_SEND = "GW#C#SEND";

        public const string eGW_CMDID_SETALARMS = "GW#C#SETALARMS";

        public const string eGW_CMDID_UNDELETE = "GW#C#UNDELETE";

        public const string eGW_CMDID_VIEW = "GW#C#VIEW";

        public const string eGW_CMDID_VIEWATTACH = "GW#C#VIEWATTACH";

        public const short eGW_CMDVAL_ALWAYS = 1;

        public const short eGW_CMDVAL_CHECKED = 2;

        public const short eGW_CMDVAL_DISABLED = 4;

        // Constant for Context menu item GWSaveToDB
        public const int clickGWSaveToDB = 0;

        //  Global C3POManager for use in project
        public static C3POTypeLibrary.C3POManager g_C3POManager = null;

        public static void RegC3po()
        {
            RegistryKey rk = Registry.LocalMachine;
            string sServerKey;
            RegistryKey serverKey;

                sServerKey = "SOFTWARE\\Novell\\GroupWise\\5.0\\C3PO\\DataTypes\\GW.CLIENT\\GWSaveToDB.C3POServer";
                serverKey = rk.CreateSubKey(sServerKey);

                if (serverKey != null)
                {
                    using (RegistryKey
                        testObject = serverKey.CreateSubKey("Objects"),
                        testEvent = serverKey.CreateSubKey("Events"))
                    {
                        testObject.SetValue("EventMonitor", "");
                        testEvent.SetValue("OnReady", "");
                    }
                }

                sServerKey = "SOFTWARE\\Novell\\GroupWise\\5.0\\C3PO\\DataTypes\\GW.MESSAGE.MAIL\\GWSaveToDB.C3POServer";
                serverKey = rk.CreateSubKey(sServerKey);

                if (serverKey != null)
                {
                    using (RegistryKey
                        testObject = serverKey.CreateSubKey("Objects"),
                        testEvent = serverKey.CreateSubKey("Events"))
                    {
                        testObject.SetValue("CommandFactory", "");
                    }
                }

        }


        public static void UnRegC3po()
        {
            RegistryKey rk = Registry.LocalMachine;
            string sServerKey;
            RegistryKey serverKey;
            RegistryKey subKey;

                sServerKey = "SOFTWARE\\Novell\\GroupWise\\5.0\\C3PO\\DataTypes\\GW.CLIENT";

                serverKey = rk.OpenSubKey(sServerKey, true);
                if (serverKey != null)
                {
                    subKey = serverKey.OpenSubKey("GWSaveToDB.C3POServer");
                    if (subKey != null)
                        serverKey.DeleteSubKeyTree("GWSaveToDB.C3POServer");
                    serverKey.Close();
                }

                sServerKey = "SOFTWARE\\Novell\\GroupWise\\5.0\\C3PO\\DataTypes\\GW.MESSAGE.MAIL";

                serverKey = rk.OpenSubKey(sServerKey, true);
                if (serverKey != null)
                {
                    subKey = serverKey.OpenSubKey("GWSaveToDB.C3POServer");
                    if (subKey != null)
                        serverKey.DeleteSubKeyTree("GWSaveToDB.C3POServer");
                    serverKey.Close();
                }

        }
    }
}
