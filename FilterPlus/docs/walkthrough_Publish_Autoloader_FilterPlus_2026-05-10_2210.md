# Walkthrough - Generic Autodesk Publish Protocol

I have implemented a generic protocol for publishing Revit add‑ins to the Autodesk App Store. This protocol is now integrated into the `revit-addin-publish-autodesk-store` skill.

## Changes Made

### 1. Skill Enhancement
Modified the `SKILL.md` file in `.agent/skills/revit-addin-publish-autodesk-store/` to:
- Support any Revit add‑in by using dynamic folder naming (`<AddInName>PublishPackage`).
- Prompt the user to choose between a **Standard Bundle** and a **Custom Installer**.
- Include a comprehensive checklist for Autodesk requirements (Privacy Policy, Screenshots, App Description, etc.).

### 2. Assets and Templates
Created a template structure for the publishing package:
- `PrivacyPolicy.md`: A template for the mandatory privacy policy.
- `Steps.md`: A detailed guide on the publishing workflow.
- Placeholder for `Screenshots/` and `AppDescription.md`.

### 3. Documentation Persistence
Created the `docs/` directory and backed up the implementation plan, task list, and this walkthrough, following the repository's naming conventions.

## How to Use
1. Invoke the skill by saying: *"Run the Autodesk publish skill."*
2. Follow the prompts to choose your installer type.
3. Replace the placeholder files in the generated `PublishPackage` folder with your actual data.
4. Compress the resulting `.bundle` folder and upload it to the Autodesk App Store.

## Verification
- Checked `git status` to ensure all new assets are tracked.
- Verified file contents in the `.agent/skills` directory.
