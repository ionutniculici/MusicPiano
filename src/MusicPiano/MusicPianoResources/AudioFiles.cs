namespace MusicPianoResources
{
    public static class AudioFiles
    {
        public static string GetPath(string fileName) =>
            Path.Combine(AppContext.BaseDirectory, "Sounds", fileName);
    }
}
