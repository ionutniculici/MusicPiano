namespace MusicPianoResources
{
    public static class AudioFiles
    {
        public static Stream? GetSoundStream(string fileName)
        {
            string soundFilePath = Path.Combine(AppContext.BaseDirectory, "Sounds", fileName);
            if (!File.Exists(soundFilePath))
            {
                return null;
            }
            return new FileStream(soundFilePath, FileMode.Open, FileAccess.Read);
        }
    }
}
