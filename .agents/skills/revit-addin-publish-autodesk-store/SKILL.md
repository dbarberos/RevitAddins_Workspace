# Skill: Autodesk App Store Publisher (Autoloader Format)

**Version:** 1.2
**Description:** Automates the creation of the `.bundle` format and the `PackageContents.xml` file required to publish Revit Add-ins in the Autodesk App Store, complying with the standards for rejecting custom installers.

---

## 🟢 1. Inspection and Metadata Phase
When activating this skill, the Agent must proactively extract:
1.  **Technical Metadata**: `AppName`, `Version`, `AddInId`, and `VendorId` from the `.csproj` and `.addin` files.
2.  **Version Range**: Identify `SeriesMin` and `SeriesMax` by analyzing the Revit API references.
3.  **Compliance Checklist**:
    - **App Description**: Must have a minimum of **4000 characters**.
    - **Privacy Policy**: Must cover: Data Collection, Third Parties, Retention/Deletion, and Revocation of consent.
    - **Screenshots**: Minimum 4 images (or 3 + 1 video).
    - **Website**: URL of the site or Autodesk publisher profile.

---

## 🛠 2. Packaging Logic (.bundle)

### Step A: Autoloader Structure
The Agent will create the `FilterPlusPublishPackage/FilterPlus.bundle/` folder with the following hierarchy:
```text
FilterPlus.bundle/
├── PackageContents.xml (Bundle Root)
└── Contents/
    ├── 2023/ (Version subfolders if DLLs differ)
    │   ├── FilterPlus.dll
    │   └── FilterPlus.addin
    ├── 2024/ ...
    └── Resources/
        ├── Icon16.png
        ├── Icon32.png
        └── Help.html (Documentation converted from Markdown)
```

### Step B: `PackageContents.xml`
Although the packaging script can generate this XML for local developer testing, **Critical Rule**: The `PackageContents.xml` file **MUST NOT be included** within the final `.zip` file that is uploaded to the store. The Autodesk portal generates this file automatically during the submission process based on the information entered on the website.

### Step C: Contextual Help Integration (F1)
**Critical Rule**: The application must mandatorily have a local `help.html` file (generated from the user guide) and the Ribbon button must point to it using the `SetContextualHelp()` method pointing to `Resources/help.html`.

### Step C: `.addin` Manifest Modification
**Critical Rule**: The `<Assembly>` tag inside the distributed `.addin` file MUST NOT have absolute paths or folders. It must point directly to the file in the same folder:
` <Assembly>FilterPlus.dll</Assembly>`

---

## 🛡 3. Publication Rules (Anti-Rejection)

### 1. Custom Installer Replacement
Autodesk prefers the bundle format because its portal automatically generates the final MSI. 
- **Action**: Disable the generation of a custom MSI unless the app requires changes to the Windows Registry or complex external dependencies.

### 2. Internal Privacy Policy
The app must include a link to the privacy policy accessible from the interface (e.g., in the Settings or Help button).

### 3. Multi-Version Support
If versions from Revit 2025+ are detected, the Agent must warn about the requirement of the **.NET 8.0 Runtime** in the app description.

---

## 📋 4. Final Workflow
1.  **Generate**: Create the publication folder with all compliance `.md` files.
2.  **Validate**: Verify that the description exceeds 4000 characters.
3.  **Document**: Convert `Guia_Uso.md` to `Help.html` using the available rendering engine.
4.  **Package**: Instruct the user to compress ONLY the `.bundle` folder into a `.zip`.