namespace MusicPianoLogic;

public static class Utils
{
    public static string SolutionDir 
    {
        get
        {
            string pathDir = Environment.CurrentDirectory;
            for (int i = 0; i < 4; i++)
            {
                DirectoryInfo? parent = Directory.GetParent(pathDir);
                if (parent != null)
                {
                    pathDir = parent.FullName;
                }
            }
            return pathDir;
        }
    }
}
