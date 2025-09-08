# cs2-health-packs
**a plugin that drops health packages when players die**

<br>


<details>
<summary>showcase</summary>
	
https://github.com/user-attachments/assets/ad2c8460-7737-4e27-9467-aefc9f25a80b

<img src="https://github.com/user-attachments/assets/636f96c3-14c4-40d9-b030-5f1ba86272bb" width="350"> <br>
<img src="https://github.com/user-attachments/assets/c78d1ccb-df27-4a93-9db3-0f09f3879667" width="350"> <br>
</details>

<br>

## information:

### requirements
- [MetaMod](https://github.com/alliedmodders/metamod-source)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)
- [MultiAddonManager](https://github.com/Source2ZE/MultiAddonManager)

<br>

> [!NOTE]
> inspired by [[CS:GO] Drop Random Health Pack](https://forums.alliedmods.net/showthread.php?t=193359)

<img src="https://github.com/user-attachments/assets/53e486cc-8da4-45ab-bc6e-eb38145aba36" height="200px"> <br>

<br>

## example config
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

<br> <a href='https://ko-fi.com/exkludera' target='blank'><img src='https://cdn.ko-fi.com/cdn/kofi5.png' height='48px' alt='Buy Me a Coffee at ko-fi.com'></a>
