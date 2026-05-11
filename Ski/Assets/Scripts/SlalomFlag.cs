using UnityEngine;

public class SlalomFlag : MonoBehaviour
{
    private enum Direction {Left, Right};
    [SerializeField] private Direction direction;
    [SerializeField] private Material goodMat, badMat;
    private bool flagPassed = false;
    public static event GameManager.TimerEvent RacePenalty;
    void Update()
    {
        

        if (PlayerControl.player != null && PlayerControl.player.position.z < transform.position.z &&
            flagPassed == false)
        {
            Direction passingDirection = Direction.Right;
            if (PlayerControl.player.position.x < transform.position.x)
                passingDirection = Direction.Left;
            
            flagPassed = true;
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (passingDirection == direction)
            {
                renderer.material = goodMat;
            }
            else
            {
                renderer.material = badMat;
            }
        }
    }
}
