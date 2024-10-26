namespace hello_phi_3_vision
{
    #region using

    using Microsoft.ML.OnnxRuntimeGenAI;

    #endregion

    public interface IHelloPhi3VisionService
    {
        #region Methods

        public void Run(string modelPath, string userPrompt, string imagePath);

        #endregion
    }

    public class HelloPhi3VisionService : IHelloPhi3VisionService
    {
        #region Public Methods

        public void Run(string modelPath, string userPrompt, string imagePath)
        {
            using var model = new Model(modelPath);
            using var processor = new MultiModalProcessor(model);
            using var tokenizerStream = processor.CreateStream();

            var hasImage = !string.IsNullOrWhiteSpace(imagePath);

            Images? image = Images.Load(imagePath);
            Images? images = hasImage ? Images.Load(imagePath) : null;

            var prompt = "<|user|>\n";
            prompt += hasImage ? "<|image_1|>\n" : "";
            prompt += userPrompt + "<|end|>\n<|assistant|>\n";

            Console.WriteLine($"Processing...");
            using var inputs = processor.ProcessImages(prompt, images);

            Console.WriteLine($"Generating response...");
            using var generatorParams = new GeneratorParams(model);
            generatorParams.SetInputs(inputs);
            generatorParams.SetSearchOption("max_length", 3072);
            using var generator = new Generator(model, generatorParams);

            Console.WriteLine("================  Output  ================");
            while (!generator.IsDone())
            {
                generator.ComputeLogits();
                generator.GenerateNextToken();
                var newTokens = generator.GetSequence(0);
                var output = tokenizerStream.Decode(newTokens[^1]);
                Console.Write(output);
            }
            Console.WriteLine();
            Console.WriteLine("==========================================");

        }

        #endregion
    }
}
