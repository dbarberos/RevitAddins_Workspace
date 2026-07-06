// Registro del panel en OnStartup (Requiere un GUID único para el panel)
DockablePaneId myPaneId = new DockablePaneId(new Guid("A1B2C3D4-E5F6-7A8B-9C0D-1E2F3A4B5C6D"));
MiPanelWebView2 myPane = new MiPanelWebView2(); // Hereda de Page e implementa IDockablePaneProvider

application.RegisterDockablePane(myPaneId, "Dashboard Web AECO", myPane);
