using FrameworkDesign;
using NotImplementedException = System.NotImplementedException;

namespace ShootingEditor2D.System
{
    public interface IStatSystem : ISystem
    {
        BindableProperty<int> KillCount { get; }
    }

    public class StatSystem : AbstractSystem, IStatSystem
    {
        protected override void OnInit()
        {
        }

        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}