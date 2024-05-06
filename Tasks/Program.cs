using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        // Прочитать 3 файла параллельно и вычислить количество пробелов в них 
        string[] filePaths = { "../../../Directory/file1.txt", "../../../Directory/file2.txt", "../../../Directory/file3.txt" };

        int totalSpaces = await FileOperations.CountSpacesInFilesAsync(filePaths);
        Console.WriteLine($"Всего пробелов в файлах: {totalSpaces}");


        // Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них
        string folderPath = "../../../Directory";
        
        totalSpaces = await FileOperations.CountSpacesInFolderAsync(folderPath);
        Console.WriteLine($"Всего пробелов в файлах в директории: {totalSpaces}");


        // Замерьте время выполнения кода (класс Stopwatch)
        Stopwatch stopwatch = Stopwatch.StartNew();
        
        totalSpaces = await FileOperations.CountSpacesInFolderAsync(folderPath);
        Console.WriteLine($"Всего пробелов в файлах в директории на время: {totalSpaces}");

        stopwatch.Stop();
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} ms");
    }
}