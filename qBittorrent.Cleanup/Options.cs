
using CommandLine;

namespace qBittorrent.Cleanup
{
    public class Options
    {

        [Option('u', "user", Required = true, HelpText = "Username for your qBittorrent instance")]
        public string Username { get; set; }


        [Option('p', "pass", Required = true, HelpText = "Password for your qBittorrent instance")]
        public string Password { get; set; }


        [Option("url", Required = true, HelpText = "Url for your qBittorrent instance")]
        public string Url { get; set; }


        [Option("path", Required = true, HelpText = "The path to the directory containing your torrents")]
        public string Path { get; set; }


        [Option("dry-run", Required = false, HelpText = "Just outputs the things it would do, without actually doing it")]
        public bool DryRun { get; set; }

    }
}