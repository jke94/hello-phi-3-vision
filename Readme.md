# hello-phi-3-vision
Proof of concept to use [**https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu**](https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu) model in .NET ecosystem with ONNX runtime running in CPU.

## A. Initializing setup to run the proof of concept.

Note: Windows process.

### 1. Create python virtual environment.

```
python -m venv venv
```
### 2. Activate virtual environment.

```
.\venv\Scripts\activate
```
### 3. Install **huggingface-hub[cli]**.

```
pip install huggingface-hub[cli]
```
### 4. HuggingFace downloading process.

#### 4.1. Download model **microsoft/Phi-3-mini-4k-instruct-onnx**

Use case to be used in CPU environments.

```
huggingface-cli download microsoft/Phi-3-vision-128k-instruct-onnx-cpu --include cpu-int4-rtn-block-32-acc-level-4/* --local-dir models/microsoft/Phi-3-vision-128k-instruct-onnx-cpu
```
### 5. Build solution.

Use case to be used with CPU environments.

```
dotnet build .\hello-phi-3-vision.sln -c Release
```

## B. Playing with Phi3-Vision in CPU!

### 1. Run example:

```
dotnet run --project .\hello-phi-3-vision.consoleapp\hello-phi-3-vision.consoleapp.csproj -c Release --model J:\Repositories\hello-phi-3-vision\models\microsoft\Phi-3-vision-128k-instruct-onnx-cpu\cpu-int4-rtn-block-32-acc-level-4
```

### 2. Example output!

```
PS J:\Repositories\hello-phi-3-vision> dotnet run --project .\hello-phi-3-vision.consoleapp\hello-phi-3-vision.consoleapp.csproj -c Release --model .\models\microsoft\Phi-3-vision-128k-instruct-onnx-cpu\cpu-int4-rtn-block-32-acc-level-4
-------------
Hello, Phi-3-Vision! To finalize program please enter '[EXIT]' string.
-------------
Model path: .\models\microsoft\Phi-3-vision-128k-instruct-onnx-cpu\cpu-int4-rtn-block-32-acc-level-4
Use case 0:
Please, enter a prompt:
Could you describe the image?
Please, enter the image path:
J:\Repositories\hello-phi-3-vision\image_1.jpg
Processing...
Generating response...
================  Output  ================
The image is a promotional poster for the 2024 Gran Premio GoPro de Aragón motorcycle racing event. It features a group of motorcyclists in racing suits with sponsor logos, standing in front of a dark background that resembles a racetrack. The text 'MOTORLAND ARAGON' is prominently displayed in large white letters across the center of the poster. The event dates '30 - 31 Ago 11 Sept' are mentioned at the top, and the hashtag '#AragonGP' is visible. The bottom of the poster includes logos of GoPro, FIM, and MOTORLAND, along with the text 'GRAN PREMIO DE ARAGON 2024' and 'MOTORLAND Aragón'. The overall design suggests an official MotoGP poster.
==========================================
Use case 1:
Please, enter a prompt:
[EXIT]
PS J:\Repositories\hello-phi-3-vision>
```

# B. Useful links

- [Phi-3-vision in 50 lines of C# with ONNX Runtime GenAI](https://nietras.com/2024/06/05/phi-3-vision-csharp-ortgenai/)

- [HuggingFace: microsoft/Phi-3-vision-128k-instruct-onnx-cpu](https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu)

- [Onnxruntime docs: Run the Phi-3 vision model with the ONNX Runtime generate() API](https://onnxruntime.ai/docs/genai/tutorials/phi3-v.html)