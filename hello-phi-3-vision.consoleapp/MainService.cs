namespace hello_phi_3_vision.consoleapp
{
    #region using

    using CommandLine;

    #endregion

    public interface IMainService
    {
        #region Methods

        public Task<int> RunAsync(string[] args);

        #endregion
    }

    public class MainService : IMainService
    {
        #region Fields

        private int _nUserPrompts = 0;
        private readonly IHelloPhi3VisionService _helloPhi3VisionService;

        #endregion

        #region Constructor

        public MainService(IHelloPhi3VisionService helloPhi3VisionService)
        {
            _helloPhi3VisionService = helloPhi3VisionService;
        }

        #endregion

        #region Public Methods

        public async Task<int> RunAsync(string[] args)
        {
            return await Parser.Default.ParseArguments<CommandLineOptions>(args)
            .MapResult(async (CommandLineOptions opts) =>
            {
                try
                {
                    return await Task.Run(() => RunPhi3Vision(opts));
                }
                catch
                {
                    Console.WriteLine("Error!");
                    return -3;
                }
            },
            errs => Task.FromResult(-1));
        }

        #endregion

        #region Private Methods

        private int RunPhi3Vision(CommandLineOptions options)
        {
            if (string.IsNullOrEmpty(options.ModelPath))
            {
                throw new Exception("Model path must be specified.");
            }

            Console.WriteLine("-------------");
            Console.WriteLine("Hello, Phi-3-Vision! To finalize program please enter '[EXIT]' string.");
            Console.WriteLine("-------------");

            Console.WriteLine("Model path: " + options.ModelPath);

            string? imagePath;
            string? prompt;
            bool running = true;

            do
            {
                Console.WriteLine($"Use case {_nUserPrompts}:");

                prompt = GetUserInputPromptFromCommandLine();

                if(!string.IsNullOrEmpty(prompt) && prompt.Equals("[EXIT]"))
                {
                    running = false;
                }
                else
                {
                    imagePath = GetUserImagePathInputFromCommandLine();

                    if (string.IsNullOrEmpty(prompt))
                    {
                        Console.WriteLine("Hi user! Please, enter a valid option.");
                    }
                    else if (prompt.Equals("[EXIT]"))
                    {
                        running = false;
                    }
                    else if (string.IsNullOrEmpty(imagePath))
                    {
                        Console.WriteLine("Hi user! Please, enter a image path valid.");
                    }
                    else
                    {
                        _nUserPrompts++;
                        _helloPhi3VisionService.Run(options.ModelPath, prompt, imagePath);
                    }
                }
            }
            while (running);

            return 0;
        }

        private string? GetUserImagePathInputFromCommandLine()
        {
            string? imagePath;

            Console.WriteLine($"Please, enter the image path:");

            do
            {
                imagePath = Console.ReadLine();

                if (string.IsNullOrEmpty(imagePath))
                {
                    Console.WriteLine("Please, enter a valid image path. Null or empty is not a valid prompt.");
                }
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"Please, enter a valid image path. The input '{imagePath}' does not exist.");
                }
            }
            while (string.IsNullOrEmpty(imagePath) && !File.Exists(imagePath));

            return imagePath;
        }

        private string? GetUserInputPromptFromCommandLine()
        {
            string? userPrompt;

            Console.WriteLine($"Please, enter a prompt:");

            do
            {
                userPrompt = Console.ReadLine();

                if(string.IsNullOrEmpty(userPrompt))
                {
                    Console.WriteLine("Please, enter a valid prompt. Null or empty is not a valid prompt.");
                }
            }
            while (string.IsNullOrEmpty(userPrompt));

            return userPrompt;
        }

        #endregion
    }
}
