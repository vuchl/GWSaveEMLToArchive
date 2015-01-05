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
using System.Windows.Forms;
using C3POTypeLibrary;



namespace GWSaveToDB
{
    // ***********************************************************
    //    Object Name:  EventMonitor
    //
    //    Description:  This interface is passed to monitor "low level" actions
    //                  that occur in GroupWise.
    //
    // *END************************************************************************
    [Guid(Guids.eventMonitorGuid), ProgId("GWSaveToDB.EventMonitor")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class EventMonitor
    {
        //  Predefined GroupWise Event IDentifier constants
        private const string eGW_CMDEVTID_READY = "GW#E#0";

        private const string eGW_CMDEVTID_DELIVERY = "GW#E#1";

        private const string eGW_CMDEVTID_SHUTDOWN = "GW#E#2";

        private const string eGW_CMDEVTID_OVERFLOW = "GW#E#3";

        public void Notify(ref string sGWContext, ref object objGWEvent)
        {
            IGWEvent gwEvent = (IGWEvent)objGWEvent;
            switch (gwEvent.PersistentID)
            {
                //Check for Ready Event
                case eGW_CMDEVTID_READY:
                    //C3PO WIZARD This is were you put your Ready code.
                    MessageBox.Show(gwEvent.PersistentID, sGWContext, MessageBoxButtons.OK);
                    break;

                default:
                    MessageBox.Show("Unsupported Case", "Error", MessageBoxButtons.OK);
                    break;
            }
        }
    }
}
