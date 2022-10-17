// See https://aka.ms/new-console-template for more information

// Initialize all variables we'll be using.
string fileName = "results.txt";
string dirName = "FileCollection";
string ext = default;
string output = "";
List<string> dirFiles;
int fileCount = default;
long dirSize = default;
long fSize = default;
Dictionary<string, int> fileType = new Dictionary<string, int>();
Dictionary<string, long> fileSize = new Dictionary<string, long>();
FileInfo fInfo;

// Do nothing if the directory doesn't exist.
if (Directory.Exists(dirName)) {
    // Store a list of file names.
    dirFiles = new List<string>(Directory.EnumerateFiles(dirName));
    fileCount = dirFiles.Count; // Store size of file list.

    foreach (string file in dirFiles) {
        // Capture the file extension and size.
        try {
            fInfo = new FileInfo(file);
            ext = fInfo.Extension;
            fSize = fInfo.Length;
        }
        catch (Exception e) {
            System.Console.WriteLine($"Exception accessing file: {file}\n{e}");
            continue;
        }
        
        // Record the number of files with each extension and their collective size.
        if (fileType.ContainsKey(ext)) {
            fileType[ext] += 1;
            fileSize[ext] += fSize;
        }
        else {
            // Add and initialize the extension if it has not been seen yet.
            fileType.Add(ext, 1);
            fileSize.Add(ext, fSize);
        }

        // Increment total size of the directory.
        dirSize += fSize;
    }

    // Assemble file output.
    output += "~~~~ Results ~~~~";

    // Record file count by extension.
    output += $"\nTotal Files: {fileCount:N0}";
    foreach (string k in fileType.Keys) {
        output += $"\n{k}: {fileType[k]:N0}";
    }
    output+= "\n----";

    // Record file size by extension.
    output += $"\nTotal Size: {dirSize:N0}";
    foreach (string k in fileSize.Keys) {
        output += $"\n{k}: {fileSize[k]:N0}";
    }

    // Output to console and file.
    System.Console.WriteLine(output);
    using (StreamWriter sw = File.CreateText(fileName)) {
        sw.Write(output);
    }
}