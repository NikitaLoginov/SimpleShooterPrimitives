using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float onscreenDelay = 3f;

    private void Update()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
