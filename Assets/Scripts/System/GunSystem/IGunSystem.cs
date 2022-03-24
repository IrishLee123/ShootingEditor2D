using System.Collections.Generic;
using System.Linq;
using FrameworkDesign;

namespace ShootingEditor2D
{
    public interface IGunSystem : ISystem
    {
        GunInfo CurrentGun { get; }

        void PickGun(string name, int bulletCountInGun, int bulletCountOutGun);
    }

    public class GunSystem : AbstractSystem, IGunSystem
    {
        private Queue<GunInfo> mGunInfos = new Queue<GunInfo>();

        protected override void OnInit()
        {
            CurrentGun = new GunInfo()
            {
                Name = new BindableProperty<string>()
                {
                    Value = "手枪",
                },
                BulletCountInGun = new BindableProperty<int>()
                {
                    Value = 3,
                },
                BulletCountOutGun = new BindableProperty<int>()
                {
                    Value = 3,
                },
                State = new BindableProperty<GunState>()
                {
                    Value = GunState.Idle,
                },
            };
        }

        public GunInfo CurrentGun { get; set; }

        public void PickGun(string name, int bulletCountInGun, int bulletCountOutGun)
        {
            if (CurrentGun.Name.Value == name)
            {
                // 已经拥有，更新子弹数量
                CurrentGun.BulletCountOutGun.Value += bulletCountInGun;
                CurrentGun.BulletCountOutGun.Value += bulletCountOutGun;
                return;
            }

            if (mGunInfos.Any(info => info.Name.Value == name))
            {
                var gunInfo = mGunInfos.First(info => info.Name.Value == name);
                gunInfo.BulletCountInGun.Value += bulletCountInGun;
                gunInfo.BulletCountOutGun.Value += bulletCountOutGun;
                return;
            }

            // 未拥有，捡起武器

            // 缓存当前武器
            var currentGunInfo = new GunInfo()
            {
                Name = new BindableProperty<string>()
                {
                    Value = CurrentGun.Name.Value
                },
                BulletCountInGun = new BindableProperty<int>()
                {
                    Value = CurrentGun.BulletCountInGun.Value
                },
                BulletCountOutGun = new BindableProperty<int>()
                {
                    Value = CurrentGun.BulletCountOutGun.Value
                },
                State = new BindableProperty<GunState>()
                {
                    Value = CurrentGun.State.Value
                }
            };
            mGunInfos.Enqueue(currentGunInfo);

            // 换上新武器
            CurrentGun.Name.Value = name;
            CurrentGun.BulletCountInGun.Value = bulletCountInGun;
            CurrentGun.BulletCountOutGun.Value = bulletCountOutGun;
            CurrentGun.State.Value = GunState.Idle;
            
            this.SendEvent(new OnCurrentGunChanged()
            {
                Name = CurrentGun.Name.Value
            });
        }

        public struct OnCurrentGunChanged
        {
            public string Name { get; set; }
        }
    }
}