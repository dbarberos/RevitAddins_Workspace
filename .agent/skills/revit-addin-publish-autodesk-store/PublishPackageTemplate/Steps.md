# Pasos para publicar el Add‑in en Autodesk App Store

1. **Selección de instalador** – Cuando invoques el skill, el agente preguntará si deseas usar el **formato estándar .bundle** o un **instalador personalizado**.
   - Si eliges **bundle**, el agente seguirá el flujo de creación del paquete `.bundle`.
   - Si eliges **custom**, deberás proporcionar la ruta al instalador (`.exe`/`.msi`) y el agente lo copiará a `CustomInstaller/`.

2. **Creación de la carpeta `<AddInName>PublishPackage`** – El agente crea automáticamente una carpeta con el nombre del Add‑in seguido de `PublishPackage` (p. ej. `MyAddinPublishPackage`).

3. **Estructura básica** – Dentro de esa carpeta se generan los siguientes elementos:
   - `PrivacyPolicy.md` – plantilla de política de privacidad.
   - `Screenshots/` – carpeta donde colocar **≥ 4 imágenes** o **3 imágenes + 1 video**.
   - `WebsiteInfo.txt` – contiene `https://example.com` (reemplazar con la URL real).
   - `AppDescription.md` – texto placeholder (mínimo 4000 caracteres). Si existe `Guia_Uso.md` generado por `revit-addin-doc-manager`, su contenido se copiará aquí.
   - `DigitalSignatureInfo.md` – notas sobre la firma digital del instalador (opcional).
   - `Steps.md` – este archivo (el propio) que describe el proceso completo.

4. **Generación del bundle** – El agente extrae los metadatos del proyecto, genera `PackageContents.xml`, copia el `.dll` y el `.addin` adaptado, y crea la estructura `.bundle` dentro de la carpeta `Contents/`.

5. **Documentación** – Si hay un `Guia_Uso.md` en la raíz del proyecto, el agente lo convertirá a `Help.html` dentro de `Contents/Resources/` y también lo insertará en `AppDescription.md`.

6. **Compresión** – Al finalizar, el agente sugiere comprimir la carpeta `<AddInName>.bundle` en un `.zip` listo para subir a la Autodesk App Store.

7. **Checklist final** – Verifica que:
   - La política de privacidad está completa.
   - Se han añadido al menos 4 capturas de pantalla (o 3 + video).
   - La descripción tiene al menos 4000 caracteres.
   - La URL del sitio web está actualizada.
   - Si se usa instalador custom, está firmado digitalmente (opcional).
   - El archivo `PackageContents.xml` contiene los datos correctos.

Una vez completados estos pasos, el paquete está listo para su envío a Autodesk.
