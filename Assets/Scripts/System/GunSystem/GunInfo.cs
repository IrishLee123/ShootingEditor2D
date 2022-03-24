using System;
using FrameworkDesign;

namespace ShootingEditor2D
{
    public enum GunState
    {
        Idle,
        Shooting,
        Reload,
        EmptyBullet,
        CoolDown
    }

    public struct GunInfo
    {
        public BindableProperty<string> Name;

        public BindableProperty<int> BulletCountInGun;

        public BindableProperty<int> BulletCountOutGun;

        public BindableProperty<GunState> State;
    }
}