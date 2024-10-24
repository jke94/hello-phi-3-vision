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

# B. Useful links

- [Phi-3-vision in 50 lines of C# with ONNX Runtime GenAI](https://nietras.com/2024/06/05/phi-3-vision-csharp-ortgenai/)

- [HuggingFace: microsoft/Phi-3-vision-128k-instruct-onnx-cpu](https://huggingface.co/microsoft/Phi-3-vision-128k-instruct-onnx-cpu)

- [Onnxruntime docs: Run the Phi-3 vision model with the ONNX Runtime generate() API](https://onnxruntime.ai/docs/genai/tutorials/phi3-v.html)