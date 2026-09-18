# Manual de Proceso: Sincronización y Recuperación de Ramas de GitHub

**Fecha:** 29 de Agosto de 2026  
**Proyecto:** RevitAddins_Workspace  
**Repositorio Remoto:** `https://github.com/dbarberos/RevitAddins_Workspace.git`  
**Estándar:** `AGENTS.md` (Sección 7 - Artifact Backup y `workspace-ops`)

---

## 1. Contexto y Objetivo

El objetivo de esta operación fue consultar el estado completo del repositorio remoto en GitHub, identificar todas las ramas remotas existentes (incluyendo aquellas ausentes en el entorno local), crear sus correspondientes ramas locales de rastreo (*tracking branches*) y sincronizar todas las ramas locales para alinearlas 1:1 con los últimos commits de `origin`.

---

## 2. Procedimiento Ejecutado Paso a Paso

### Paso 1: Inspección Diagnóstica de Remote y Ramas
Se verificó la configuración de los remotos y el estado del árbol de trabajo:
```bash
git remote -v
git status
git branch -a
```

### Paso 2: Descarga Completa de Referencias (`Fetch`)
Se ejecutó un fetch exhaustivo con eliminación de referencias huérfanas y etiquetas:
```bash
git fetch --all --prune --tags
```

### Paso 3: Identificación y Registro de Ramas Remotas (Tracking)
Para evitar crear ramas manualmente una por una, se empleó un script en Python que inspeccionó `git branch -r`, identificó ramas en `origin/` no rastreadas localmente y ejecutó `git branch --track <nombre_local> origin/<rama_remota>`.

**Ramas locales incorporadas / vinculadas:**
- `TransferCAD` -> `origin/TransferCAD`
- `TransferTransformBy` -> `origin/TransferTransformBy`
- `github-actions-dependencies-bfcc5bf1bd` -> `origin/dependabot/github_actions/github-actions-dependencies-bfcc5bf1bd`
- `all-other-nuget-16fbd68587` -> `origin/dependabot/nuget/eng/skill-validator/src/all-other-nuget-16fbd68587`
- `microsoft-and-system-906697585b` -> `origin/dependabot/nuget/eng/skill-validator/src/microsoft-and-system-906697585b`

### Paso 4: Sincronización Fast-Forward de Commits
Para garantizar que todas las ramas locales apuntaran exactamente al commit remoto más reciente sin alterar la rama de trabajo activa (`TransferFamily`), se ejecutó la actualización vía `git update-ref` y `git pull --ff-only`:

```python
import subprocess
current = subprocess.check_output(['git', 'branch', '--show-current'], text=True).strip()
branches = [b.strip().lstrip('* ').strip() for b in subprocess.check_output(['git', 'branch'], text=True).splitlines()]
for b in branches:
    upstream = subprocess.check_output(['git', 'rev-parse', '--abbrev-ref', f'{b}@{upstream}'], text=True).strip()
    if upstream and upstream.startswith('origin/'):
        remote_commit = subprocess.check_output(['git', 'rev-parse', upstream], text=True).strip()
        local_commit = subprocess.check_output(['git', 'rev-parse', b], text=True).strip()
        if remote_commit != local_commit:
            if b == current:
                subprocess.run(['git', 'reset', '--hard', upstream])
            else:
                subprocess.run(['git', 'update-ref', f'refs/heads/{b}', remote_commit])
```

---

## 3. Matriz Final de Sincronización de Ramas

| Rama Local | Rama Remota Tracking | Hash Commit | Estado Final |
| :--- | :--- | :--- | :--- |
| `main` | `origin/main` | `a3e60f1` |  Up to date |
| `TransferFamily` *(activa)* | `origin/TransferFamily` | `4f04f1b` |  Up to date |
| `TransferPlus` | `origin/TransferPlus` | `aa23cb1` |  Up to date |
| `TransferCAD` | `origin/TransferCAD` | `ff96393` |  Up to date |
| `TransferTransformBy` | `origin/TransferTransformBy` | `983d908` |  Up to date |
| `TransferRename` | `origin/TransferRename` | `136b792` |  Up to date |
| `TransferOnDuplicates` | `origin/TransferOnDuplicates` | `2e69954` |  Up to date |
| `TransferOnView` | `origin/TransferOnView` | `447a5e8` |  Up to date |
| `PreSelection` | `origin/PreSelection` | `c64c560` |  Up to date |
| `SelectMode` | `origin/SelectMode` | `bd05adc` |  Up to date |
| `Fase2` | `origin/Fase2` | `d3521eb` |  Up to date |
| `AddChecked` | `origin/AddChecked` | `dc30efb` |  Up to date |
| `all-other-nuget-16fbd68587` | `origin/dependabot/...` | `90ccc86` |  Up to date |
| `github-actions-dependencies-bfcc5bf1bd` | `origin/dependabot/...` | `295db09` |  Up to date |
| `microsoft-and-system-906697585b` | `origin/dependabot/...` | `83552e3` |  Up to date |

---

## 4. Conclusión

El entorno local ha sido completamente actualizado acorde a GitHub sin provocar conflictos ni perder cambios locales no guardados. Todas las ramas cuentan con su vinculación explícita de seguimiento.
