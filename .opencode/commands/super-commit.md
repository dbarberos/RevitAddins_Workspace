---
description: Group changes into semantic commits and push
---

Group all current changes into meaningful semantic commits and push the current branch.

Optional context for commit messages: `$ARGUMENTS`


Rules:

- First inspect the full
 - `git status --short`
 - `git diff --stat`
 - `git diff`
 - 'git log -- oneline -10'

- Identify related file groups by intent: feature, fix, refactor, tests, docs, chore, release, or config.

- Create multiple commits when there are independent changes. Do not mix unrelated changes in the same commit.
- If '$ARGUMENTS is not empty, use it as context to adjust commit messages, but do not force that text if it does not accurately describe The changes.
- Use clear, semantic, concise commit messages that follow the repo's recent style.
- Before committing, check for sensitive or suspicious files ('.env', tokens, credentials, keys, secrets). If any appear, stop and ask.
- Include new, modified, and deleted files that belong to each group.
- Do not revert existing changes. 
- Do not use '--no-verify'.
- Do not amend commits.
- Do not force push.

Flow
1. Show the proposed commit plan with the files included in each commit.
2. If the grouping is clear, continue. If there is real ambiguity, ask before committing.
3. For each group:
 - Add only the files for that group with <files>'
 - Create the commit with a semantic message.
4. Once all commits have been created, run: 'git push'
5. When finished, summarize the commits created and the changes




<!-- 
- List and compare changes to suggest an accurate commit message
- Group related changes to improve the commit message clarity
- Suggest a comprehensive description of changes 
- Avoid generic messages like "changes"
- Suggest emoji to enhance readability
- Suggest a short version for the title and a detailed version for the body of the commit message
- Ask for user input if needed to adjust message
- Show the full "git status --short" output
- Show the full "git diff --stat" output
- Group related changes into commits (feature, fix, refactor, tests, docs, chore, etc.)
- Create multiple commits when there are independent changes (no mixing unrelated changes)
- Use semantic commit messages ( Conventional Commits format if possible)
- Use clear, concise, descriptive commit messages
- Suggest emojis to enhance readability
- Suggest a short version for the title and a de tailed version for the body
- Ask for user input if the changes are ambiguous    -->

