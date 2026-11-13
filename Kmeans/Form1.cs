
using System.Drawing.Imaging;


namespace Kmeans;

public partial class Form1 : Form
{
    double[][] samples;
    KMeans km;
    int totalIterations = 0;

    // chart range
    double xMin = -2, xMax = 2, yMin = -2, yMax = 2;

    Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Orange,
                       Color.Purple, Color.Brown, Color.Teal, Color.Magenta };

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        samples = DataLoader.Load("spiralka.csv");

        cmbDistance.Items.Add("Euclidean");
        cmbDistance.Items.Add("Manhattan");
        cmbDistance.Items.Add("Chebyshev");
        cmbDistance.Items.Add("Minkowski");
        cmbDistance.Items.Add("Only x1");
        cmbDistance.SelectedIndex = 0;

        numClusters.Value = 3;
        numIterations.Value = 4;

        btnRun.Enabled = false;
        Redraw(null);
    }

    // choose the delegate based on the combobox
    private DistanceFunc GetDistance()
    {
        DistanceFunc d = Distances.Euclidian;
        switch (cmbDistance.SelectedIndex)
        {
            case 0: d = Distances.Euclidian; break;
            case 1: d = Distances.Manhattan; break;
            case 2: d = Distances.Czebyszewa; break;
            case 3: d = Distances.Minkowskiego; break;
            case 4: d = Distances.OnlyX1; break;
        }
        return d;
    }

    // runs N more iterations and shows the report + chart


    private void ShowReport(List<Cluster> report)
    {
        txtReport.Text = "After " + totalIterations + " iterations:" + Environment.NewLine;
        foreach (Cluster c in report)
            txtReport.Text += c.ToString() + Environment.NewLine;
    }

    // data coordinates -> pixel coordinates
    private PointF ToPixel(double x, double y, int w, int h)
    {
        float px = (float)((x - xMin) / (xMax - xMin) * w);
        float py = (float)(h - (y - yMin) / (yMax - yMin) * h);
        return new PointF(px, py);
    }

    // report == null -> before the first iteration (gray samples + random centers)
    private void Redraw(List<Cluster> report)
    {
        int w = picChart.Width;
        int h = picChart.Height;
        Bitmap bmp = new Bitmap(w, h);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.White);

        // axes x1 and x2
        g.DrawLine(Pens.Gray, ToPixel(xMin, 0, w, h), ToPixel(xMax, 0, w, h));
        g.DrawLine(Pens.Gray, ToPixel(0, yMin, w, h), ToPixel(0, yMax, w, h));
        Font font = new Font("Arial", 8);
        for (int t = -2; t <= 2; t++)
        {
            if (t == 0) continue;
            PointF px = ToPixel(t, 0, w, h);
            g.DrawString(t.ToString(), font, Brushes.Black, px.X - 5, px.Y + 2);
            PointF py = ToPixel(0, t, w, h);
            g.DrawString(t.ToString(), font, Brushes.Black, py.X + 3, py.Y - 6);
        }
        g.DrawString("x1", font, Brushes.Black, w - 20, h / 2 + 12);
        g.DrawString("x2", font, Brushes.Black, w / 2 + 6, 2);

        if (report == null)
        {
            foreach (double[] p in samples)
            {
                PointF q = ToPixel(p[0], p[1], w, h);
                g.FillRectangle(Brushes.Gray, q.X - 3, q.Y - 3, 6, 6);
            }
            if (km != null)
            {
                foreach (double[] c in km.centers)
                {
                    PointF q = ToPixel(c[0], c[1], w, h);
                    g.FillEllipse(Brushes.Black, q.X - 6, q.Y - 6, 12, 12);
                }
            }
        }
        else
        {
            foreach (Cluster cl in report)
            {
                Color color = colors[(cl.Number - 1) % colors.Length];
                Brush brush = new SolidBrush(color);

                foreach (double[] p in cl.Points)
                {
                    PointF q = ToPixel(p[0], p[1], w, h);
                    g.FillRectangle(brush, q.X - 3, q.Y - 3, 6, 6);
                }

                // legend
                g.FillRectangle(brush, 10, 10 + cl.Number * 16, 10, 10);
                g.DrawString("Cluster " + cl.Number + " (" + cl.Count + ")", font, Brushes.Black, 25, 8 + cl.Number * 16);
            }
            // centers on top
            foreach (Cluster cl in report)
            {
                PointF q = ToPixel(cl.Center[0], cl.Center[1], w, h);
                g.FillEllipse(Brushes.Black, q.X - 6, q.Y - 6, 12, 12);
            }
        }

        g.Dispose();
        picChart.Image = bmp;
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        km = new KMeans(samples, (int)numClusters.Value, GetDistance());
        totalIterations = 0;
        lblIteration.Text = "Iteration: 0";
        txtReport.Clear();
        btnRun.Enabled = true;
        Redraw(null);
    }

    // runs N more iterations and shows the report + chart
    private void btnRun_Click(object sender, EventArgs e)
    {
        int n = (int)numIterations.Value;
        km.Iterations(n);
        totalIterations += n;
        lblIteration.Text = "Iteration: " + totalIterations;

        List<Cluster> report = km.GetReport();
        ShowReport(report);
        Redraw(report);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        picChart.Image.Save("chart_" + totalIterations + ".png", ImageFormat.Png);
        File.WriteAllText("report_" + totalIterations + ".txt", txtReport.Text);
    }
}