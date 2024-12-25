using System;
using Exiled.API.Features;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace SCP_999
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Unmake : ICommand
    {
        public string[] Aliases { get; set; } = { "uns999" };

        public string Description => "Spawn a SCP-999";

        string ICommand.Command => "unscp999";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player;
            if (!sender.CheckPermission("scp999.unspawn"))
            {
                response = "You don't have enough permissions.";
                return false;
            }
            else if (arguments.Count != 1 || !int.TryParse(arguments.At(0), out int id))
            {
                response = "Incorrect arguments.";
                return false;
            }
            else if ((player = Player.Get(id)) == null)
            {
                response = $"Player with id {id} can't be found.";
                return false;
            }
            else if (!EventHandler.IsScp999(player))
            {
                response = "Player is not SCP-999.";
                return false;
            }
            else
            {
                EventHandler.UnmakeSCP(player);
                response = $"Ok, {player.Nickname} you is not SCP-999 now.";
                return true;
            }
        }
    }
}
