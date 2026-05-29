---
name: apply-skillopt
description: Autonomously optimizes and documents technical knowledge and debugging lessons-learned from previous development cycles (C# and Python). Triggered via "aplica el skillopt para todo el trabajo realizado anterior de <feature/change>". Synthesizes lessons, creates technical reference guides, and extracts reusable code assets into corresponding global repository skills.
---

# Apply SkillOpt — Meta-Optimization of AI Skills

This skill acts as a dynamic knowledge consolidator and optimizer within the repository. It empowers the agent to autonomously extract best practices, Revit API design rules, and debugging resolutions from completed tasks, structuring and injecting them directly into the relevant global skills for future usage.

## 📚 Technical References (Knowledge Base)

Refer to the following files in the `references/` folder to understand the detailed SkillOpt operational workflow customized for this project:

*   `references/skillopt_workflow_guide.md`: Step-by-step guideline for trajectory analysis, verification, and automated updating of repository skills.

## 📦 Assets (Templates & Support Scripts)

Helper automation scripts reside under:

*   `scripts/git_analyzer.ps1`: (Optional) PowerShell script to analyze modified files in the last commit or active workspace state.
