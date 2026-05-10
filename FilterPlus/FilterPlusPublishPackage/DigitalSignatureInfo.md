# Information on Digital Signature

Autodesk recommends digitally signing your binaries and installer to avoid Windows security warnings ("Unknown Publisher").

### Current Status:
- The DLL files in `Contents/[Year]/` **are not digitally signed**.
- Autodesk allows publishing without a signature, but users will see a warning during installation.

### How to Sign in the Future:
1. Obtain a code signing certificate (Sectigo, DigiCert, etc.).
2. Use the `signtool.exe` tool from the Windows SDK:
   `signtool sign /f MyCert.pfx /p password /t http://timestamp.digicert.com FilterPlus.dll`
3. Replace the files in the bundle before compressing the final ZIP.
