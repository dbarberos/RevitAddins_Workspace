---
name: revit-addin-doc-manager
description: Autonomous management of documentation and versioning for Revit Add-ins through technical file inspection. Use this when generating a user guide, creating a changelog, or updating project documentation based on git tags and source code.
---

# Revit Add-in Documentation Skill (Autonomous Version)

This skill allows the agent to autonomously manage the add-in's documentation lifecycle, extracting technical truth directly from the source code and project configuration files.

## 🚨 Mandatory Critical Rules
1. **English Language:** All generated information written to the `User_Guide.md` (or similar documents) **MUST be written in English**.
2. **Historical Context and Artifacts:** To document how to use the options and features, the agent MUST NOT limit itself to looking at commits. **It must mandatorily read the `.md` artifact files** (e.g., in `docs/references/`) to extract the functionalities, uses, and evolution of each option.
3. **Comprehensive Update:** The manual must be updated across all its points from its origin to the current version. If a previous function has been modified, the main usage guide must be rewritten to reflect its state in the new tag, using the previous context from the artifacts.
4. **Friendly and Readable Structure (Textual UX):** The "Comprehensive Usage Guide" or description sections must be structured using bullet points, clear subsections, and tables to make reading very friendly and fast. Dense paragraphs or "walls of text" should be avoided.
5. **Autodesk App Store Standard:** All information regarding "Installation & Uninstallation" must strictly use the Autodesk App Store standard (explaining that the downloaded installer already does the job, the need to restart the Autodesk product, and the uninstallation method from the Control Panel).
6. **Preserve and Format Changelog History:** When updating the Version History (Changelog) section (in `User_Guide.md`, `help.html`, etc.), the agent MUST NOT delete or overwrite comments from previous versions. New version updates must be appended at the top. **CRITICAL: Do NOT show the release dates in the version headers** (use only the version tag, e.g. `### vX.Y.Z` or `### [X.Y.Z]`). Under `Added` and `Changed` sections, do NOT document code-level modifications or internal logic changes. Focus strictly on user-facing features and UI adjustments, summarized concisely in a single sentence.
7. **Developer Identity:** When generating any documentation or template, the agent MUST strictly use `DBDev_dbarberos` as the Author/Developer Name and `DBDev Solutions` as the Company Name. The use of generic AI placeholders like "AI_Corp" or "AI Solutions" is strictly forbidden.
8. **Revit Contextual Help (F1 help.html):** In projects that feature a `Resources/help.html` file (used for Revit F1 Contextual Help), the agent MUST synchronously update it alongside `User_Guide.md`. Its HTML content must mirror the user guide's structure, version, and changelog updates in clean, readable HTML, ensuring that F1 help is compiled with the latest application specs.

## 📚 Technical References (Knowledge Base)
To obtain documentation inspection guides and procedures, consult the files in the `references/` folder:

*   `references/doc_extraction_and_scenarios.md`: Automatic code inspection processes and logical flows by scenarios.

## 📦 Assets (Templates and Documentation Examples)
The following files are found in the `assets/` folder and define the templates to be injected:

*   `assets/user_guide_template.md`: Standard structure and formatting rules for the add-in's `User_Guide.md` file.