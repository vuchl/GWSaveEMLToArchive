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


namespace GWSaveToDB
{
    // ****************************************************************************
    //  This class should be included with every C3PO.
    //  It is used to initalize the C3PO.
    //
    //  The name of this class, which is now "C3POServer", can be any name you
    //  choose.
    //
    //  A good rule of thumb is to:
    //      1) Rename the project to your company's name. (e.g. "Novell", under
    //         Tools | Options | Project | Project Name)
    //      2) Rename the C3POServer class (e.g. "GWMyTestC3PO")
    //
    //  This will allow a unique ProgID to identify the C3PO(s) in the registry
    //  (e.g. "Novell.GWMyTestC3PO")
    // ****************************************************************************
    [Guid(Guids.c3poserverGuid), ProgId("GWSaveToDB.C3POServer")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class C3POServer
    {
        //  C3POServer Class member variables
        private const string m_sDESCRIPTION = "Description for your C3PO";

        private bool m_bCanShutdown;

        // ***********************************************************
        // Name:          Default Constructor
        //
        //    Description:  The default constructor(constructor with no arguments) is
        //                  required so that COM can create an instance of the object.
        //
        //    In:           none
        //
        //    Out:          none
        //
        // Comments:
        // 
        // ************************************************************
        public C3POServer()
        {
        }

        //  Returns the CommandFactory object for the C3PO.
        //  The C3PO server may return NULL.
        // ***********************************************************
        // Name:          Get CommandFactory
        // 
        //    Description:  This property returns the CommandFactory for the C3PO.  The
        //                  C3PO server may return NULL.
        // 
        // 
        //    In:           none
        // 
        //    Out:          CommandFactory object or null in not supported
        // 
        // Comments:
        // 
        // ************************************************************
        public CommandFactory CommandFactory
        {
            get
            {
                return new CommandFactory();
            }
        }

        public string Description
        {
            get
            {
                return m_sDESCRIPTION;
            }
        }

        public EventMonitor EventMonitor
        {
            get
            {
                return new EventMonitor();
            }
        }

        public IconFactory IconFactory
        {
            get
            {
                return new IconFactory();
            }
        }

        public bool SetCanShutdown
        {
            set
            {
                m_bCanShutdown = value;
            }
        }

        public bool CanShutdown()
        {
            return m_bCanShutdown;
        }

        // ***********************************************************
        // Name:            DeInit
        // 
        //    Description:  Terminates the relationship of the C3PO Manager with the C3PO
        //                  server.  Note that this is a separate issue from the shutdown
        //                  sequence (including shutdown events).  For example, a C3PO may
        //                  be unloaded from memory as a runtime optimization.  In that
        //                  scenario, the C3PO server first receives CanShutdown() calls
        //                  followed by DeInit() ? the C3PO is unloaded, but the client
        //                  application has not necessarilly terminated.
        // 
        //                  The C3POManager pointer passed in to C3POServer::Init() is
        //                  still valid during this call.  However, when DeInit() returns,
        //                  the C3POManager pointer is not guaranteed to be valid.  The
        //                  C3POServer must release all holds to the C3POManager during
        //                  the DeInit call.
        // 
        //                  One DeInit call will be issued to the C3POServer for each C3PO
        //                  Client using the C3PO system.  C3POs that wish to be capable of
        //                  loading into multiple Clients (irrespective of process boundaries)
        //                  should be multiple-instance OLE servers.  That is, a new C3POServer
        //                  object should be created for each C3POManager that wished to
        //                  use the services of the C3PO.  By tracking the Manager pointer
        //                  for each C3POServer, the C3PO can sort out which requests are
        //                  being issued from which clients.
        // 
        // 
        //    In:           none
        // 
        //    Out:             none
        // 
        // Comments:
        // 
        // ************************************************************}
        public void DeInit()
        {
        }

        // ***********************************************************
        // Name:          Init
        // 
        //    Description:  This method is the first method invoked in the C3POServer object
        //                  when loading a C3PO server.  If the server fails this call
        //                  (via the HRESULT), the C3PO server is unloaded.
        // 
        //                  One Init call will be issued to the C3POServer for each C3PO
        //                  Client using the C3PO system.  C3POs that wish to be capable of
        //                  loading into multiple Clients (irrespective of process boundaries)
        //                  should be multiple-instance OLE servers.  That is, a new C3POServer
        //                  object should be created for each C3POManager that wished to use
        //                  the services of the C3PO.  By tracking the Manager pointer for
        //                  each C3POServer, the C3PO can sort out which requests are being
        //                  issued from which clients.
        // 
        //                  The Manager object is valid until a future DeInit() call.
        //                  That is, the C3PO does not need to AddRef() this object but can
        //                  simply store it for the life of the C3PO (until DeInit is called).
        // 
        // 
        // 
        //    In:           objGWManager: variant - C3POManager object
        // 
        //    Out:             none
        // 
        // Comments:
        // 
        // ************************************************************
        public void Init(ref object objGWManager)
        {
            //  Set a global C3POManager object for later use
            GWSaveToDB.g_C3POManager = (C3POTypeLibrary.C3POManager)objGWManager;
            //  Set default to CanShutdown
            m_bCanShutdown = true;
        }


        [ComRegisterFunctionAttribute]
        public static void RegC3poServer(Type t)
        {
            GWSaveToDB.RegC3po();
        }

        [ComUnregisterFunctionAttribute]
        public static void UnRegC3poServer(Type t)
        {
            GWSaveToDB.UnRegC3po();
        }


    }
}

