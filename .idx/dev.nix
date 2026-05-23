# Configuración de Entorno Novedoso para Google Project IDX / Antigravity
{ pkgs, ... }: {
  # Canal estable de paquetes NixOS
  channel = "stable-23.11";

  # Paquetes y herramientas del contenedor
  packages = [
    pkgs.dotnet-sdk_8
    pkgs.python311
    pkgs.git
  ];

  # Configuraciones específicas de Project IDX
  idx = {
    # Extensiones de VS Code a auto-instalar en el entorno
    extensions = [
      "ms-dotnettools.csdevkit"        # Soporte oficial para C# (.NET Core & net48)
      "ms-python.python"               # Soporte nativo para Python
      "ms-python.vscode-pylance"      # Análisis de tipos estáticos de Python
    ];

    # Ciclo de vida del espacio de trabajo
    workspace = {
      # Se dispara una vez al crear el espacio de trabajo
      onCreate = "dotnet restore";

      # Se dispara cada vez que el contenedor se despierta o inicia
      onStart = "";
    };
  };
}
