using FrameworkDesign;
using ShootingEditor2D.Model;
using ShootingEditor2D.System;

namespace ShootingEditor2D
{
    public class ShootingEditorApp : Architecture<ShootingEditorApp>
    {
        protected override void IocInjection()
        {
            // register models
            this.RegisterModel<IGunConfigModel>(new GunConfigModel());
            this.RegisterModel<IPlayerModel>(new PlayerModel());

            // register systems
            this.RegisterSystem<IStatSystem>(new StatSystem());
            this.RegisterSystem<IGunSystem>(new GunSystem());
            this.RegisterSystem<ITimeSystem>(new TimeSystem());

            // register utilities
        }
    }
}