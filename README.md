# qBittorrent.Cleanup
A small tool to cleanup torrents that do not exist anymore in qBittorrent instance


# How to use
## Install .Net Core 3.1
```
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-runtime-3.1
```

## Download latest release
Download the latest `qBittorrent.Cleanup.zip` from the releases page

https://github.com/TheUltimateC0der/qBittorrent.Cleanup/releases

## Run

### Show help
`dotnet qBittorrent.Cleanup.dll --help`
```
qBittorrent.Cleanup 1.0.0
Copyright (C) 2020 TheUltimateC0der

  -u, --user    Required. Username for your qBittorrent instance

  -p, --pass    Required. Password for your qBittorrent instance

  --url         Required. Url for your qBittorrent instance

  --path        Required. The path to the directory containing your torrents

  --dry-run     Just outputs the things it would do, without actually doing it

  --help        Display this help screen.

  --version     Display version information.
```

### Delete stuff
```
dotnet qBittorrent.Cleanup.dll -u YourUserName -p YourTotallySecurePassword --path /mnt/local/downloads/torrents/qbittorrent/completed --url https://qbittorrent.mydomain.org
```
