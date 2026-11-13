using System.Globalization;
namespace Kmeans;

public static class DataLoader
{
    public static double[][] Load(string path)
    {
        string[] lines = File.ReadAllLines(path);
        List<double[]> samples = [];

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            double x1 = double.Parse(parts[0], CultureInfo.InvariantCulture);
            double x2 = double.Parse(parts[1], CultureInfo.InvariantCulture);
            samples.Add([x1, x2]);
        }
        return [.. samples];
    }
}
