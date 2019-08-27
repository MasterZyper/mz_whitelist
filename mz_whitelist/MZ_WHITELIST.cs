/*
MZ-Whitelist, managed the connections to the Server
Copyright (C) 27.08.2019 MasterZyper 🐦
Contact: masterzyper@reloaded-server.de

You like to get a FiveM-Server? 
Visit ZapHosting*: https://zap-hosting.com/a/17444fc14f5749d607b4ca949eaf305ed50c0837

Support us on Patreon: https://www.patreon.com/gtafivemorg

For help with this Script visit: https://gta-fivem.org/

This program is free software; you can redistribute it and/or modify it under the terms of the 
GNU General Public License as published by the Free Software Foundation; either version 3 of 
the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.
You should have received a copy of the GNU General Public License along with this program; 
if not, see <http://www.gnu.org/licenses/>.

*Affiliate-Link: Euch entstehen keine Kosten oder Nachteile. Kauf über diesen Link erwirtschaftet eine kleine prozentuale Provision für mich.

*/

using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CitizenFX.Core.Native.API;

namespace mz_whitelist
{    
    public class MZ_WHITELIST_CLIENT : BaseScript
    {
        //Cfg Variables
        bool CFG_Steam_Check = false;
        bool CFG_License_Check = false;
        bool CFG_Discord_Check = false;
        bool CFG_FiveM_Acc_Check = false;
        //Language
        string LG_Steam_Required = "[Missing Text]";
        string LG_License_Required = "[Missing Text]";
        string LG_Discord_Required = "[Missing Text]";
        string LG_FiveM_Acc_Required = "[Missing Text]";
        string LG_Steam_Not_Permitted = "[Missing Text]";
        string LG_License_Not_Permitted = "[Missing Text]";
        string LG_Discord_Not_Permitted = "[Missing Text]";
        string LG_FiveM_Acc_Not_Permitted = "[Missing Text]";
        string LG_Other_Reasons = "[Missing Text]";

        public MZ_WHITELIST_CLIENT()
        {
            //Load CFG
            CFG_Steam_Check = ReadInputAsBool("cfg_steam_check");
            CFG_License_Check = ReadInputAsBool("cfg_license_check");
            CFG_Discord_Check = ReadInputAsBool("cfg_discord_check");
            CFG_FiveM_Acc_Check = ReadInputAsBool("cfg_fivem_acc_check");
            //Load Language
            LG_Steam_Required = ReadInputAsString("lg_steam_required");
            LG_License_Required = ReadInputAsString("lg_license_required");
            LG_Discord_Required = ReadInputAsString("lg_discord_required");
            LG_FiveM_Acc_Required = ReadInputAsString("lg_fivem_acc_required");

            LG_Steam_Not_Permitted = ReadInputAsString("lg_steam_not_permitted");
            LG_License_Not_Permitted = ReadInputAsString("lg_license_not_permitted");
            LG_Discord_Not_Permitted = ReadInputAsString("lg_discord_not_permitted");
            LG_FiveM_Acc_Not_Permitted = ReadInputAsString("lg_fivem_acc_not_permitted");

            LG_Other_Reasons = ReadInputAsString("lg_other_reasons");

            //Bind EventHandlers
            EventHandlers.Add("playerConnecting", new Action<Player, string, CallbackDelegate>(OnPlayerConnecting));
        }
        private bool ReadInputAsBool(string data_field)
        {
            return Convert.ToBoolean(Convert.ToInt32(GetResourceMetadata(GetCurrentResourceName(), data_field, 0)));
        }
        private string ReadInputAsString(string data_field)
        {
            return GetResourceMetadata(GetCurrentResourceName(), data_field, 0);
        }
        private List<string> ReadInputAsList(string data_field)
        {
            List<string> result_list = new List<string>();
            int elem_count = GetNumResourceMetadata(GetCurrentResourceName(), data_field);
            for (int i = 0; i < elem_count; i++)
            {
                result_list.Add(GetResourceMetadata(GetCurrentResourceName(), data_field, i));
            }
            return result_list;
        }
        private string CheckPlayerIsPermitForServer(Player player)
        {
            int needed_security_level = 0;
            int security_level = 0;
            if (CFG_Steam_Check)
            {
                needed_security_level++;
                string steam_id = TryToGetPlayerIndentifier(player, "steam:");
                if (steam_id != null)
                {
                    bool right_steam_id = false;
                    foreach (string steamid in ReadInputAsList("steam"))
                    {
                        if (steamid.Equals(steam_id))
                        {
                            right_steam_id = true;
                            break;
                        }
                    }
                    if (!right_steam_id)
                    {
                        return "steam_not_permitted";
                    }
                    else
                    {
                        security_level++;
                    }
                }
                else
                {
                    return "missing_steam";
                }
            }
            if (CFG_License_Check)
            {
                needed_security_level++;
                string license = TryToGetPlayerIndentifier(player, "license:");
                if (license != null)
                {
                    bool right_license_id = false;
                    foreach (string license_ in ReadInputAsList("license"))
                    {
                        if (license_.Equals(license))
                        {
                            right_license_id = true;
                            break;
                        }
                    }
                    if (!right_license_id)
                    {
                        return "license_not_permitted";
                    }
                    else
                    {
                        security_level++;
                    }
                }
                else
                {
                    return "missing_license";
                }
            }
            if (CFG_Discord_Check)
            {
                needed_security_level++;
                string discord = TryToGetPlayerIndentifier(player, "discord:");
                if (discord != null)
                {
                    bool right_discord_id = false;
                    foreach (string discord_ in ReadInputAsList("discord"))
                    {
                        if (discord_.Equals(discord))
                        {
                            right_discord_id = true;
                            break;
                        }
                    }
                    if (!right_discord_id)
                    {
                        return "discord_not_permitted";
                    }
                    else
                    {
                        security_level++;
                    }
                }
                else
                {
                    return "missing_discord";
                }
            }
            if (CFG_FiveM_Acc_Check)
            {
                needed_security_level++;
                string fivem = TryToGetPlayerIndentifier(player, "fivem:");
                if (fivem != null)
                {
                    bool right_fivem_id = false;
                    foreach (string fivem_ in ReadInputAsList("fivem"))
                    {
                        if (fivem_.Equals(fivem))
                        {
                            right_fivem_id = true;
                            break;
                        }
                    }
                    if (!right_fivem_id)
                    {
                        return "fivem_not_permitted";
                    }
                    else
                    {
                        security_level++;
                    }
                }
                else
                {
                    return "missing_fivem_acc";
                }
            }
            if (needed_security_level == security_level)
                return "success";
            else
                return "error_fatal";
        }

        private string TryToGetPlayerIndentifier(Player player, string indentifier)
        {
            string current = null;
            for (int i = 0; i < GetNumPlayerIdentifiers(player.Handle); i++)
            {
                current = GetPlayerIdentifier(player.Handle, i);
                if (current.StartsWith(indentifier))
                {
                    return current;
                }
            }
            return null;
        }

        private void OnPlayerConnecting([FromSource] Player player, string playerName, CallbackDelegate kickCallback)
        {
            string indentfiers = "";
            for (int i = 0; i < GetNumPlayerIdentifiers(player.Handle); i++)
            {
                indentfiers += GetPlayerIdentifier(player.Handle, i) + " ";
            }
            Console.WriteLine($"{GetCurrentResourceName()}: {player.Name} trying to connect with Indentfiers: {indentfiers}");
            switch (CheckPlayerIsPermitForServer(player))
            {
                case "success":
                    //Do nothing...
                    break;
                case "missing_steam":
                    kickCallback(LG_Steam_Required);
                    CancelEvent();
                    break;
                case "missing_license":
                    kickCallback(LG_License_Required);
                    CancelEvent();
                    break;
                case "missing_discord":
                    kickCallback(LG_Discord_Required);
                    CancelEvent();
                    break;
                case "missing_fivem_acc":
                    kickCallback(LG_FiveM_Acc_Required);
                    CancelEvent();
                    break;
                case "steam_not_permitted":
                    kickCallback(LG_Steam_Not_Permitted);
                    CancelEvent();
                    break;
                case "license_not_permitted":
                    kickCallback(LG_License_Not_Permitted);
                    CancelEvent();
                    break;
                case "discord_not_permitted":
                    kickCallback(LG_Discord_Not_Permitted);
                    CancelEvent();
                    break;
                case "fivem_not_permitted":
                    kickCallback(LG_FiveM_Acc_Not_Permitted);
                    CancelEvent();
                    break;
                default:
                    kickCallback(LG_Other_Reasons);
                    CancelEvent();
                    break;
            }
        }
    }
}
