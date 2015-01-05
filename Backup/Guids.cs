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

namespace GWSaveToDB
{
    /// <summary>
    /// Group all identyfying Guids for the typelibarary
    /// Instantiate the read-only GUID's in the (static) contructor
    /// </summary>
    class Guids
    {
        /* Guids as string
         * As Guid const cannot be initiated */
        public const string c3poserverGuid = "BF426ABF-3140-42A8-85D3-8F02BC1FC797";
        public const string iconFactoryGuid = "24CB0008-278D-4F2A-9976-8D59A4B1763F";
        public const string gwCommandGuid = "7FBC627B-38D0-472D-833D-176E10818351";
        public const string commandFactoryGuid = "90BF3E08-A057-4629-A51D-8136203780DA";
        public const string eventMonitorGuid = "EC347C47-3200-4794-8057-CB961F3A2771";
        
        /* Atribute values need a Guid*/
        public static readonly System.Guid idC3poServer;
        public static readonly System.Guid idIconFactor;
        public static readonly System.Guid idGWCommand;
        public static readonly System.Guid idCommandFactory;
        public static readonly System.Guid idEventMonitor;
        
        /* Static constructor to init static Guids */
        static Guids()
        {
            idC3poServer = new System.Guid(c3poserverGuid);
            idIconFactor = new System.Guid(iconFactoryGuid);
            idGWCommand = new System.Guid(gwCommandGuid);
            idCommandFactory = new System.Guid(commandFactoryGuid);
            idEventMonitor = new System.Guid(eventMonitorGuid);
        }
    }
}

