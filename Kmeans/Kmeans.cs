namespace Kmeans;

public class KMeans
{
    private readonly double[][] _samples;
    private int _clusters;
    private readonly DistanceFunc _distance;    
    public double[][] centers;
    public int[] u;          

    public KMeans(double[][] samples, int clusters, DistanceFunc distance)
    {
        this._samples = samples;
        this._clusters = clusters;
        this._distance = distance;
        u = new int[samples.Length];
        centers = new double[clusters][];

        Random r = new();
        List<int> chosen = [];
        //randomowo wybierz srodki
        while (chosen.Count < clusters)
        {
            int k = r.Next(samples.Length);
            if (!chosen.Contains(k))
                chosen.Add(k);
        }
        for (int j = 0; j < clusters; j++)
            centers[j] = [samples[chosen[j]][0], samples[chosen[j]][1]];
    }

    public void Iteration()
    {
        for (int s = 0; s < _samples.Length; s++)
        {
            double smallest = double.MaxValue;
            for (int j = 0; j < _clusters; j++)
            {
                double d = _distance(_samples[s], centers[j]);
                if (d < smallest)
                {
                    smallest = d;
                    u[s] = j;
                }
            }
        }

        for (int j = 0; j < _clusters; j++)
        {
            double sum1 = 0, sum2 = 0;
            int count = 0;
            for (int s = 0; s < _samples.Length; s++)
            {
                if (u[s] == j)
                {
                    sum1 += _samples[s][0];
                    sum2 += _samples[s][1];
                    count++;
                }
            }
            if (count == 0) continue;
            centers[j][0] = sum1 / count;
            centers[j][1] = sum2 / count;
        }
    }

    public void Iterations(int count)
    {
        for (int i = 0; i < count; i++)
            Iteration();
    }

    public List<Cluster> GetReport()
    {
        List<Cluster> list = [];
        for (int j = 0; j < _clusters; j++)
        {
            Cluster c = new()
            {
                Number = j + 1,
                Center = centers[j]
            };
            for (int s = 0; s < _samples.Length; s++)
                if (u[s] == j)
                    c.Points.Add(_samples[s]);
            c.CalcMinMax();
            list.Add(c);
        }
        return list;
    }
}
