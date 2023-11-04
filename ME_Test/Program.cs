using MetadataExtractor;

foreach (var path in args)
{
    var directories = ImageMetadataReader.ReadMetadata(path);
    foreach (var directory in directories)
    {
        foreach (var tag in directory.Tags)
        {
            Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");
        }
    }
    Console.WriteLine();

    var photoData = new ME_Test.PhotoData(path);
    Console.Write("撮影日時  : ");
    if (ME_Test.PhotoData.HasValue(photoData.Date))
    {
        Console.WriteLine(photoData.Date.ToString("yyyy/MM/dd HH:mm:ss"));
    }
    else
    {
        Console.WriteLine("No data");
    }

    Console.ReadLine();
}