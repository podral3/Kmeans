
namespace PSO;

public delegate double Function(Point point);

public class Entity
{
    public Point Position { get; private set; }
    public Point BestPosition { get; set; }

    public double XVel { get; private set; } = 0;
    public double YVel { get; private set; } = 0;

    private readonly Function _functionToOptimize;

    public double FunctionValue = 0;

    public Entity(Function funcToOptimize)
    {
        _functionToOptimize = funcToOptimize;

        Position = new Point(
            Random.Shared.NextDouble() * 100,
            Random.Shared.NextDouble() * 100);

        BestPosition = Position;
    }

    public double CalculateFunction()
    {
        FunctionValue = _functionToOptimize(Position);
        return FunctionValue;
    }

    public double CalculateFunction(Point point) =>
        _functionToOptimize(point);

    public void UpdateVelocityAndPosition(
        Point globalBest,
        double ri,
        double rg,
        double rl)
    {
        double rndGlobal = Random.Shared.NextDouble();
        double rndLocal = Random.Shared.NextDouble();

        XVel = XVel * ri
            + (globalBest.X - Position.X) * rg * rndGlobal
            + (BestPosition.X - Position.X) * rl * rndLocal;

        YVel = YVel * ri
            + (globalBest.Y - Position.Y) * rg * rndGlobal
            + (BestPosition.Y - Position.Y) * rl * rndLocal;

        Position = new Point(
            Math.Clamp(Position.X + XVel, 0, 100),
            Math.Clamp(Position.Y + YVel, 0, 100));
    }
}
