# Lesson Learned: TransferOrchestrator - Keep Original con Nombres Renombrados

## Fecha: 2026-07-17

## Problema
Cuando se transfieren elementos usando `ElementTransformUtils.CopyElements` y se emplea la opción **"Keep Original"** en combinación con el renombrado de elementos desde una paleta personalizada, se producía un comportamiento indeseado. 

Si el elemento a transferir se renombra (ej: "Muro A" a "Muro B") y "Muro B" ya existe en el documento destino, la intención de "Keep Original" es no copiar nada y mantener el original del destino. Sin embargo, como el origen sigue llamándose "Muro A", `CopyElements` lo transfiere al no encontrar colisión con "Muro A". Luego, el add-in intentaba renombrar el nuevo elemento a "Muro B", fallando silenciosamente y resultando en la copia no deseada del elemento (quedando "Muro B" y "Muro A" en el destino).

## Causa Raíz
`ElementTransformUtils.CopyElements` evalúa los nombres originales de los elementos en el documento origen durante la copia. Si la lógica confía en que `DuplicateTypeAction.UseDestinationTypes` maneje las colisiones, fallará porque la API no conoce el nombre renombrado que se aplicará *después* de la copia.

## Solución
Para resolver esto, se debe pre-filtrar la lista de elementos a copiar antes de enviársela a `CopyElements`.
1. Iterar sobre la lista inicial de elementos a copiar (`elementsCopyList`).
2. Evaluar el nombre renombrado (`evalName`).
3. Buscar si `evalName` ya existe en el destino.
4. Si existe y la opción es "Keep Original", hacer un `continue` (omitir el `Add` de ese elemento a una nueva lista `finalCopyList`).
5. Usar `finalCopyList` para el proceso de transferencia con `CopyElements`.

Esta misma lógica aplica para la transferencia de Estilos de Objeto (Categorías y Subcategorías): si existe la subcategoría en el destino y se usa "Keep Original", se debe omitir la llamada a `TransferSingleCategoryStyle` para no sobreescribir atributos de línea, grosor o material.
