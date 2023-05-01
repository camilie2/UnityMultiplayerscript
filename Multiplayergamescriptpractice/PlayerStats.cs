using UnityEngine;
using Mirror;

public class PlayerStats : NetworkBehaviour
{
    //��Ƽ�÷��̾�� Player���� �޴� �⺻ stat ���� ���� �޴� script 
    //�� Script�� server�� client  ���̸� �����ϴ� ��������. 
    [SyncVar] public int health = 100;
    [SyncVar] public int stamina = 50;
    [SyncVar] public int attackPower = 10;

    //(Connection ID, character, physical strength, attack power, item, level, server ping)
    //(hearthstone, zoe, hp=300 , attack = 4, item : IBCM , LV : 4 , 15ms )
    //(saturn, king, hp = 36, attack = 17, item : AK-47 , LV : 3 , 22ms) 
    //(mars, teemo , hp = 30, attack = 400,  null, LV : 11 , 58ms)
   

    //player���� �����Ѵٸ� 
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
