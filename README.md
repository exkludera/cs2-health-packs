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
> inspired by [[CS:GO] Drop Random Health Pack](https://forums.alliedmods.net/showthread.php?t=193359)
> 
> ty @heartbreakhotel from cssharp discord for distance calculation

<img src="https://media.discordapp.net/attachments/1051988905320255509/1146537451750432778/ezgif.com-video-to-gif_2.gif?ex=66a359f6&is=66a20876&hm=768e346857f44792cf5b2917fe55b525522029ecccac95bb765b881baa6660d7&" width="250">>

<br>

<a href='https://ko-fi.com/G2G2Y3Z9R' target='_blank'><img style='border:0px; height:75px;' src='https://storage.ko-fi.com/cdn/brandasset/kofi_s_tag_dark.png?_gl=1*6vhavf*_gcl_au*MTIwNjcwMzM4OC4xNzE1NzA0NjM5*_ga*NjE5MjYyMjkzLjE3MTU3MDQ2MTM.*_ga_M13FZ7VQ2C*MTcyMjIwMDA2NS4xNy4xLjE3MjIyMDA0MDUuNjAuMC4w' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>

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
