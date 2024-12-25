using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_999
{
    public class Config : IConfig
    {
        [Description("Вкл/Выкл плагина.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Режи отладки для плагина")]
        public bool Debug { get; set; } = true;
        [Description("Размер по координате X")]
        public float ScaleX { get; set; } = 0.35f;
        [Description("Размер по координате Y")]
        public float ScaleY { get; set; } = 0.35f;
        [Description("Размер по координате Z")]
        public float ScaleZ { get; set; } = 0.35f;
        [Description("Максимум здоровья у SCP-999.")]
        public int MaxHealPercent { get; set; } = 10000;
    }
}
