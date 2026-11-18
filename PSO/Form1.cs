
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;

namespace PSO;

public partial class Form1 : Form
{
    private PSO? _pso;

    private readonly List<string[]> _history = [];

    private int _targetIterations;
    private Bitmap? _heatmap;
    private readonly List<(double Level, PointF A, PointF B)> _contours = [];
    public Form1()
    {
        InitializeComponent();

        typeof(Panel).GetProperty("DoubleBuffered",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!
        .SetValue(panelGraph, true);
        timer.Tick += TimerPSO_Tick;

        panelGraph.Paint += PanelGraph_Paint;

        btnStart.Click += BtnStart_Click;
        btnStop.Click += BtnStop_Click;
        btnReset.Click += BtnReset_Click;
        btnExport.Click += BtnExport_Click;

        btnStop.Enabled = false;
        btnExport.Enabled = false;

        _heatmap = new Bitmap(200, 200);

        for (int x = 0; x < 200; x++)
            for (int y = 0; y < 200; y++)
            {
                double value = PSO.FunctionToOptimize(new Point(x / 2.0, 100 - y / 2.0));
                double normalized = Math.Clamp((value + 2.4) / 4.8, 0, 1);
                _heatmap.SetPixel(x, y, Color.FromArgb((int)(255 * normalized), 60, (int)(255 * (1 - normalized))));
            }

        BuildContours();
    }

    private void BtnStart_Click(object? sender, EventArgs e)
    {
        if(_pso == null)
        {
            _targetIterations = (int)numIterations.Value;

            _pso = new PSO(
                (int)numEntities.Value,
                (double)numRI.Value,
                (double)numRG.Value,
                (double)numRL.Value,
                _targetIterations,
                PSO.FunctionToOptimize
            );

            _history.Clear();
            SaveHistory();
        }

        timer.Start();

        btnStart.Enabled = false;
        btnStop.Enabled = true;
        btnExport.Enabled = false;

        panelGraph.Invalidate();
    }

    private void TimerPSO_Tick(object? sender, EventArgs e)
    {
        if (_pso == null)
            return;

        _pso.Step();

        SaveHistory();

        lblIterations.Text =
            $"Iteracja: {_pso.CurrentIteration}/{_targetIterations}";

        lblBestValue.Text =
            $"Najlepszy wynik: {_pso.GlobalBestValue:F6}";

        lblBestPosition.Text =
            $"Najlepsza pozycja: " +
            $"({_pso.GlobalBestPosition.X:F2}, " +
            $"{_pso.GlobalBestPosition.Y:F2})";

        panelGraph.Invalidate();

        if (_pso.CurrentIteration >= _targetIterations)
        {
            timer.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnExport.Enabled = true;
        }
    }

    private void BtnStop_Click(object? sender, EventArgs e)
    {
        timer.Stop();

        btnStart.Enabled = true;
        btnStop.Enabled = false;
        btnExport.Enabled = true;
    }

    private void BtnReset_Click(object? sender, EventArgs e)
    {
        timer.Stop();

        _pso = null;
        _history.Clear();

        lblIterations.Text = "Iteracja: 0";
        lblBestValue.Text = "Najlepszy wynik: -";
        lblBestPosition.Text = "Najlepsza pozycja: -";

        btnStart.Enabled = true;
        btnStop.Enabled = false;
        btnExport.Enabled = false;

        panelGraph.Invalidate();
    }

    private void SaveHistory()
    {
        if (_pso == null)
            return;

        _history.Add(
        [
            _pso.CurrentIteration.ToString(),
            _pso.GlobalBestPosition.X.ToString(CultureInfo.InvariantCulture),
            _pso.GlobalBestPosition.Y.ToString(CultureInfo.InvariantCulture),
            _pso.GlobalBestValue.ToString(CultureInfo.InvariantCulture)
        ]);
    }

    private void BtnExport_Click(object? sender, EventArgs e)
    {
        if (_history.Count == 0)
            return;

        using SaveFileDialog dialog = new()
        {
            Filter = "CSV files (*.csv)|*.csv",
            FileName = "PSO_results.csv"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        StringBuilder csv = new();

        csv.AppendLine(
            "Iteration,BestX,BestY,BestValue");

        foreach (var row in _history)
        {
            csv.AppendLine(string.Join(",", row));
        }

        File.WriteAllText(
            dialog.FileName,
            csv.ToString(),
            Encoding.UTF8
        );

        MessageBox.Show(
            "Wyniki zostały wyeksportowane!",
            "Export CSV",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }

    private void PanelGraph_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        const float margin = 12f;
        var plot = new RectangleF(
            margin, margin,
            panelGraph.ClientSize.Width - 2 * margin,
            panelGraph.ClientSize.Height - 2 * margin);

        if (plot.Width <= 0 || plot.Height <= 0)
            return;

        PointF Map(double x, double y) => new(
            plot.Left + (float)(x / 100 * plot.Width),
            plot.Bottom - (float)(y / 100 * plot.Height));

        g.SmoothingMode = SmoothingMode.AntiAlias;

        if (_heatmap != null)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.DrawImage(_heatmap, plot);
        }
        else
        {
            g.FillRectangle(Brushes.White, plot);
        }

        // Contour lines
        using var pen = new Pen(Color.FromArgb(140, 255, 255, 255), 1f);
        foreach (var (_, a, b) in _contours)
        {
            PointF p1 = Map(a.X, a.Y);
            PointF p2 = Map(b.X, b.Y);
            g.DrawLine(pen, p1, p2);
        }

        g.DrawRectangle(Pens.Black, plot.X, plot.Y, plot.Width, plot.Height);

        if (_pso == null)
            return;

        foreach (var entity in _pso.Entities)
        {
            PointF p = Map(entity.Position.X, entity.Position.Y);
            g.FillEllipse(Brushes.White, p.X - 4, p.Y - 4, 8, 8);
            g.DrawEllipse(Pens.Black, p.X - 4, p.Y - 4, 8, 8);
        }

        PointF best = Map(_pso.GlobalBestPosition.X, _pso.GlobalBestPosition.Y);
        g.FillEllipse(Brushes.Lime, best.X - 7, best.Y - 7, 14, 14);
        g.DrawEllipse(Pens.Black, best.X - 7, best.Y - 7, 14, 14);
    }

    private void BuildContours()
    {
        const int n = 100;               // grid resolution
        const double step = 100.0 / n;
        double[,] v = new double[n + 1, n + 1];

        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= n; j++)
                v[i, j] = PSO.FunctionToOptimize(new Point(i * step, j * step));

        // Contour levels: change the step (0.4) for more/fewer lines
        for (double level = -2.0; level <= 2.0; level += 0.4)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double bl = v[i, j], br = v[i + 1, j];
                    double tr = v[i + 1, j + 1], tl = v[i, j + 1];
                    double x0 = i * step, x1 = (i + 1) * step;
                    double y0 = j * step, y1 = (j + 1) * step;

                    var pts = new List<PointF>(4);

                    // bottom, right, top, left edges
                    if ((bl < level) != (br < level))
                        pts.Add(new PointF((float)(x0 + step * (level - bl) / (br - bl)), (float)y0));
                    if ((br < level) != (tr < level))
                        pts.Add(new PointF((float)x1, (float)(y0 + step * (level - br) / (tr - br))));
                    if ((tl < level) != (tr < level))
                        pts.Add(new PointF((float)(x0 + step * (level - tl) / (tr - tl)), (float)y1));
                    if ((bl < level) != (tl < level))
                        pts.Add(new PointF((float)x0, (float)(y0 + step * (level - bl) / (tl - bl))));

                    if (pts.Count == 2)
                        _contours.Add((level, pts[0], pts[1]));
                    else if (pts.Count == 4)
                    {
                        _contours.Add((level, pts[0], pts[3]));
                        _contours.Add((level, pts[1], pts[2]));
                    }
                }
            }
        }
    }
}
