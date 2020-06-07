using UnityEngine;

namespace Assets.Scripts
{
    public class ConstantForceApplier : MonoBehaviour
    {
        private Vector3 force;

        private void Update()
        {
            if (force != null)
                transform.position += force * Time.deltaTime;
        }

        public void ApplyForce(Vector3 force) => this.force = force;
    }
}
