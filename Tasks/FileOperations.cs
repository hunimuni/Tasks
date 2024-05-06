
class FileOperations
{
    public static async Task<int> CountSpacesInFilesAsync(string[] filePaths)
    {
        Task<int>[] tasks = new Task<int>[filePaths.Length];

        for (int i = 0; i < filePaths.Length; i++)
        {
            tasks[i] = CountSpacesAsync(filePaths[i]);
        }

        int[] spaceCounts = await Task.WhenAll(tasks);
        return spaceCounts.Sum();
    }

    public static async Task<int> CountSpacesInFolderAsync(string folderPath)
    {
        string[] filePaths = Directory.GetFiles(folderPath);

        Task<int>[] tasks = new Task<int>[filePaths.Length];

        for (int i = 0; i < filePaths.Length; i++)
        {
            tasks[i] = CountSpacesAsync(filePaths[i]);
        }

        int[] spaceCounts = await Task.WhenAll(tasks);
        return spaceCounts.Sum();
    }

    private static async Task<int> CountSpacesAsync(string filePath)
    {
        string content = await File.ReadAllTextAsync(filePath);
        return content.Count(c => c == ' ');
    }
}