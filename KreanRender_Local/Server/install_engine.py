import os
import sys
import argparse
import urllib.request
import zipfile
import subprocess
import shutil

def download_file(url, dest):
    print(f"Descargando {url}...")
    with urllib.request.urlopen(url) as response, open(dest, 'wb') as out_file:
        shutil.copyfileobj(response, out_file)

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--path", required=True, help="Ruta de instalación")
    parser.add_argument("--mode", default="CPU", help="Modo de instalación (CPU, GPU, GPU_LOW)")
    parser.add_argument("--model", default="SD 1.5 Base", help="Nombre del modelo a instalar")
    args = parser.parse_args()

    install_path = args.path
    engine_path = os.path.join(install_path, "python_env")
    models_path = os.path.join(install_path, "models")

    if not os.path.exists(engine_path):
        os.makedirs(engine_path)
    if not os.path.exists(models_path):
        os.makedirs(models_path)

    # 1. Descargar Python Embebido (Windows 64-bit)
    python_zip = os.path.join(install_path, "python_tmp.zip")
    python_url = "https://www.python.org/ftp/python/3.10.11/python-3.10.11-embed-amd64.zip"
    
    if not os.path.exists(os.path.join(engine_path, "python.exe")):
        download_file(python_url, python_zip)
        with zipfile.ZipFile(python_zip, 'r') as zip_ref:
            zip_ref.extractall(engine_path)
        os.remove(python_zip)
        print("Python embebido extraído.")

    # 2. Configurar pip
    pth_file = os.path.join(engine_path, "python310._pth")
    if os.path.exists(pth_file):
        with open(pth_file, "r") as f:
            lines = f.readlines()
        with open(pth_file, "w") as f:
            for line in lines:
                if line.strip() == "#import site":
                    f.write("import site\n")
                else:
                    f.write(line)

    get_pip_path = os.path.join(engine_path, "get-pip.py")
    if not os.path.exists(os.path.join(engine_path, "Scripts", "pip.exe")):
        download_file("https://bootstrap.pypa.io/get-pip.py", get_pip_path)
        subprocess.run([os.path.join(engine_path, "python.exe"), get_pip_path], check=True)
        os.remove(get_pip_path)

    # 3. Instalar librerías
    pip_exe = os.path.join(engine_path, "Scripts", "pip.exe")
    print(f"Instalando dependencias para modo {args.mode}...")
    
    base_pkgs = ["diffusers", "transformers", "accelerate", "opencv-python", "ftfy", "huggingface_hub", "pillow"]
    torch_cmd = [pip_exe, "install", "torch", "torchvision"]
    
    if "GPU" in args.mode.upper():
        torch_cmd += ["--index-url", "https://download.pytorch.org/whl/cu118"]
    else:
        torch_cmd += ["--index-url", "https://download.pytorch.org/whl/cpu"]

    subprocess.run(torch_cmd, check=True)
    subprocess.run([pip_exe, "install"] + base_pkgs, check=True)

    # 4. Descargar Modelo Seleccionado
    model_urls = {
        "SD 1.5 Base": "runwayml/stable-diffusion-v1-5",
        "Architecture Realism": "SG_1612/Realistic_Vision_V6.0",
        "Juggernaut XL": "Lykon/Juggernaut-XL"
    }
    
    hf_model_id = next((v for k, v in model_urls.items() if k in args.model), "runwayml/stable-diffusion-v1-5")
    print(f"Configurando modelo: {args.model} ({hf_model_id})...")
    
    with open(os.path.join(models_path, "current_model.txt"), "w") as f:
        f.write(hf_model_id)

    print("INSTALACION_FINALIZADA_OK")

if __name__ == "__main__":
    main()
