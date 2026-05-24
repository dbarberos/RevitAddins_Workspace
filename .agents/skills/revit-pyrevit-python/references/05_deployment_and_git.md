# Deployment, Version Control, and Corporate Distribution

## 1. Importance of Version Control
Professional development demands protecting the source code. Hosting and backing up your pyRevit extensions in Git repositories (like GitHub, GitLab, or Azure DevOps) before it's "too late" is a mandatory practice. Git allows you to track changes, collaborate with other developers in the company, and revert code if an update breaks a workflow.

## 2. Repository Preparation
When preparing your tool for distribution:
* **Clean structure:** Ensure the repository directly contains the `.extension` folder (e.g., `MyCompany.extension`).
* **Ignore unnecessary files:** Configure a `.gitignore` file to exclude temporary files, Python caches (`.pyc`), or auto-generated items during testing.
* **Documentation:** Always include a `README.md` file in the root of the repository that explains how to use the extension and its dependencies.

## 3. Installation and Deployment Methods
There are two main ways to install pyRevit extensions on end-user computers:

### A. Manual Installation (Recommended for basic users or local testing)
The most straightforward method involves adding the extension to the user's Windows Roaming folder.
* Navigate to the path by entering `%appdata%` in the file explorer address bar.
* Copy the contents of the extension (the entire `.extension` folder) into the pyRevit extensions path (usually `%appdata%\pyRevit\Extensions`).
* Reload pyRevit in the Revit interface for the changes to take effect. This approach is useful for quick setups.

### B. Automated Installation via pyRevit CLI (Recommended for companies)
To avoid manual installations and facilitate corporate updates, you should use the pyRevit command-line interface (CLI). This method can be integrated into IT deployment scripts (e.g., `.bat` or PowerShell files).

**Command flow:**
1. Open the terminal (`cmd`).
2. Run the installation command pointing to the extension's Git repository.

*Example syntax:*
```cmd
pyrevit extend ui ExtensionName https://github.com/User/Repository.git --dest="C:\Install\Path" --branch=main
```

*(Note: Replace the URL and paths with those of your corporate server or repository. This will download the tool and instruct pyRevit to load it)*.
3. If Revit was already open, use the "Reload" button in pyRevit so the new tab appears.

## 4. Update Management

* When using the CLI method linked to a Git repository, pyRevit can seamlessly manage extension updates.
* **Separate environments:** Always maintain a `main` branch (production) and development branches (`dev`). End users should only point to the production branch to ensure the tools are stable.
