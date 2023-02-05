# NoSurrender_Project
NoSurrender demo Unity3d Game Project

 I used Cinemachine for camera control. I used a joystick for character movement mobile control and I disable it so that it does not show on the scene. For the opponent's movement and behavior, I use NavMesh. However, because of navmesh areas, my navmesh agents could not leave the platform. I can not push them. So, I added separate navMesh areas under the platform edges and connected them with OffMeshLinks. Between these navmesh areas, there are collider triggers that are triggering to restart the scene or add score points. My thinking was that nav mesh agents can go to the OffMeshLink and trigger the colliders. Resulting score to increased. But I still could not push the agents off the platform. I am thinking it is because the destination of the agents is the closest player.
 
 This is the video of the game: https://drive.google.com/file/d/1oJLNFApeddqqpoH0rGn8npIeH8n-pSeH/view?usp=share_link

Kamera kontrolü için Cinemachine kullandım. Karakterin mobil touch kontrolü için joystick kullandım. Sahnede görünmemesi için resimlerini kapattım.

Diğer karakterlerin kontrolü için NavMesh kullandım. En yakın oyuncuya gitmeleri için AIControl scriptini yazdım. 
Fakat navmesh alanı platform olduğu için karakterler platform dışına çıkmıyorlardı. Ben de sorunu çözmek için platformun uçlarının altına başka navmesh alanları koyup 
OffMeshLink ile birleştirdim. Ana platform ve diğer alanların arasında trigger collider'ı olduğu için OffMeshLink'ki kullandıklarında collider'ı trigger edeceker ve 
puan kazanılacaktı. 
Fakat yine de karakterler platformu terketmiyorlar. Verilen süre içerisinde bu sorunu çözemedim. 


Oyunun videosu: https://drive.google.com/file/d/1oJLNFApeddqqpoH0rGn8npIeH8n-pSeH/view?usp=share_link



![screenshot](https://user-images.githubusercontent.com/32210921/216812966-d0956672-c37c-436a-a592-e02c1a98821d.png)
