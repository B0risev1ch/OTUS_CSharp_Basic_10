
using System.IO;

var filesNum = 10;

var dirNames = new List<string>()
{
    Path.Combine("C:", "Otus", "TestDir1"),
    Path.Combine("C:", "Otus", "TestDir2")
};

var dirInfoes = dirNames.Select(a => new DirectoryInfo(a));

foreach (var directory in dirInfoes)
{
    if (!directory.Exists)
        directory.Create();

    //Наполняем файлы:
    for (int i = 0; i < filesNum; i++)
    {
        var fileName = $"File{i + 1}";
        var filePath = Path.Combine(directory.FullName, fileName);
        try
        {
            using (var streamW = File.CreateText(filePath))
            {
                streamW.WriteLine($"{fileName}, {DateTime.Now}");                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка при записи в файл: ", e);
        }
    }

}

foreach (var directory in dirInfoes)
{
    //Читаем:
    if (directory.Exists)
    {
        var files = Directory.EnumerateFiles(directory.FullName);
        foreach (var filePath in files)
        {
            try
            {
                using (var streamR = File.OpenText(filePath))
                {
                    Console.WriteLine(filePath + " : " + streamR.ReadToEnd());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка при чтении из файла: ", e);
            }
            
        }
    }
}