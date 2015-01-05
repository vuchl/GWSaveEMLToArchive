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
    // ***********************************************************
    //    Class Name:  IconFactory
    // 
    //    Description:  This interface is used to retrieve icons that represent the
    //                  state of C3PO record types.
    // 
    // *END************************************************************************
    [Guid(Guids.iconFactoryGuid), ProgId("GWSaveToDB.IconFactory")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class IconFactory
    {
        // ***********************************************************
        // Name:          GetIcons
        // 
        //    Description:  This interface is used to retrieve icons that
        //                  represent the state of the C3po record types.
        // 
        //    In:           sGWObjClass: string - String of the object class
        // 
        // 
        //    Out:          psGWIconFile: string - Name of the file containing the icons(.dll or .exe)
        //                  plGWUnOpenIcon: longint - Index value of the unopen icon
        //                  plGWOpenIcon: longint - Index value of the open icon
        // 
        //    Comments: The plGWUnOpenIcon and plGWOpenIcon parameters are icon index values within
        //              the module (.exe or .dll) named by the pIconFile parameter.  Returning
        //              a value of -1 indicates that a default icon should be used.  Any other
        //              negative index value indicates a resource ID by taking the absolute value
        //              of the number.  The IconFactory object does not support inheritance.
        //              That is, there is no mechanism for two C3POs to both offer icons for
        //              the same record.  The C3PO system will simply use the first C3PO it finds.
        // 
        //              The icons retrieved are presumed to contain multiple image sizes.  The
        //              appropriate size is used by GroupWise as needed.  The current C3PO
        //              specification does not allow the C3PO to specify specific icon overlays (
        //              such as the attachment clip).
        // 
        //              The full path must be specified for the function to work.
        // 
        // 
        // ************************************************************
        public void GetIcons(ref string sGWObjClass, ref string psGWIconFile, ref int plGWUnOpenIcon, ref int plGWOpenIcon)
        {
        }
    }
}
