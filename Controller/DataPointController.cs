using System.IO;

namespace BattleFroggy.Controller
{
    internal static class DataPointController
    {
        private static readonly string _path = "save.txt";

        public static void Save(int points)
        {
            File.WriteAllText(_path, points.ToString());
        }

        public static int Load()
        {
            if (!File.Exists(_path)) return 0;
            int.TryParse(File.ReadAllText(_path), out int points);
            return points;
        }
    }
}