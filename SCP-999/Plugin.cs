using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PluginAPI.Events;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP_999
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "SCP-999";
        public override string Prefix => Name;
        public override string Author => "Hid Man";
        public override Version Version => base.Version;

        public static Plugin plugin { get; private set; }

        public override void OnEnabled()
        {
            plugin = this;

            RegistredEvent();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            plugin = null;

            UnRegistredEvent();

            base.OnDisabled();
        }

        private void RegistredEvent()
        {
            Server.RestartingRound += OnRestartingRound;
            Player.ChangingRole += OnPlayerChangingRole;
            Player.PickingUpItem += EventHandler.PickingUpItem;
        }

        private void UnRegistredEvent()
        {
            Server.RestartingRound -= OnRestartingRound;
            Player.ChangingRole -= OnPlayerChangingRole;
            Player.PickingUpItem -= EventHandler.PickingUpItem;
        }

        private void OnPlayerChangingRole(ChangingRoleEventArgs ev)
        {
            if (EventHandler.IsScp999(ev.Player)) EventHandler.UnmakeSCP(ev.Player);
        }

        private void OnRestartingRound()
        {
            EventHandler.end();
        }
    }
}
