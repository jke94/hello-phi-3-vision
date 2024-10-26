namespace hello_phi_3_vision.consoleapp
{
    #region using

    using CommandLine;

    #endregion

    public class CommandLineOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Enable verbose output.")]
        public bool Verbose { get; set; }
        
        [Option('m', "model", Required = true, HelpText = "Model path.")]
        public string? ModelPath { get; set; }
    }
}
