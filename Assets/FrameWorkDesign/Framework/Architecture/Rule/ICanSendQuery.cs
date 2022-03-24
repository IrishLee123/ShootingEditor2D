using FrameWorkDesign;

namespace FrameworkDesign
{
    public interface ICanSendQuery : IBelongToArchitecture
    {
    }

    public static class CanSendQueryExtension
    {
        public static T SendQuery<T>(this ICanSendCommand self, IQuery<T> query)
        {
            return self.GetArchitecture().SendQuery<T>(query);
        }
    }
}