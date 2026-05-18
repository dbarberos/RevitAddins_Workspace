# 🖋️ Digital Signing Guide for Revit Add-ins

This guide explains how to eliminate the "Untrusted Add-in" warning when loading FilterPlus or any other Revit add-in by using digital signatures (Code Signing).

---

## 🛡️ Why Sign the Add-in?
By default, Revit checks if the `.dll` assembly and the `.addin` manifest have a valid digital signature. If they do not, it displays a security warning dialog every time Revit starts. This is distracting and unprofessional for end-users.

---

## 🟢 Option 1: Development/Testing Certificate (Self-Signed)
*Ideal for internal deployment, office-wide testing, or during active development.*

### 1. Create the Certificate in Windows
Open **PowerShell as Administrator** and execute:
```powershell
New-SelfSignedCertificate -Type CodeSigningCert -Subject "CN=FilterPlus-DabaDev" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3") -KeyUsage DigitalSignature -FriendlyName "FilterPlus Code Signing" -NotAfter (Get-Date).AddYears(5)
```

### 2. Install the Certificate
To make the local machine trust the certificate automatically:
1.  Open `certmgr.msc` (Manage User Certificates).
2.  Navigate to **Personal > Certificates**.
3.  Right-click your certificate -> **All Tasks > Export...** (Export without private key, in `.cer` format).
4.  Import that `.cer` file into:
    *   **Trusted Root Certification Authorities**.
    *   **Trusted Publishers** (This step is CRITICAL to prevent Revit's confirmation popup).

---

## 🔵 Option 2: Production Certificate (Public CA)
*Required for publishing on the Autodesk App Store or distributing to external clients.*

1.  **Acquisition**: Purchase a Code Signing Certificate from a recognized Certification Authority (CA) such as Sectigo, DigiCert, or GlobalSign.
2.  **Verification**: The CA will verify your legal identity or company registration.
3.  **Deployment**: Revit will immediately recognize you as a verified publisher and let users select "Always trust add-ins from this publisher".

---

## ⚙️ Automating Visual Studio Builds
You can automate the signing of the compiled `.dll` every time you build in **Release** mode.

1.  Open the **Project Properties** for your Revit add-in.
2.  Go to **Build Events > Post-build event command line**.
3.  Paste the script (adjust the path to `signtool.exe` according to your Windows SDK version):

```cmd
if "$(ConfigurationName)" == "Release.R24" (
    "C:\Program Files (x86)\Windows Kits\10\bin\10.0.19041.0\x64\signtool.exe" sign /n "FilterPlus-DabaDev" /t http://timestamp.digicert.com /v "$(TargetPath)"
)
```

---

## 📋 Verification
Once signed, verify the DLL's digital signature state:
- Right-click the `.dll` file in Windows Explorer -> **Properties**.
- Navigate to the **Digital Signatures** tab.
- If your publisher name is listed, Revit will detect and validate the signature correctly on startup.
