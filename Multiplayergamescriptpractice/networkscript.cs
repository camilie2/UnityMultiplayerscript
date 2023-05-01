using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

//

   
    public float speed = 10f;

   
    void Update() {
        if (!isLocalPlayer) {
            return;
        }

      
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * speed * Time.deltaTime);
    }

   
    public override void OnStartLocalPlayer() {
        base.OnStartLocalPlayer();
        GetComponent<Renderer>().material.color = Color.blue; 
    }
}

