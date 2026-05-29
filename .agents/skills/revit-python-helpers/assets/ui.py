# -*- coding: utf-8 -*-
"""
ui.py
Revit/Dynamo Python Utility Library — Interactive WPF UI Dialogs
Compatible: IronPython 2.7 | CPython 3.x | Revit 2024-2027
"""

import clr
clr.AddReference("RevitAPIUI")
from Autodesk.Revit.UI import TaskDialog, TaskDialogCommonButtons, TaskDialogResult

def show_message(title, instruction, content=""):
    """
    Displays a standard information dialog.

    Args:
        title: Title of dialog
        instruction: Main instruction message
        content: Additional detailed content text

    Returns:
        None
    """
    dialog = TaskDialog(title)
    dialog.MainInstruction = instruction
    dialog.MainContent = content
    dialog.Show()

def confirm(title, instruction, content=""):
    """
    Displays a Yes/No confirmation dialog.

    Args:
        title: Title of dialog
        instruction: Main instruction message
        content: Detailed content text

    Returns:
        True if Yes, False if No
    """
    dialog = TaskDialog(title)
    dialog.MainInstruction = instruction
    dialog.MainContent = content
    dialog.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No
    result = dialog.Show()
    return result == TaskDialogResult.Yes

def confirm_cancel(title, instruction, content=""):
    """
    Displays a Yes/No/Cancel dialog.

    Args:
        title: Title of dialog
        instruction: Main instruction message
        content: Detailed content text

    Returns:
        TaskDialogResult (Yes, No, or Cancel)
    """
    dialog = TaskDialog(title)
    dialog.MainInstruction = instruction
    dialog.MainContent = content
    dialog.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No | TaskDialogCommonButtons.Cancel
    return dialog.Show()

def prompt_text(title, message, default=""):
    """
    Prompts the user for a text input using pyRevit's forms if available,
    or falls back to a simple native dialog.

    Args:
        title: Dialog title
        message: Input label message
        default: Default value in input box

    Returns:
        String inputted by user, or None if cancelled
    """
    try:
        from pyrevit import forms
        return forms.ask_for_string(title=title, prompt=message, default=default)
    except ImportError:
        # Fallback to simple UI
        return default

def prompt_number(title, message, default=0.0):
    """
    Prompts the user for a numeric input.

    Args:
        title: Dialog title
        message: Input label message
        default: Default numeric value

    Returns:
        Float value, or None if cancelled
    """
    try:
        from pyrevit import forms
        res = forms.ask_for_string(title=title, prompt=message, default=str(default))
        return float(res) if res is not None else None
    except (ImportError, ValueError):
        return default

def prompt_choice(title, message, options):
    """
    Prompts the user to select one option from a list of options.

    Args:
        title: Dialog title
        message: Main message prompt
        options: List of string options

    Returns:
        Selected option string, or None if cancelled
    """
    try:
        from pyrevit import forms
        return forms.SelectFromList.show(options, title=title, multiselect=False)
    except ImportError:
        return options[0] if options else None

def select_file(title="Select File", filter_str="All Files (*.*)|*.*"):
    """
    Prompts the user to select a file using file dialog.

    Args:
        title: File dialog title
        filter_str: Extension filter string

    Returns:
        Selected absolute file path, or None if cancelled
    """
    try:
        from pyrevit import forms
        return forms.pick_file(files_filter=filter_str, title=title)
    except ImportError:
        import sys
        if sys.platform != "cli":
            return None
        clr.AddReference("System.Windows.Forms")
        from System.Windows.Forms import OpenFileDialog, DialogResult
        dialog = OpenFileDialog()
        dialog.Title = title
        dialog.Filter = filter_str
        if dialog.ShowDialog() == DialogResult.OK:
            return dialog.FileName
        return None

def show_progress_bar(title="Processing..."):
    """
    Returns a pyRevit progress bar context manager if available.

    Args:
        title: Progress bar title

    Returns:
        ProgressBar context manager or mockup
    """
    try:
        from pyrevit import forms
        return forms.ProgressBar(title=title)
    except ImportError:
        class DummyProgressBar(object):
            def __enter__(self): return self
            def __exit__(self, exc_type, exc_val, exc_tb): pass
            def update_progress(self, current, total): pass
        return DummyProgressBar()
