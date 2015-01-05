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
    //    Class:  CommandFactory
    //
    //    Description:  This interface is used to manage commands in GroupWise.
    //                  A command occurs in multiple locations including the Menu and
    //                  Toolbar.
    //
    //    Comments:     Modification of the menus is done according to the following algorithm:
    //                    0 CommandFactory::Init(?) called once, long before any menu modifications actually occur.
    //                    1 Menu Load from disk
    //                    2 Send menu out to C3PO servers (CommandFactory::CustomizeMenu())
    //                    3 At INIT_MENU_POPUP time
    //                       Call CommandFactory::CustomizeMenu(?) for all interested C3PO servers (i.e. those
    //                       that returned TRUE to the initial call to CustomizeMenu() ).
    //                    4 Validate the menu
    //
    // *END************************************************************************
    [Guid(Guids.commandFactoryGuid), ProgId("GWSaveToDB.CommandFactory")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class CommandFactory
    {
        //  Predefined GroupWise Command IDentifier constants
        private const short eGW_CMDINIT_CONTEXT_MENUS = 16;

        private const short eGW_CMDINIT_MENUS = 1;

        private const short eGW_CMDINIT_TOOLBARS = 4;

        private const short eGW_CMDINIT_NO_PREDEFINED = 0;

        // ***********************************************************
        // Name:          BuildCommand
        //
        //    Description:  This method is invoked to create a Command object. The C3po cannot assume
        //                  that WantComand has been called before this method is invoked.
        //
        //    In:           sGWContext: string - This is the context for the command. The context string
        //                                    contains either the class of a GW data object(e.g. GW.MESSAGE.MAIL.X)
        //                                    or the class of the specific user interface(e.g. GW.APPLICATION.BROWSER).
        //                  sGWPersistentID: string - This can be either a "pre-defined" ID or is an ID provided in a previous run of GW.
        //                  objGWBaseCommand: variant - The command object of the command being overridden.
        //                  objGWParameter: variant - The parameter list of the command.
        //
        //    Out:          GWCommand: Object - Command object for persistentID.
        //
        //    Comments:     Each time the BuilCommand is invoked, the C3po should return a new instance of a GWCommand
        //                  object. This is neccessary because BuildCommand can be called recursively.
        //
        // ************************************************************
        public object BuildCommand(string sGWContext, string sGWPersistentID, ref object objGWBaseCommand, ref object objGWParameter)
        {
            GWCommand GWCmd = null;


            return (IGWCommand)GWCmd;
        }

        // ***********************************************************
        // Name:            CustomizeContextMenu
        //
        //    Description:  Method to Customize a Context Menu
        //
        //    In:           sGWContext: string - The context string is the class of the object
        //                                    owning the menu. For example, ObjClass would
        //                                    contain "GW.MESSAGE.MAIL" for the mail messages.
        //
        //                  objGWMenu: variant - The context menu to be modified.
        //
        //
        // Out:             none
        //
        // Comments:        This menuis always volatile.
        //
        // ************************************************************
        public void CustomizeContextMenu(ref string sGWContext, ref object objGWMenu)
        {
            C3POTypeLibrary.GWMenu Menu;
            C3POTypeLibrary.GWMenuItems MenuItems;

            // Check for GW.MESSAGE.MAIL or any sub context
            if (sGWContext.Length > 0 && sGWContext.IndexOf("GW.MESSAGE.MAIL") == 0)
            {
               // Get the menu object for the menu at this context
               Menu = (C3POTypeLibrary.GWMenu)objGWMenu;

               // Build GWCommand object
               GWCommand Cmd00 = new GWCommand(GWSaveToDB.clickGWSaveToDB);
               // Set LongPrompt
               Cmd00.LongPrompt = "GWSaveToDB";

               // add menu item to the end of menu
               MenuItems = (C3POTypeLibrary.GWMenuItems)Menu.MenuItems;
               MenuItems.Add("GWSaveToDB", Cmd00, null);

            }

        }

        // ***********************************************************
        // Name:          CustomizeMenu
        //
        //    Description:  Method to customise the menu.
        //
        //    In:           sGWContext: string - The context string property is the class of the
        //                                    containing window.  For example "GW.APPLICATION.BROWSER"
        //                  objGWMenu: variant - The main menu object being modified.
        //
        //    Out:          ToleBool - The return value indicates whether the modifications to the
        //                  menu were "volatile".  If the return value is TRUE, CustomizeMenu()
        //                  will continue to be called each time the menu may need to be updated
        //                  e.g. at each popup creation).  Otherwise, C3PO servers can safely
        //                  assume that CustomizeMenu is called only once for any single instance
        //                  of a menu.  This simplifies the resulting code because there is
        //                  no need to check for commands that might already be on the menu.
        //                  That is, the C3PO's command are guaranteed to be absent from the
        //                  menu at the time of the first CustomizeMenu call.
        //
        //
        // Comments:
        //
        // ************************************************************
        public bool CustomizeMenu(ref string sGWContext, ref object objGWMenu)
        {
            bool bChanged = false;

            C3POTypeLibrary.GWMenu Menu;
            C3POTypeLibrary.GWMenuItems MenuItems;


            return bChanged;
        }

        // ***********************************************************
        // Name:            CustomizeToolbar
        //
        //    Description:  Method to customize the toolbar. The C3po must assume that its commands are absent from
        //                  the toolbar. For example, when a toolbar has been saved and restored in another session
        //                  of GruopWise, the commands can be put back onto the toolbar w/out any intervening calls to
        //                  CustomizeToolbar. For that reason, the C3po should query, the toolbar first before adding
        //                  anything to the toolbar window.
        //
        //    In:           sGWContext: string - Contains the class of the containing window.
        //                  objGWToolbar: variant - Contains the GWToolbar object to be modified.
        //
        //    Out:          Returning TRUE from this method indicates that the toolbar modifications were
        //                  'volatile'. In that case, each time the toolbar is validated in the UI, the
        //                  CustomizeToolbar method will be called.
        // Comments:
        //
        // ************************************************************
        public bool CustomizeToolbar(ref string sGWContext, ref object objGWToolbar)
        {
            C3POTypeLibrary.GWToolbar Button;
            C3POTypeLibrary.GWToolbarItems ButtonItems;
            C3POTypeLibrary.GWToolbarItem ButtonItem;
            string FilePath;
            bool bChanged = false;


            return bChanged;
        }

        // ***********************************************************
        // Name:          Init
        //
        //    Description:  This method is the first method of CommandFactory called. It is used to tell
        //                  GroupWise what UI items will be modified.
        //
        //    In:           lGWLCID: longint - This is the locale ID of the application driving the C3po.
        //
        //    Out:          The C3po server returns any combination of the following bits:
        //
        //                  eGW_CMDINIT_MENUS  - The C3po intends to modify the menus (CustomizeMenu Interface)
        //                  eGW_CMDINIT_TOOLBARS  - The C3po intends to modify the toolbar (CustomizeMenu Interface)
        //                  eGW_CMDINIT_CONTEXT_MENUS - The C3po intends to modify the context menus (CustomizeMenu Interface)
        //                  eGW_CMDINIT_NO_PREDEFINED - Optimization flag that indicates the C3po will never respond to
        //                                              predefined commands. Returning this flag will supress calls to the
        //                                              WantCommand method for predefined commands.
        //
        //
        // Comments:
        //
        // ************************************************************
        public int Init(ref int lGWLCID)
        {
            return (eGW_CMDINIT_CONTEXT_MENUS);
        }

        // ***********************************************************
        // Name:          WantCommand
        //
        //    Description:  This method is used to query the C3po for it's intention to
        //                  support a predefined command.
        //
        //    In:           sGWContext: string - This is the actual object class
        //                                    associates with the command.
        //                  sGWPersistentID: string - This can be either a "pre-defined"
        //                                         ID or is an ID provided in a previous
        //                                         run of GW.
        //
        //    Out:          TRUE - I do want to support this predefined command
        //                  FALSE - I do not want to support this predefined command
        //
        // Comments:
        //
        // ************************************************************
        public bool WantCommand(string sGWContext, string sGWPersistentID)
        {
            bool bWantCommand = false;


            return bWantCommand;
        }
    }
}

