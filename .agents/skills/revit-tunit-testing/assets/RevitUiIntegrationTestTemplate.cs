using Autodesk.Revit.UI;
using Nice3point.TUnit.Revit;
using Nice3point.TUnit.Revit.Executors;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace YourAddin.Tests.Integration;

/// <summary>
/// Validates that Ribbon elements, tabs, panels, and UI controls are registered inside Revit's UIApplication host.
/// </summary>
public sealed class RevitUiIntegrationTestTemplate : RevitApiTest
{
    private const string ExpectedTabName = "YourAddinTab";
    private const string ExpectedPanelName = "YourAddinPanel";
    private const string ExpectedButtonName = "YourAddinButton";

    [Test]
    [TestExecutor<RevitThreadExecutor>]
    public async Task RibbonPanel_IsRegisteredInRevit()
    {
        // Act: Retrieve all ribbon panels under the specified tab
        var panels = Application.GetRibbonPanels(ExpectedTabName);

        // Assert
        await Assert.That(panels).IsNotNull();
        await Assert.That(panels).IsNotEmpty();
        
        var targetPanel = panels.FirstOrDefault(p => p.Name == ExpectedPanelName);
        await Assert.That(targetPanel).IsNotNull();
    }

    [Test]
    [TestExecutor<RevitThreadExecutor>]
    public async Task RibbonButton_HasValidMetadata()
    {
        var panels = Application.GetRibbonPanels(ExpectedTabName);
        var targetPanel = panels.FirstOrDefault(p => p.Name == ExpectedPanelName);
        await Assert.That(targetPanel).IsNotNull();

        var ribbonItems = targetPanel!.GetRibbonItems();
        var targetButton = ribbonItems.OfType<PushButton>().FirstOrDefault(b => b.Name == ExpectedButtonName);

        // Assert
        await Assert.That(targetButton).IsNotNull();
        await Assert.That(targetButton!.ItemText).IsNotEmpty();
        await Assert.That(targetButton.ToolTip).IsNotEmpty();
        await Assert.That(targetButton.LargeImage).IsNotNull();
    }

    [Test]
    [TestExecutor<RevitThreadExecutor>]
    public async Task ActiveUIDocument_Context_IsAccessible()
    {
        // Validates that the active UI document context does not throw threading exceptions
        var uiDoc = Application.ActiveUIDocument;
        
        // Context is safely reachable (can be null if no document is opened)
        await Assert.That(Application).IsNotNull();
    }
}
