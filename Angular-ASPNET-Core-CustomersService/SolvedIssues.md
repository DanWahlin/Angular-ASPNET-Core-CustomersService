# Unable to start process dotnet.exe

Had moved folder to a new location which messed up configuration in the
.vs folder. Just delete it and reopen the project.

https://elanderson.net/2016/09/unable-to-start-process-dotnet-exe/

# AOT fails

Had to add ./node_modules and ./wwwroot/libs to the exclusions in tsconfig.aot.json.