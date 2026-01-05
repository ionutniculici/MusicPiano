namespace MusicPianoResources;

public static class ImageFiles
{
    public static string? GetImagePath(string fileName)
    {
        string imageFilePath = Path.Combine(AppContext.BaseDirectory, "Images", fileName);
        if (!File.Exists(imageFilePath))
        {
            return null;
        }
        return imageFilePath;
    }
}
