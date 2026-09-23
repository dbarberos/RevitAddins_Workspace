# Privacy Policy for TablePlus

**Last updated:** September 23, 2026

This Privacy Policy describes Our policies and procedures on the collection, use, and disclosure of Your information when You use the **TablePlus** Revit Add-in provided by **DBDev Solutions**.

---

## 1. Overview & Data Minimization Principle

**TablePlus operates entirely as an on-premise local extension for Autodesk Revit.** 

- TablePlus **does NOT collect, harvest, transmit, or monetize any personal data or BIM design models** to external tracking servers.
- All spreadsheet reading, cell styling parsing, coordinate transformations, and Revit detail line/text/filled region creation are processed entirely in-memory within your local workstation during the active Revit session.
- No telemetry, analytics, or background call-homes are made by the add-in.

---

## 2. Information Handled Locally

### A. Technical Diagnostics & Logging
- When enabled by the user or administrator, local diagnostic logs are written exclusively to your local machine under `%AppData%\DBDev\TablePlus\Logs`.
- Exception traces are sanitized to prevent exposing local directory username paths.

### B. User Configuration Settings
- Selected user preferences (such as default table view scale, default font overrides, and UI theme options) are saved locally within your Windows User Profile.

---

## 3. Contact & Inquiries

For any questions regarding this Privacy Policy or data security:
* **Company**: DBDev Solutions
* **Developer**: DBDev_dbarberos
* **Website**: https://dbdev-dbarberos.github.io
* **Email**: dbarberos@outlook.com
