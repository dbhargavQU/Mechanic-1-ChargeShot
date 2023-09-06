using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public GameObject projectilePrefab;  
    public float minForce = 2f;        
    public float maxForce = 10f;        
    public float chargeTime = 2f;     

    private float currentCharge = 0f;

    void Update()
    {
        // Start charging when mouse button is pressed down
        if (Input.GetMouseButtonDown(0)) currentCharge = 0f;

        // Continue to charge while holding the mouse button
        if (Input.GetMouseButton(0)) currentCharge += Time.deltaTime;

        // Fire the projectile when the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Calculate force based on current charge
            float force = Mathf.Lerp(minForce, maxForce, currentCharge / chargeTime);
            
            // Call the Fire function to instantiate and launch the projectile
            Fire(force);
            
            // Reset charge
            currentCharge = 0f;
        }
    }

    void Fire(float force)
    {
        // Instantiate the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Apply the calculated force to the projectile
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * force, ForceMode2D.Impulse);
    }
}
