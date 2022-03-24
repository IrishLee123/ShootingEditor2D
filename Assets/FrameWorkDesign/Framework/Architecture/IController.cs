namespace FrameworkDesign
{
    public interface IController : IBelongToArchitecture,
        ICanSendCommand, ICanSendQuery, ICanGetSystem, ICanGetModel, ICanRegisterEvent
    {
    }
}