# 🖋️ Guía de Firma Digital para Add-ins de Revit

Esta guía explica cómo eliminar la advertencia de "Add-in no confiable" al cargar FilterPlus en Revit mediante el uso de firmas digitales (Code Signing).

---

## 🛡️ ¿Por qué firmar el Add-in?
Por defecto, Revit comprueba si el archivo `.dll` y el archivo `.addin` tienen una firma digital válida. Si no la tienen, muestra un mensaje de advertencia cada vez que se inicia Revit, lo cual resulta poco profesional y molesto para el usuario final.

---

## 🟢 Opción 1: Certificado de Prueba (Self-Signed)
*Ideal para uso interno o durante el desarrollo.*

### 1. Crear el certificado en Windows
Abre **PowerShell como Administrador** y ejecuta:
```powershell
New-SelfSignedCertificate -Type CodeSigningCert -Subject "CN=FilterPlus-DabaDev" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3") -KeyUsage DigitalSignature -FriendlyName "FilterPlus Code Signing" -NotAfter (Get-Date).AddYears(5)
```

### 2. Instalar el certificado
Para que Revit confíe automáticamente:
1.  Abre `certmgr.msc` (Certificados de usuario).
2.  Busca tu certificado en **Personal > Certificados**.
3.  Haz clic derecho -> **Todas las tareas > Exportar** (sin clave privada, formato .cer).
4.  Importa ese archivo `.cer` en:
    *   **Entidades de certificación raíz de confianza**.
    *   **Editores de confianza** (Este paso es CLAVE para evitar el mensaje de Revit).

---

## 🔵 Opción 2: Certificado Profesional (CA Pública)
*Necesario para publicar en la Autodesk App Store o para clientes externos.*

1.  **Adquisición**: Comprar un certificado de firma de código (Sectigo, DigiCert, GlobalSign).
2.  **Validación**: La entidad verificará tu identidad o la de tu empresa.
3.  **Uso**: Revit reconocerá al autor inmediatamente y permitirá marcar la casilla "Confiar siempre".

---

## ⚙️ Automatización en Visual Studio
Puedes automatizar la firma de la DLL cada vez que compiles en modo **Release**.

1.  En las **Propiedades del Proyecto** de FilterPlus.
2.  Ve a **Build Events > Post-build event command line**.
3.  Pega el siguiente script (ajustando la ruta de `signtool.exe` según tu versión de Windows SDK):

```cmd
if $(ConfigurationName) == Release.R24 (
    "C:\Program Files (x86)\Windows Kits\10\bin\10.0.19041.0\x64\signtool.exe" sign /n "FilterPlus-DabaDev" /t http://timestamp.digicert.com /v "$(TargetPath)"
)
```

---

## 📋 Comprobación Final
Una vez firmado, puedes verificar si la DLL es válida haciendo clic derecho sobre ella en el Explorador de Archivos -> **Propiedades > Firmas digitales**. Si aparece tu nombre o el de tu empresa, Revit lo detectará correctamente.
