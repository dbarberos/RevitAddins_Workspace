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
6. **Preserve Changelog History:** When updating the Version History (Changelog) section of the user guide or similar documents, the agent MUST NOT delete or overwrite comments from previous versions. New version updates must be appended at the top of the history to maintain a complete historical record of all changes.

## 📚 Technical References (Knowledge Base)
To obtain documentation inspection guides and procedures, consult the files in the `references/` folder:

*   `references/doc_extraction_and_scenarios.md`: Automatic code inspection processes and logical flows by scenarios.

## 📦 Assets (Templates and Documentation Examples)
The following files are found in the `assets/` folder and define the templates to be injected:

*   `assets/user_guide_template.md`: Standard structure and formatting rules for the add-in's `User_Guide.md` file.