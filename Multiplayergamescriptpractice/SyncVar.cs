using UnityEngine;
using UnityEngine.Networking;

//서버와 클라이언트 사이를 싱크로화 

public class SyncVarScript : NetworkBehaviour {

    // Health of the game object
    [SyncVar]
    public int health = 100;

    // Called on the server when the game object takes damage
    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    // Called when the game object dies
    private void Die() {
        NetworkServer.Destroy(gameObject);
    }
}
