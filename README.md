# cs2-health-packs
**this plugin drops health packages when players die**
> request from counterstrikesharp discord

<br>

<details>
	<summary>showcase</summary>
	<img src="https://media.discordapp.net/attachments/901988124178145330/1266093924175450142/image.png?ex=66a3e55a&is=66a293da&hm=24bd4e85da935197ddf472f439119106f075ff90553f4144766a5170e1a36fd8&=&format=webp&quality=lossless" width="400"> <br>
	<img src="https://media.discordapp.net/attachments/901988124178145330/1266093924460658829/image.png?ex=66a3e55a&is=66a293da&hm=5883c8f756cd343f20cfb0265239b15ea3bfef6486f99b179ea2d025583354f7&=&format=webp&quality=lossless" width="350"> <br>
	<img src="https://media.discordapp.net/attachments/901988124178145330/1266093924691480798/image.png?ex=66a3e55a&is=66a293da&hm=145a86047927bdf46e0243ccc78ef7c1139ee0effb084fbf9a64cfaf7a9df7b0&=&format=webp&quality=lossless" width="350"> <br>
  I could show more but I'm lazy 🐱
</details>

<br>

## information
> [!NOTE]
> inspired by [[CS:GO] Drop Random Health Pack](https://forums.alliedmods.net/showthread.php?t=193359)
> 
> ty @heartbreakhotel from cssharp discord for distance calculation

<img src="https://media.discordapp.net/attachments/1051988905320255509/1146537451750432778/ezgif.com-video-to-gif_2.gif?ex=66a359f6&is=66a20876&hm=768e346857f44792cf5b2917fe55b525522029ecccac95bb765b881baa6660d7&" width="250">>

## config
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
