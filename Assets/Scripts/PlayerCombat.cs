using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    public PlayerMain main;
    public PlayerAlt alt;
    public PlayerMove move;
    public PlayerUltimate ultimate;

    void Update() {
        main.Update();
        alt.Update();
        move.Update();
        ultimate.Update();
    }
}
