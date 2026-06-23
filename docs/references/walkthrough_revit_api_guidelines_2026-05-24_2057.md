# Instalación de la Skill: `revit-transactions` Completada

Se ha implementado con éxito la habilidad centralizada para el manejo de transacciones, cerrando la brecha de seguridad principal que suele corromper los modelos BIM cuando se producen excepciones no controladas.

## Resumen de Cambios

1. **Creación del Núcleo de Transacciones:**
   - **[SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-transactions/SKILL.md):** Define la obligatoriedad universal del manejo de transacciones para modificar el `Document`.
   - **[transaction_rules.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-transactions/references/transaction_rules.md):** Contiene la teoría técnica sobre el por qué del uso de `using` en C# (gestión de memoria C++) y explica en detalle los entornos anidados o *Clean Transactions* donde es obligatorio usar **`SubTransaction`** para aislar fallos.

2. **Plantillas Dual-Stack:**
   - **C#:** `TransactionTemplates.cs` con ejemplos de `using (Transaction...)` y métodos seguros con `SubTransaction`.
   - **Python:** `transaction_templates.py` con el *Context Manager* nativo de pyRevit (`with revit.Transaction("...")`) y el manejo mixto de `SubTransaction` a través del importador CLR.

3. **Integración Automática (Auto-Enforcement):**
   - He modificado la habilidad principal de C# ([revit-api/SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-api/SKILL.md)) para forzar a que toda modificación consulte las reglas estrictas de `revit-transactions`.
   - He modificado la habilidad principal de Python ([revit-pyrevit-python/SKILL.md](file:///b:/REVIT/C%23/RevitAddins_Workspace/.agents/skills/revit-pyrevit-python/SKILL.md)) en su "Step 3" para inyectar este mismo rigor a los scripts de pyRevit.

4. **Mantenimiento:**
   - El conocimiento técnico y los planes generados se han respaldado en la carpeta local de documentación (`docs/references/`).
