using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IcyTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetRange = 3f;
    [SerializeField] private float attackPerSecond = 0.25f;
    [SerializeField] private float freezeTime = 1f;

    private float timeUntilFire;

    private void Update()
    {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / attackPerSecond)
            {
                FreezeEnemy();
                timeUntilFire = 0f;
            }
    }  

    private void FreezeEnemy()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.UpdateSpeed(0.5f);

                StartCoroutine(ResetEnemySpeed(em));
            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeTime); 

        em.ResetSpeed();
    }

    private void OnDrawGizmosSelected()
    {
        #if UNITY_EDITOR
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
        #endif
    }
}
