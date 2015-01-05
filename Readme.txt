C3PO Wizard Readme.
You have created 11 new files using the C3PO wizard.

GWSaveToDB.wiz
C3POServer.cs         GWSaveToDB.cs
CommandFactory.cs     EventMonitor.cs
GWCommand.cs          Iconfactory.cs
readme.txt            AssemblyInfo.cs
Guids.cs              GWSaveToDB.csproj

The .wiz file is a ascii text file that can be edited to modify your C3PO code
generation. C3POWizGen uses your .wiz file to generate code. And can be used if
you have changed your .wiz file.

Steps to prepare your C3PO

1) Copy all generated .cs files and the one .csproj file into the directory that
you wish to build your C3PO.  Icons.dll is a dll that contains bitmap and icon
data that is used for the toolbar buttons and icons files.  Copy it over as well.

2) Use Visual Studio 2003/2005/.NET to open the project.

****NOTE: For Visual Studio 2003, the C3POTypeLibrary reference can not be added
correctly.  It is because the problem of Visual Studio 2003.  Remove the C3POTypeLibrary
reference and then re-added it back will solve the problem.


3) If you want to run your C3PO server as a shared/public copy, a strong name has to be
established, otherwise you can ignore this step. To generate a key file for used
in signing will be as the follow:

sn -k C3POserverKeyFile.snk

signing the Assembly can be done either through command line
cs /out:(your C3PO name).dll MyModule.cs ... /keyfile:sgKey.snk
or use Visual Studio to associate the keyfile to the Assembly
In project's properties page, choose signing category then associate the
keyfile to the Assembly.

4) The C3POTypeLibrary and System.Windows.Forms references have been added in
the current Visual Stadio project for accessing GroupWise COM object. This will
generate an output Interop.C3POTypeLibrary.DLL file(a binary file that
contains runtime metadata for the types defined within the original type
library--C3POTypeLibrary).  This is equivalent to use Type Library
Importer, tlbimp.exe, to converts the type definitions found within a COM type
library into equivalent definitions in a common language runtime assembly.

5) Using the .NET SDK tools RegAsm.exe to read the metadata within the Assembly
and adds the necessary entries to the registry, which allows COM clients to
create .NET Framework classes transparently.

Regasm.exe <your C3PO server>

6) Install assemblies -- your C3PO server and Interop.C3POTypeLibrary.DLL -- into
GAC(global Assembly cache) or copy the Assembly into GroupWise directory if
strong name (step 3) is not established.

Gacutil -i <your C3PO server>

7) To unregister the Assembly and type library use the same Regasm SDK utility
Regasm.exe /u <your C3PO server>


The C3po Wizard has created comments to help you to find where you need to add your
code. They all begin with "'C3PO WIZARD".

