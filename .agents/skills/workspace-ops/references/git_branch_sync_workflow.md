# Workflow Guía: Sincronización Masiva de Ramas Git en Workspace

Este documento proporciona el procedimiento estándar y scripts reutilizables para recuperar, rastrear y actualizar todas las ramas remotas de GitHub en un proyecto local.

## 1. Comandos de Inspección y Fetch Básicos

```bash
# 1. Traer todos los objetos, ramas y tags limpiando referencias remotas eliminadas
git fetch --all --prune --tags

# 2. Listar todas las ramas locales y su correspondiente remote de rastreo
git branch -vv
```

## 2. Script Automatizado en Python para Rastreo y Actualización

Este script puede ejecutarse de forma segura en Windows/PowerShell o Bash para:
1. Crear el rastreo local (`--track`) de cualquier rama remota nueva.
2. Hacer `reset --hard` en la rama activa si está por detrás de origin.
3. Actualizar silenciosamente las ramas inactivas mediante `git update-ref` sin necesidad de cambiarse de rama (`checkout`).

```python
import subprocess

def sync_all_branches():
    # 1. Fetch remotos
    subprocess.run(['git', 'fetch', '--all', '--prune', '--tags'], check=True)

    # 2. Obtener rama actual y ramas locales
    current = subprocess.check_output(['git', 'branch', '--show-current'], text=True).strip()
    remote_branches = subprocess.check_output(['git', 'branch', '-r'], text=True).splitlines()

    # 3. Crear tracking branches faltantes
    for r in remote_branches:
        r_clean = r.strip()
        if 'origin/' in r_clean and 'HEAD' not in r_clean:
            local_name = r_clean.split('/')[-1]
            subprocess.run(['git', 'branch', '--track', local_name, r_clean], capture_output=True)

    # 4. Sincronizar commits de todas las ramas locales con su upstream
    local_branches = [b.strip().lstrip('* ').strip() for b in subprocess.check_output(['git', 'branch'], text=True).splitlines()]
    for b in local_branches:
        try:
            upstream = subprocess.check_output(['git', 'rev-parse', '--abbrev-ref', f'{b}@{{upstream}}'], text=True).strip()
            if upstream and upstream.startswith('origin/'):
                remote_commit = subprocess.check_output(['git', 'rev-parse', upstream], text=True).strip()
                local_commit = subprocess.check_output(['git', 'rev-parse', b], text=True).strip()
                if remote_commit != local_commit:
                    if b == current:
                        subprocess.run(['git', 'reset', '--hard', upstream])
                        print(f"[SYNC] {b} (actual) sincronizada a {remote_commit[:7]}")
                    else:
                        subprocess.run(['git', 'update-ref', f'refs/heads/{b}', remote_commit])
                        print(f"[SYNC] {b} sincronizada a {remote_commit[:7]}")
                else:
                    print(f"[OK] {b} ya está al día con {upstream}")
        except Exception as e:
            print(f"[WARN] Error verificando rama {b}: {e}")

if __name__ == '__main__':
    sync_all_branches()
```

## 3. Verificación de Integridad

Finalizar siempre verificando que no existan cambios pendientes ni conflictos desatendidos:
```bash
git status
```
