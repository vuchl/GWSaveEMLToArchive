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
    // ****************************************************************************
    //    Class Name:   GWCommand
    //
    //    Description:   This object defines an instance of a GroupwWise command
    //
    // *END************************************************************************

    [Guid(Guids.gwCommandGuid), ProgId("GWSaveToDB.GWCommand")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    public class GWCommand : IGWCommand
    {
        //  Member variables to hold private data
        private object m_objBaseCmd;

        private string m_sLongPrompt;

        private string m_sToolTip;

        private int m_PersistentID;

        // ***********************************************************
        // Name:        Constructor
        // ***********************************************************
        public GWCommand (int id)
        {
            m_PersistentID = id;
        }

        // ***********************************************************
        // Name:          Get/Set BaseCmd
        //
        //    Description: Returns/Save the Base GWCommand
        //
        //    In:          none/Object Base GWCommand GroupWise Client functionality
        //
        //    Out:         Object - Base GWCommand/none
        //
        // Comments:
        //
        // ************************************************************
        public object BaseCmd
        {
            get
            {
                return m_objBaseCmd;
            }
            set
            {
                m_objBaseCmd = value;
            }
        }

        public string LongPrompt
        {
            get
            {
                return m_sLongPrompt;
            }
            set
            {
                m_sLongPrompt = value;
            }
        }

        public object Parameters
        {
            get
            {
                return null;
            }
        }

        public string PersistentID
        {
            get
            {
                return null;
            }
        }

        public string ToolTip
        {
            get
            {
                return m_sToolTip;
            }
            set
            {
                m_sToolTip = value;
            }
        }

        public void Execute()
        {
            try
            {
                switch (m_PersistentID)
                {
                    case GWSaveToDB.clickGWSaveToDB:
                        MessageBox.Show( "GWSaveToDB Context Menu", "Execute", MessageBoxButtons.OK);
                        //C3PO WIZARD Put execute command code here for GWSaveToDB Context menu.
                        break;

                    default:
                        MessageBox.Show("Unsupported Case", "Error", MessageBoxButtons.OK);
                        break;
                }

                //A way to get the GroupWise client state with newest interface
                //C3POTypeLibrary.IGWClientState6 myCL = (C3POTypeLibrary.IGWClientState6)GWSaveToDB.g_C3POManager.ClientState;

                //uncomment the code below to unblock the base command
                //IGWCommand baseCmd = (IGWCommand)GWSaveToDB.g_C3POManager.CreateGWCommand(m_objBaseCmd);
                //baseCmd.Execute();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Executing GWCommand: " + m_PersistentID.ToString() + " Error: " + e.Message);
           }

           return;
        }

        // ***********************************************************
        // Name:          Help
        //
        //    Description: Reserved for future use.
        //
        //    In:          none
        //
        //    Out:         none
        //
        // Comments:
        //
        // ************************************************************
        public void Help()
        {
        }

        // ***********************************************************
        // Name:          UnDo
        //
        //    Description: Reserved for future use.
        //
        //    In:          none
        //
        //    Out:         none
        //
        // Comments:
        //
        // ************************************************************
        public void Undo()
        {
        }

        // ***********************************************************
        // Name:          Validate
        //
        //    Description:  This interface is called to determine the state of a C3po
        //                  command. Determining the state is termed the validation.
        //                  The command is assumed by default to be in an enabled, unchecked,
        //                  visible state. The C3po provider can then modify that assumption
        //                  by returning flags. The available flags are:
        //
        //                      eGW_CMDVAL_CHECKED - The command has a check mark.
        //                      eGW_CMDVAL_DISABLED - The command is disabled.
        //
        //
        //    In:           none
        //
        //    Out:          Long - Setting command Checked or Disabled
        //
        //    Comments:  Validate applies only to commands put onto the toolbar or menu by the
        //              C3po server. Predifined commands do not cause this method to be involked.
        //
        // ************************************************************
        public int Validate()
        {
            return 0;
        }
    }
}
