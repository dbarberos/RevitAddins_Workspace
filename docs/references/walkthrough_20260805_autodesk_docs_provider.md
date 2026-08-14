# Technical Reference: Autodesk Docs (APS / ACC) Production Client ID Setup Guide

**Date:** 2026-08-05  
**Module:** TransferPlus  
**Pattern:** OAuth 2.0 PKCE + Automated Loopback Listener + Decoupled IFamilyProvider  

---

## 🎯 Mockup Configuration & Future Deployment Steps

The codebase is pre-configured to seamlessly authenticate users once **TransferPlus** is published to Autodesk App Store / Autodesk Platform Services (APS).

### Location of Mockup Constant:
- File: [AutodeskDocsService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/AutodeskDocsService.cs#L56)
- Code line:
  ```csharp
  public static string DefaultClientId { get; set; } = "YOUR_AUTODESK_APS_CLIENT_ID_HERE";
  ```

---

## 🔧 Steps to Activate Production Login for All Users

1. Go to [https://aps.autodesk.com/myapps](https://aps.autodesk.com/myapps) and create your application.
2. Set Callback URL to: `http://localhost:8989/callback/`
3. Enable APIs: **Data Management API** and **BIM 360 / ACC API**.
4. Copy the generated **Client ID** (e.g. `3kF92mX10aL8nQ4pZ7rW2vY5uT9sP1dE`).
5. Replace `"YOUR_AUTODESK_APS_CLIENT_ID_HERE"` with your Client ID in `AutodeskDocsService.cs`.

Once updated, clicking **`🔑 Sign In with Autodesk Account`** will open the official login page for all end-users automatically!
