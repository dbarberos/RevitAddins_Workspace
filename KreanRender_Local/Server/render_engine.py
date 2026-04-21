import os
import sys
import argparse
import torch
import cv2
import numpy as np
from PIL import Image
from diffusers import StableDiffusionControlNetPipeline, ControlNetModel, UniPCMultistepScheduler

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--image", required=True, help="Ruta de la imagen de entrada")
    parser.add_argument("--prompt", required=True, help="Prompt positivo")
    parser.add_argument("--neg", default="", help="Prompt negativo")
    parser.add_argument("--out", required=True, help="Ruta de salida")
    parser.add_argument("--models_path", required=True, help="Carpeta de modelos")
    parser.add_argument("--steps", type=int, default=20)
    parser.add_argument("--guidance", type=float, default=7.5)
    parser.add_argument("--strength", type=float, default=0.8)
    args = parser.parse_args()

    # 1. Leer el modelo ID desde el archivo de configuración si existe
    config_file = os.path.join(args.models_path, "current_model.txt")
    model_id = "runwayml/stable-diffusion-v1-5"
    if os.path.exists(config_file):
        with open(config_file, "r") as f:
            model_id = f.read().strip()

    print(f"Iniciando Render con {model_id}...")
    
    # 2. Cargar Imagen y procesar Canny
    image = Image.open(args.image).convert("RGB")
    np_image = np.array(image)
    
    # Detectar bordes para ControlNet
    low_threshold = 100
    high_threshold = 200
    edges = cv2.Canny(np_image, low_threshold, high_threshold)
    edges = edges[:, :, None]
    edges = np.concatenate([edges, edges, edges], axis=2)
    canny_image = Image.fromarray(edges)

    # 3. Cargar ControlNet y Pipeline
    print("Cargando Pesos de IA...")
    
    controlnet = ControlNetModel.from_pretrained("lllyasviel/sd-controlnet-canny", torch_dtype=torch.float32)
    pipe = StableDiffusionControlNetPipeline.from_pretrained(
        model_id, controlnet=controlnet, torch_dtype=torch.float32
    )
    
    # Optimizaciones para CPU / RAM limitada
    pipe.scheduler = UniPCMultistepScheduler.from_config(pipe.scheduler.config)
    
    # En CPU no podemos usar float16 o xformers fácilmente, pero podemos liberar memoria
    if torch.cuda.is_available():
        pipe.to("cuda")
        print("Hardware detectado: GPU (Modo Turbo)")
    else:
        pipe.to("cpu")
        print("Hardware detectado: CPU (Modo Seguro)")

    # 4. Generación
    print(f"Renderizando (Steps: {args.steps}, Guidance: {args.guidance})...")
    
    def progress_callback(step, timestep, latents):
        progress = int((step / args.steps) * 100)
        print(f"PROGRESS: {progress}", flush=True)

    output = pipe(
        args.prompt,
        image=canny_image,
        negative_prompt=args.neg,
        num_inference_steps=args.steps,
        guidance_scale=args.guidance,
        controlnet_conditioning_scale=args.strength,
        callback=progress_callback,
        callback_steps=1
    ).images[0]

    # 5. Guardar
    output.save(args.out)
    print(f"RENDER_COMPLETADO: {args.out}")

if __name__ == "__main__":
    main()
