--[[
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

]]--

resource_manifest_version '44febabe-d386-4d18-afbe-5e627f4af937'
server_script 'mz_whitelist.net.dll';

--Whitelist:
--Permited Useres:
--Steam: Schaue auf: https://www.youtube.com/watch?v=zxXl0TNwpaI um zu sehen wie man Steam ID´s für FiveM generiert
steam {
	'steam:110000107c45664',	--MasterZyper
	'steam:110000107c35241',	--Dummy 1
	'steam:110000107c52314'		--Dummy 2
}
--Gamelicense:
license {
	'license:62b8f3a25ecfb3c2895a83aa39232b67665bcf15', --MasterZyper
	'license:62b8f3a25ecfb3c2895a83aa39232b67665bcf15',	--Dummy 1
	'license:62b8f3a25ecfb3c2895a83aa39232b67665bcf15'	--Dummy 2
}
--Discord
discord {
	'discord:224904592633233409',	--MasterZyper
	'discord:454545123148452156',	--Dummy 1
	'discord:442302482154421411'	--Dummy 2
}
--FiveM
fivem {
	'fivem:151784', --MasterZyper
	'fivem:151455',	--Dummy 1
	'fivem:527184'	--Dummy 2
}
--Konfig:
cfg_steam_check '1'
cfg_license_check '0';
cfg_discord_check '0';
cfg_fivem_acc_check '1';

--Language:
lg_steam_required "You must be logged into Steam to join this server!";
lg_license_required "You do not have a valid Gamelicense!";
lg_discord_required "You need to have to install Discord to join this server!";
lg_fivem_acc_required "You need to have an FiveM Account to join this server!";

lg_steam_not_permitted "Your SteamAccount is not whitelisted!";
lg_license_not_permitted "Your Gamelicense is not whitelisted!";
lg_discord_not_permitted "Your Discordaccount is not whitelisted!";
lg_fivem_acc_not_permitted "Your FiveM_Account is not whitelisted!";

lg_other_reasons "You are not permitted to join this Server!"
