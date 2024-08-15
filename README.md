# cs2-health-packs
**a plugin that drops health packages when players die**

<br>

<details>
	<summary>showcase</summary>
	<img src="https://github.com/user-attachments/assets/6b6c97c4-fb99-424e-82d0-065a655a3e6a" width="400"> <br>
	<img src="https://github.com/user-attachments/assets/636f96c3-14c4-40d9-b030-5f1ba86272bb" width="350"> <br>
	<img src="https://github.com/user-attachments/assets/c78d1ccb-df27-4a93-9db3-0f09f3879667" width="350"> <br>
  	I could show more but I'm lazy 🐱
</details>

<br>

## information:

### requirements
- [MetaMod](https://cs2.poggu.me/metamod/installation)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

<br>

> [!NOTE]
> ty @heartbreakhotel from cssharp discord for distance calculation
> 
> inspired by [[CS:GO] Drop Random Health Pack](https://forums.alliedmods.net/showthread.php?t=193359)

<img src="https://github.com/user-attachments/assets/53e486cc-8da4-45ab-bc6e-eb38145aba36" height="200px"> <br>

<br>

## example config
```json
{
  "Settings": {
    "AlwaysDrop": false,
    "DropPercentage": 50,
    "DropDelay": 0.1,
    "HealAmount": 40,
    "MaxHealth": 100,
    "PickupDistance": 32
  },
  "Entity": {
    "Model": "models/chicken/chicken_roasted.vmdl",
    "DeleteTimer": 10,
    "DeleteIfFullHealth": true,
    "SpawnHeight": 10,
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
    "PickupFailSound": "sounds/buttons/button8.vsnd"
  },
  "Debug": false,
  "ConfigVersion": 1
}
```

<br> <a href='https://ko-fi.com/exkludera' target='blank'><img src='https://cdn.ko-fi.com/cdn/kofi5.png' height='48px' alt='Buy Me a Coffee at ko-fi.com'></a>
