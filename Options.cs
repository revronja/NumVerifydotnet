using System;
namespace NumVerfifydotnet
{
    public class Options
    {
        [Option('u', "export-users", HelpText = "Toggle export of users.", Required = false, DefaultValue = true)]
        public bool ExportUsers { get; set; }

        [Option("number-of-jobs", HelpText = "Number of jobs to export.", Required = false, DefaultValue = Int32.MaxValue)]
        public int JobsToExport { get; set; }

        [Option('h', "help", HelpText = "Prints this help", Required = false, DefaultValue = false)]
        public bool Help { get; set; }
    }
}

/*
 * if (CommandLine.Parser.Default.ParseArguments(args, options))
{
    if (options.Help)
    {
        Console.WriteLine(CommandLine.Text.HelpText.AutoBuild(options));
        return;
    }
    Console.WriteLine(options.JobsToExport);
}
/*