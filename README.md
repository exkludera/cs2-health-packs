<div align="center">
  <img width="50" height="50" alt="cssharp" src="https://github.com/user-attachments/assets/3393573f-29be-46e1-bc30-fafaec573456" />
	<h3><strong>Health Packs</strong></h3>
	<h4>a plugin that drops health packages when players die</h4>
	<h2>
		<img src="https://img.shields.io/github/downloads/exkludera-cssharp/health-packs/total" alt="Downloads">
		<img src="https://img.shields.io/github/stars/exkludera-cssharp/health-packs?style=flat&logo=github" alt="Stars">
		<img src="https://img.shields.io/github/forks/exkludera-cssharp/health-packs?style=flat&logo=github" alt="Forks">
		<img src="https://img.shields.io/github/license/exkludera-cssharp/health-packs" alt="License">
	</h2>
	<!--<a href="https://discord.gg" target="_blank"><img src="https://img.shields.io/badge/Discord%20Server-7289da?style=for-the-badge&logo=discord&logoColor=white" /></a> <br>-->
	<a href="https://ko-fi.com/exkludera" target="_blank"><img src="https://img.shields.io/badge/KoFi-af00bf?style=for-the-badge&logo=kofi&logoColor=white" alt="Buy Me a Coffee at ko-fi.com" /></a>
	<a href="https://paypal.com/donate/?hosted_button_id=6AWPNVF5TLUC8" target="_blank"><img src="https://img.shields.io/badge/PayPal-0095ff?style=for-the-badge&logo=paypal&logoColor=white" alt="PayPal"  /></a>
	<a href="https://github.com/sponsors/exkludera" target="_blank"><img src="https://img.shields.io/badge/Sponsor-696969?style=for-the-badge&logo=github&logoColor=white" alt="GitHub Sponsor" /></a>
</div>

> [!NOTE]
> inspired by [[CS:GO] Drop Random Health Pack](https://forums.alliedmods.net/showthread.php?t=193359)

<img src="https://github.com/user-attachments/assets/53e486cc-8da4-45ab-bc6e-eb38145aba36" height="200px"> <br>

## Requirements
- [MetaMod](https://github.com/alliedmodders/metamod-source)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)
- [MultiAddonManager](https://github.com/Source2ZE/MultiAddonManager)

## Showcase
<details>
<summary>content</summary>
	
https://github.com/user-attachments/assets/ad2c8460-7737-4e27-9467-aefc9f25a80b

<img src="https://github.com/user-attachments/assets/636f96c3-14c4-40d9-b030-5f1ba86272bb" width="350"> <br>
<img src="https://github.com/user-attachments/assets/c78d1ccb-df27-4a93-9db3-0f09f3879667" width="350"> <br>
</details>


## Config
<details>
<summary>HealthPacks.json</summary>
	
```json
{
  "Settings": {
    "DropPercentage": 50,
    "DropDelay": 0,
    "HealAmount": 40,
    "MaxHealth": 100
  },
  "Entity": {
    "Model": "models/therazu/props/healthpack/healthpack.vmdl",
    "DeleteTimer": 10,
    "DeleteIfFullHealth": false,
    "SpawnHeight": 32,
    "SpawnVelocity": 250,
    "MaxCount": 64
  },
  "Chat": {
    "Enabled": true,
    "Prefix": "{lightred}[HealthPack]",
    "DropAnnounce": true,
    "PickupAnnounce": true
  },
  "Sounds": {
    "Enabled": true,
    "PickupSound": "sounds/buttons/blip1.vsnd",
    "PickupFailSound": "sounds/buttons/button8.vsnd",
    "SoundEvents": false,
    "SoundEvent": "soundevents/healthpacks.vsndevts",
    "PickupEvent": "pack_pickup",
    "PickupFailEvent": "pack_pickupfail"
  },
  "Debug": false
}
```
</details>
