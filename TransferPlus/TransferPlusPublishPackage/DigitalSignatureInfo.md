# Information on Digital Signature

Autodesk recommends digitally signing your binaries and installer to avoid Windows security warnings ("Unknown Publisher").

### Current Status:
- The DLL files in `Contents/[Year]/` **are not digitally signed**.
- Autodesk allows publishing without a signature, but users will see an "Unknown Publisher" prompt during installation.

### How to Sign in the Future:
1. Obtain an Authenticode code signing certificate (e.g. from Sectigo, DigiCert, GlobalSign).
2. Use `signtool.exe` from the Windows SDK:
   ```cmd
   signtool sign /f MyCert.pfx /p password /tr http://timestamp.digicert.com /td sha256 /fd sha256 TransferPlus.dll
   ```
3. Replace the signed binaries in `Contents/[Year]/` prior to running `build-bundle.ps1`.
