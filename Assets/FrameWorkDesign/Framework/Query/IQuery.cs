using FrameworkDesign;

namespace FrameWorkDesign
{
    public interface IQuery<TResult> : IBelongToArchitecture, ICanSetArchitecture,
        ICanGetModel, ICanGetSystem, ICanGetUtility
    {
        TResult Do();
    }

    public abstract class AbstractQuery<T> : IQuery<T>
    {
        private IArchitecture mArchitecture;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        T IQuery<T>.Do()
        {
            return OnDo();
        }

        protected abstract T OnDo();
    }
}