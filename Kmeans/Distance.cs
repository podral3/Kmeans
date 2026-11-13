public delegate double Distance(double[] a, double[] b);

public static class Distances
{
    public static readonly double Mink = 3;

    public static double Euclidian(double[] a, double[] b)
    {
        double suma = 0;
        for (int i = 0; i < a.Length; i++)
            suma += (a[i] - b[i]) * (a[i] - b[i]);
        return Math.Sqrt(suma);
    }

    public static double Manhattan(double[] a, double[] b)
    {
        double suma = 0;
        for (int i = 0; i < a.Length; i++)
            suma += Math.Abs(a[i] - b[i]);
        return suma;
    }

    public static double Czebyszewa(double[] a, double[] b)
    {
        double max = 0;
        for (int i = 0; i < a.Length; i++)
            if (Math.Abs(a[i] - b[i]) > max)
                max = Math.Abs(a[i] - b[i]);
        return max;
    }

    public static double Minkowskiego(double[] a, double[] b)
    {
        double suma = 0;
        for (int i = 0; i < a.Length; i++)
            suma += Math.Pow(Math.Abs(a[i] - b[i]), Mink);
        return Math.Pow(suma, 1.0 / Mink);
    }

    public static double OnlyX1(double[] a, double[] b)
    {
        return Math.Abs(a[0] - b[0]);
    }
}