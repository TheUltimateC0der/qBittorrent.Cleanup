using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using CommandLine;

using QBittorrent.Client;

namespace qBittorrent.Cleanup
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var parsedArguments = Parser.Default.ParseArguments<Options>(args);

            await parsedArguments.WithParsedAsync(RunOptions);
        }


        private static async Task RunOptions(Options opts)
        {
            if (opts.DryRun)
                Console.WriteLine($"Dry run!");

            var deleteCount = 0;
            long spaceSaved = 0;

            var client = new QBittorrentClient(new Uri(opts.Url));
            await client.LoginAsync(opts.Username, opts.Password);

            var torrents = await client.GetTorrentListAsync();

            foreach (var directory in Directory.GetDirectories(opts.Path).OrderBy(x => x))
            {
                var dirName = Path.GetFileName(directory);
                if (!torrents.Any(x => x.Name == dirName))
                {
                    var dirSize = DirSize(new DirectoryInfo(directory));

                    Console.WriteLine($"Deleting: ({BytesToString(dirSize)}) {directory}");

                    if (!opts.DryRun)
                        Directory.Delete(directory, true);

                    deleteCount++;
                    spaceSaved += dirSize;
                }
            }

            Console.WriteLine($"Deleted {deleteCount} of left behind torrents which saves {BytesToString(spaceSaved)}.");
        }


        private static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            var fis = d.GetFiles();
            foreach (var fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            var dis = d.GetDirectories();
            foreach (var di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            var bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            var num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}