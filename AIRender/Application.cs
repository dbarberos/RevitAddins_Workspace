/*
 * ============================================================
 * AUTOR: David Barbero Sastre
 * EMAIL: david.barbero@alten.es
 * EMPRESA: ALTEN (Oficina Madrid)
 * APLICACIÓN: KREAN_AIRender
 * DESCRIPCIÓN: Aplicación de Revit para la generación de imágenes renderizadas mediante IA a partir de vistas 3D EN CLOUD.
 * ============================================================
  * CLIENTE: KREAN Ingeniería (Oficina Madrid)
 * PROYECTO: Proyecto Básico Edificio Industrial ACTIUM MILE y CAT en el Cañaveral (Madrid)
 * FECHA: 25/04/2026
 * ============================================================
 */

using Nice3point.Revit.Toolkit.External;
using AIRender.Commands;
using JetBrains.Annotations;
using Nice3point.Revit.Extensions;
namespace AIRender;

/// <summary>
///     Application entry-point for KREAN_AIRender
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        CreateRibbon();
    }


    private void CreateRibbon()
    {
        var panel = Application.CreatePanel("KREAN_AIRender", "KREAN");

        panel.AddPushButton<StartupCommand>("KREAN_AIRender")
            .SetImage("/AIRender;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/AIRender;component/Resources/Icons/RibbonIcon32.png");
    }
}
