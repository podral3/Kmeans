
namespace PSO;
public class PSO
{
    public int EntityCount { get; }
    public double RI { get; }
    public double RG { get; }
    public double RL { get; }
    public int Iterations { get; }

    private readonly Function _funcToOptimize;

    private readonly List<Entity> _entities = [];
    public IReadOnlyList<Entity> Entities => _entities;

    public int CurrentIteration { get; private set; } = 0;
    public Entity BestEntity { get; private set; }

    public Point GlobalBestPosition { get; private set; }
    public double GlobalBestValue { get; private set; } = double.NegativeInfinity;

    public PSO(int entityCount, double rI, double rG, double rL, int iterations, Function funcToOptimize)
    {
        EntityCount = entityCount;
        RI = rI;
        RG = rG;
        RL = rL;
        Iterations = iterations;
        _funcToOptimize = funcToOptimize;

        for (int i = 0; i < entityCount; i++)
        {
            var entity = new Entity(funcToOptimize);
            entity.CalculateFunction();
            _entities.Add(entity);
        }

        BestEntity = _entities
            .MaxBy(e => e.CalculateFunction())!;

        GlobalBestPosition = BestEntity.Position;
        GlobalBestValue = BestEntity.CalculateFunction();
    }


    public void Run()
    {
        for (int i = 0; i < Iterations; i++)
        {
            foreach (var entity in _entities)
            {
                double currentValue = entity.CalculateFunction();

                if (currentValue > entity.CalculateFunction(entity.BestPosition))
                {
                    entity.BestPosition = entity.Position;
                }

                double localBestValue =
                    entity.CalculateFunction(entity.BestPosition);

                if (localBestValue > GlobalBestValue)
                {
                    GlobalBestValue = localBestValue;
                    GlobalBestPosition = entity.BestPosition;
                    BestEntity = entity;
                }
            }

            foreach (var entity in _entities)
            {
                entity.UpdateVelocityAndPosition(
                    GlobalBestPosition, RI, RG, RL);
            }
        }
    }

    public void Step()
    {
        if (CurrentIteration >= Iterations)
            return;

        foreach (var entity in _entities)
        {
            double currentValue = entity.CalculateFunction();

            if (currentValue > entity.CalculateFunction(entity.BestPosition))
                entity.BestPosition = entity.Position;

            double localBestValue =
                entity.CalculateFunction(entity.BestPosition);

            if (localBestValue > GlobalBestValue)
            {
                GlobalBestValue = localBestValue;
                GlobalBestPosition = entity.BestPosition;
                BestEntity = entity;
            }
        }

        foreach (var entity in _entities)
        {
            entity.UpdateVelocityAndPosition(
                GlobalBestPosition, RI, RG, RL);
        }

        CurrentIteration++;
    }

    public static double FunctionToOptimize(Point point) =>
            Math.Sin(point.X * 0.05) + Math.Sin(point.Y * 0.05) + 0.4 * Math.Sin(point.X * 0.15) * Math.Sin(point.Y * 0.15);
    }
