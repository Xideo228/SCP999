using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using MEC;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SCP_999
{
    public static class EventHandler
    {
        private static List<Scp999> _scps;

        static EventHandler()
        {
            _scps = new List<Scp999>();
        }

        public static void end()
        {
            List<Scp999> scps = new List<Scp999>(_scps);
            foreach (var scp in scps)
            {
                Player player = Player.Get(scp.UserId);
                if (player != null) UnmakeSCP(player);
            }
        }

        public static bool IsScp999(Player player) => _scps.Any(scp => scp.UserId == player.UserId);
        public static void MakeScp999(Player player)
        {
            if (IsScp999(player))
                throw new InvalidOperationException("Player is already SCP-999");
            Timing.RunCoroutine(MakeSCP999Start(player));
        }
        public static void UnmakeSCP(Player player)
        {
            if (!IsScp999(player)) throw new InvalidOperationException("Player is not a SCP-999");
            player.Scale = Vector3.one;
            Scp999 scp = _scps.First(scp999 => scp999.UserId == player.UserId);
            player.CustomInfo = scp.PreviousInfo;
            _scps.Remove(scp);
        }

        public static void PickingUpItem(PickingUpItemEventArgs ev)
        {
            if (IsScp999(ev.Player)) ev.IsAllowed = false;
        }

        private static IEnumerator<float> MakeSCP999Start(Player player)
        {
            Vector3? CurrentPosition = null;
            if (player.IsAlive) CurrentPosition = player.GameObject.transform.position;
            player.Role.Set(PlayerRoles.RoleTypeId.Tutorial);
            player.Health = Plugin.plugin.Config.MaxHealPercent;
            yield return Timing.WaitForSeconds(0.4f);
            player.Scale = new Vector3(Plugin.plugin.Config.ScaleX, Plugin.plugin.Config.ScaleY, Plugin.plugin.Config.ScaleZ);
            yield return Timing.WaitForSeconds(0.4f);
            if (CurrentPosition.HasValue) player.Position = CurrentPosition.Value;
            _scps.Add(new Scp999(player.UserId, player.RankName));
            player.CustomInfo = Plugin.plugin.Translation.Info;
            player.AddItem(ItemType.KeycardMTFOperative);
        } 
    }
}
