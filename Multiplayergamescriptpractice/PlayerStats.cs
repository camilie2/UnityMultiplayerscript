using UnityEngine;
using Mirror;

public class PlayerStats : NetworkBehaviour
{
    //멀티플레이어에서 Player들이 받는 기본 stat 들을 공유 받는 script 
    //이 Script은 server와 client  사이를 연결하는 역할을함. 
    [SyncVar] public int health = 100;
    [SyncVar] public int stamina = 50;
    [SyncVar] public int attackPower = 10;

    //(Connection ID, character, physical strength, attack power, item, level, server ping)
    //(hearthstone, zoe, hp=300 , attack = 4, item : IBCM , LV : 4 , 15ms )
    //(saturn, king, hp = 36, attack = 17, item : AK-47 , LV : 3 , 22ms) 
    //(mars, teemo , hp = 30, attack = 400,  null, LV : 11 , 58ms)
   

    //player들이 접속한다면 
    private void Start()
    {
       
        if (gameObject.name == "hearthstone")
        {
            health = 300;
            attackPower = 4;
          
        }
        else if (gameObject.name == "saturn")
        {
            health = 36;
            attackPower = 17;
          
        }
        else if (gameObject.name == "mars")
        {
            health = 30;
            attackPower = 400;
          
        }
    }

  
}
