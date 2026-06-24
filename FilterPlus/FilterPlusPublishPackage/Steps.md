# Final Steps for Publishing FilterPlus v1.1.0

You have completed the generation of the **FilterPlus.bundle** package. Follow these steps to upload it to the Autodesk App Store:

1. **Review Assets**:
   - Open the `Screenshots/` folder and add at least **4 high-quality screenshots** (1280x800 px recommended).
   - Review `AppDescription.md` to ensure the professional tone matches your brand.

2. **Compression**:
   - Right-click on the `FilterPlus.bundle` folder (inside `FilterPlusPublishPackage`).
   - Select **Send to > Compressed (zipped) folder**.
   - Name the file `FilterPlus_v1.1.0_Bundle.zip`.

3. **Uploading to the Store**:
   - Go to the [Autodesk App Store Publisher Center](https://apps.autodesk.com/MyApps).
   - Create a new application for **Revit**.
   - Upload the `.zip` file you just created.
   - Copy and paste the content of `AppDescription.md` into the "Description" field (ensure it exceeds 4000 characters if strictly required by Autodesk).
   - Attach the link from `WebsiteInfo.txt` in the "Publisher Website" field.
   - Upload the Privacy Policy URL (you can upload the content of `PrivacyPolicy.md` to a service like GitHub Gist or Pastebin and provide the link there).

4. **Digital Signature (Optional)**:
   - If you decide to sign the DLLs later, remember to replace them inside the `Contents/[Year]/` folders before compressing the final ZIP.

5. **Installation Test**:
   - Before uploading, you can test the bundle locally by copying the `FilterPlus.bundle` folder to `%AppData%\Autodesk\ApplicationPlugins\`. If Revit loads it on startup, the package is correct.

---
*Generated automatically by Antigravity - Autodesk App Store Publisher Skill*
