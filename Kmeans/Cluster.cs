namespace Kmeans;

public class Cluster
{
    public int Number;
    public double[] Center;
    public int Count;
    public double[] Min = new double[2];
    public double[] Max = new double[2];
    public List<double[]> Points = [];

    public void CalcMinMax()
    {
        for (int i = 0; i < 2; i++)
        {
            Min[i] = double.MaxValue;
            Max[i] = double.MinValue;
            foreach (double[] p in Points)
            {
                if (p[i] < Min[i]) Min[i] = p[i];
                if (p[i] > Max[i]) Max[i] = p[i];
            }
        }
        Count = Points.Count;
    }

    public override string ToString()
    {
        return "Cluster " + Number + ": center=(" + Center[0].ToString("F4") + "; " + Center[1].ToString("F4") + ")"
            + ", samples=" + Count
            + ", x1 [" + Min[0].ToString("F4") + " ; " + Max[0].ToString("F4") + "]"
            + ", x2 [" + Min[1].ToString("F4") + " ; " + Max[1].ToString("F4") + "]";
    }
}