# Curated RevitPythonShell Sample Scripts Library

This curated index catalogs and explains high-value sample scripts from Daren Thomas's [rps-sample-scripts](https://github.com/daren-thomas/rps-sample-scripts) repository. These scripts illustrate advanced integration techniques, Revit UI manipulation, and external snooping from within the interactive shell.

---

## 1. Dynamic RevitLookup Snoop Hook (`revitsnoop.py`)

This script hooks dynamically into JEREMY TAMMIK's `RevitLookup` add-in if loaded in the current Revit session. It allows you to inspect any Revit object dynamically from the Python shell REPL!

```python
import clr
from Autodesk.Revit.DB import ElementSet

class RevitSnoop(object):
    """
    Dynamically accesses the loaded RevitLookup assembly and initiates Snoop Dialogs.
    """
    def __init__(self, uiApplication):
        # Scan currently loaded external applications to locate RevitLookup
        rlapp = [app for app in uiApplication.LoadedApplications
                 if app.GetType().Namespace == 'RevitLookup'
                 and app.GetType().Name == 'App'][0]
                 
        # Inject the assembly reference into IronPython's CLR
        clr.AddReference(rlapp.GetType().Assembly)
        import RevitLookup
        self.RevitLookup = RevitLookup
        
        # Inject current UI Application reference into the Snoop Extender
        self.RevitLookup.Snoop.CollectorExts.CollectorExt.m_app = uiApplication

    def snoop(self, element):
        """Displays the Snoop Objects dialog box for the given element."""
        elementSet = ElementSet()
        elementSet.Insert(element)
        form = self.RevitLookup.Snoop.Forms.Objects(elementSet)
        form.ShowDialog()
```

### How to use in shell:
```python
import revitsnoop

snooper = revitsnoop.RevitSnoop(__revit__)
# Snoop Project Info
snooper.snoop(doc.ProjectInformation)
# Snoop active view properties
snooper.snoop(doc.ActiveView)
```

---

## 2. Image View Exporter (`exportImage.py`)

Quickly exports the currently visible Revit view region as a high-quality `.PNG` raster image to a path chosen by the user.

```python
import clr
clr.AddReference('RevitAPI')
clr.AddReference('System.Windows.Forms')
from Autodesk.Revit.DB import *
from System.Windows.Forms import DialogResult, SaveFileDialog

doc = __revit__.ActiveUIDocument.Document

# Request export filepath from user via Standard SaveFileDialog
dialog = SaveFileDialog()
dialog.Title = 'Export Active Revit View as PNG'
dialog.Filter = 'PNG Files (*.PNG)|*.PNG'

if dialog.ShowDialog() == DialogResult.OK:
    # Build Image Export options
    options = ImageExportOptions()
    options.ExportRange = ExportRange.VisibleRegionOfCurrentView
    options.FilePath = dialog.FileName
    options.HLRandWFViewsFileType = ImageFileType.PNG
    options.ShadowViewsFileType = ImageFileType.PNG
    options.ImageResolution = ImageResolution.DPI_72
    options.ZoomType = ZoomFitType.Zoom
    
    # Run the Export
    doc.ExportImage(options)
    print("Successfully exported image to: {}".format(dialog.FileName))

__window__.Close()
```

---

## 3. Dynamic Ribbon Building on Startup (`simple_ribbon.py`)

Using the RPS variable `__uiControlledApplication__` during the startup sequence, you can dynamically build new Revit Ribbon Panels, load custom button icons, and compile script targets into lightweight runtime assemblies.

```python
import os
from RevitPythonShell.RpsRuntime import ExternalCommandAssemblyBuilder
from Autodesk.Revit.UI import *

try:
    # Resolve absolute path to the target python script file
    script_directory = __vars__['EXAMPLES_PATH']
    target_script = os.path.join(script_directory, "helloworld.py")
    
    # Path where RevitPythonShell should dynamically compile the DLL assembly wrapper
    dll_assembly_path = os.path.expandvars(r"%APPDATA%\RevitPythonShell\dynamic_ribbon.dll")
    
    # Compile the script to dynamic command wrapper DLL
    builder = ExternalCommandAssemblyBuilder()
    builder.BuildExternalCommandAssembly(
        dll_assembly_path,
        {'HelloWorldCommand': target_script}
    )
    
    # Create Ribbon Panel on Revit UI Ribbon tab
    ribbon_panel = __uiControlledApplication__.CreateRibbonPanel('Python Tools')
    
    # Instantiate button data wrapping DLL command
    button_data = PushButtonData(
        'pb_HelloWorld',
        'Hello World',
        dll_assembly_path,
        'HelloWorldCommand'
    )
    
    # Add to UI Panel
    ribbon_panel.AddItem(button_data)
    
except Exception as ex:
    import traceback
    traceback.print_exc()
```

---

## 4. Bulk Text and Room Case Standardizers

These lightweight utility macros parse, filter, and cast string parameters (`Room Name`, `Text Notes`) to UPPERCASE or lowercase.

### Room Name Uppercaser (Selected elements):
```python
import clr
clr.AddReference('RevitAPI')
from Autodesk.Revit.DB import *

doc = __revit__.ActiveUIDocument.Document
uidoc = __revit__.ActiveUIDocument

t = Transaction(doc, 'Capitalize Selected Room Names')
t.Start()

# Retrieve selected elements
selection_ids = uidoc.Selection.GetElementIds()

for element_id in selection_ids:
    element = doc.GetElement(element_id)
    if isinstance(element, Architecture.Room):
        # Capitalize Room Name parameter
        room_name_param = element.get_Parameter(BuiltInParameter.ROOM_NAME)
        if room_name_param and not room_name_param.IsReadOnly:
            uppercase_name = room_name_param.AsString().upper()
            room_name_param.Set(uppercase_name)

t.Commit()
```
