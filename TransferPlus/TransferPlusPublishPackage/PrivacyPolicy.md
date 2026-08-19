# Privacy Policy for TransferPlus

**Last updated:** August 17, 2026

This Privacy Policy describes Our policies and procedures on the collection, use, and disclosure of Your information when You use the **TransferPlus** Revit Add-in provided by **DBDev Solutions**.

---

## 1. Overview & Data Minimization Principle

**TransferPlus operates entirely as an on-premise local extension for Autodesk Revit.** 

- TransferPlus **does NOT collect, harvest, transmit, or monetize any personal data or BIM design models** to external tracking servers.
- All element copying, coordinate transformations, and standards migrations are processed entirely in-memory within your local workstation during the active Revit session.
- Cloud integrations (Autodesk Docs, Azure Blob Storage, AWS S3) connect strictly and directly to the customer's own authenticated storage buckets; credentials stored locally are encrypted via Microsoft Windows Data Protection API (DPAPI).

---

## 2. Information Handled Locally

### A. Technical Diagnostics & Logging
- When enabled by the user or administrator, local diagnostic logs are written exclusively to your local machine under `%AppData%\DBDev\TransferPlus\Logs`.
- Exception traces are sanitized to prevent exposing local directory username paths.

### B. User Configuration Settings
- Selected user preferences (such as default duplicate action, coordinate transformation mode, and UI layout preferences) are saved locally within your Windows User Profile.

---

## 3. Contact & Inquiries

For any questions regarding this Privacy Policy or data security:
* **Company**: DBDev Solutions
* **Developer**: DBDev_dbarberos
* **Website**: https://dbdev-dbarberos.github.io
* **Email**: dbarberos@outlook.com
