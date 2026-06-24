# Generic Autodesk Publish Protocol for Any Revit Add‑in

## Goal Description

Create a reusable, generic protocol that the `revit-addin-publish-autodesk-store` skill can apply to **any** Revit add‑in the user creates. The protocol will:
- Prompt the user at runtime to choose between the standard **bundle** format or a **custom installer**.
- Generate a folder named `<AddInName>PublishPackage` (e.g., `MyCoolToolPublishPackage`).
- Inside that folder, create the required bundle structure, a placeholder `Screenshots/` directory, and supporting documentation files.
- Include a concise checklist (privacy policy, screenshots/video, description length, digital signature, website placeholder) that matches Autodesk’s guidelines.
- Produce a final `Steps.md` file that outlines the exact steps the user must follow to submit the package to the Autodesk App Store.

## User Review Required

> [!IMPORTANT]
> This plan creates placeholder assets (screenshots folder, privacy‑policy template, description stub, website placeholder). The user must later replace these with the real files.

## Open Questions

> [!NOTE]
> - **Folder naming:** The convention is `<AddInName>PublishPackage`. Confirm this is acceptable.
> - **Installer choice:** At runtime the skill will ask: *"Do you want to use the standard bundle format or a custom installer?"* If a custom installer is chosen, the user must provide the installer executable. No further details are needed now.
> - **Website URL:** Since none is available, we will insert a placeholder `https://example.com` in the generated `PackageContents.xml` and note that the user should replace it before submission.

## Proposed Changes

---
### 1. Skill File Modification (`revit-addin-publish-autodesk-store/SKILL.md`)

- **[MODIFY]** Extend the *Objetivo y Contexto* section to state that the skill works for **any** add‑in.
- Add a new subsection **"Selección de tipo de instalador"** that describes the runtime prompt for bundle vs. custom installer.
- Add a **"Checklist de Publicación Autodesk (genérica)"** that lists every requirement (privacy policy, screenshots/video, website placeholder, description ≥ 4000 chars, digital signature optional).
- Reference the new generic folder `<AddInName>PublishPackage` and the assets it will contain.
- Add a step **"Generar archivo Steps.md con el flujo completo (genérico)"**.

---
### 2. New Documentation Folder (created under the skill directory)

- **[NEW]** `<AddInName>PublishPackage/`
  - `PrivacyPolicy.md` – template with required sections (data collection, third‑party sharing, retention, revocation).
  - `Screenshots/` – empty folder; the skill will create it automatically. The final `Steps.md` will remind the user to place **at least 4 PNG/JPG images** or **3 images + 1 video**.
  - `WebsiteInfo.txt` – contains the placeholder URL `https://example.com`.
  - `AppDescription.md` – stub text (≈ 4000 characters) that the user must edit to meet Autodesk’s length requirement.
  - `DigitalSignatureInfo.md` – notes on optional code signing.
  - `Steps.md` – a markdown file that documents the entire publishing workflow, including the initial installer‑type prompt, bundle creation, XML generation, asset placement, compression, and upload instructions.

---
### 3. Runtime Interaction Logic (skill description only)

- When the skill is invoked, the agent will:
  1. Ask the user: **"¿Prefieres usar el formato estándar .bundle o un instalador personalizado?"**
  2. Record the answer (`bundle` or `custom`).
  3. If `custom` is chosen, request the path to the installer executable and store it inside `<AddInName>PublishPackage/CustomInstaller/`.
  4. Continue with the generic bundle creation (even for a custom installer we still generate the bundle for Autodesk’s optional acceptance).

---
### 4. Verification Plan

**Automated Tests**
- Execute a dry‑run of the skill with a mock add‑in name (e.g., `TestAddin`). Verify that:
  - Folder `TestAddinPublishPackage` is created.
  - All placeholder files and sub‑folders exist.
  - `Steps.md` contains the installer‑choice prompt description.

**Manual Verification**
- After the user supplies real screenshots and edits the placeholder files, they will run the skill again to produce the final `.bundle` and ZIP ready for upload.

---
### 5. Documentation Persistence

- Once approved and applied, the generated artifacts (`implementation_plan.md`, `task.md`, `walkthrough.md`) will be copied to the repository’s `docs/` folder following the naming convention `[artifact]_[keywords]_[YYYY-MM-DD_HHmm].md` as required by the repository rules.

## Verification Plan Summary

- **Automated dry‑run** to ensure folder and file creation.
- **User review** of placeholders and final steps.
- **Copy artifacts** to `docs/` after completion.
