using System.Collections.Generic;
using FrameworkDesign;
using NotImplementedException = System.NotImplementedException;

namespace ShootingEditor2D
{
    public interface IGunConfigModel : IModel
    {
        GunConfigItem GetItemByName(string name);
    }

    public class GunConfigModel : AbstractModel, IGunConfigModel
    {
        protected override void OnInit()
        {
        }

        private Dictionary<string, GunConfigItem> mItems = new Dictionary<string, GunConfigItem>()
        {
            {"手枪", new GunConfigItem("手枪", 7, 1, 1, 0.5f, false, 3, "默认枪")},
            {"UMP9", new GunConfigItem("UMP9", 45, 1, 6, 0.34f, true, 2, "无")},
            {"M416", new GunConfigItem("M416", 30, 3, 3, 1f, true, 3, "海绵宝宝特种部队标配军用突击步枪")},
            {"M24", new GunConfigItem("M24", 10, 8, 1f, 2f, true, 4, "有些人走着走着就没了")},
            {"RPG", new GunConfigItem("RPG", 1, 10, 1f, 1.5f, true, 6, "没有什么是一发RPG解决不了的，如果有，就两发")},
            {"M684", new GunConfigItem("M684", 2, 10, 2, 0.5f, true, 1.5f, "没有什么是···，终结者用了都说好")},
        };

        public GunConfigItem GetItemByName(string name)
        {
            return mItems[name];
        }
    }

    public class GunConfigItem
    {
        public string Name { get; set; }
        public int BulletMaxCount { get; set; }
        public float Attack { get; set; }
        public float Frequency { get; set; }
        public float ShootDistance { get; set; }
        public bool NeedBullet { get; set; }
        public float ReloadSeconds { get; set; }
        public string Description { get; set; }

        public GunConfigItem(string name, int bulletMaxCount, float attack, float frequency, float shootDistance,
            bool needBullet, float reloadSeconds, string description)
        {
            Name = name;
            BulletMaxCount = bulletMaxCount;
            Attack = attack;
            Name = name;
            Frequency = frequency;
            ShootDistance = shootDistance;
            NeedBullet = needBullet;
            ReloadSeconds = reloadSeconds;
            Description = description;
        }
    }
}