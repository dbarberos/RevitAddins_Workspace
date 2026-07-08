---
name: revit-private-nuget-feed
description: Manages the creation, building, and configuration of custom private NuGet packages for official Revit API binaries, establishing local project feeds and CI/CD version caching to eliminate third-party dependencies.
---

# Revit Private NuGet Feed

This skill assists in the creation and maintenance of a local workspace NuGet feed containing official Revit API DLLs, providing packaging automation scripts, config templates, and instructions for CI/CD version caching.

## 📚 Technical References (Knowledge Base)
Check the following files in the `references/` folder for in-depth guides:

*   `references/revit_nuget_feed_guide.md`: Technical guide for Revit DLL extraction, packaging, version pinning, and feed configuration.

## 🔧 Assets (Templates & Scripts)
The following configuration templates are located in the `assets/` folder:

*   `assets/RevitAPI.nuspec`: Reusable NuGet packaging specification template.
*   `assets/nuget.config`: Configuration template to register a relative local workspace NuGet feed.

The following automation script is located in the `scripts/` folder:

*   `scripts/pack_revit_api.ps1`: PowerShell script to extract and pack Revit DLLs into a custom NuGet package.
