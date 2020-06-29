using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : MonoBehaviour
{
    [SerializeField]
    float slowDownFactor = 2f;
    [SerializeField]
    float slowDownTime = 4f;

    [SerializeField]
    GameObject coldEffect;

    public void SlowEnemy(EnemyMovement enemyMovement, Transform parentTransform)
    {
        enemyMovement.SlowDownMovement(slowDownFactor);
        //GameObject effect = Instantiate(coldEffect, enemyMovement.transform.position + enemyMovement.transform.up * 2, Quaternion.identity, enemyMovement.transform);
        GameObject effect = Instantiate(coldEffect, parentTransform.position + parentTransform.up * 0.5f, Quaternion.identity, parentTransform);

        StartCoroutine(CancelSlowDownRoutine(enemyMovement, effect));
    }

    private IEnumerator CancelSlowDownRoutine(EnemyMovement enemyMovement, GameObject effect)
    {
        yield return new WaitForSeconds(slowDownTime);
        enemyMovement.CancelSlowDownMovement(slowDownFactor);
        Destroy(effect);
        Destroy(gameObject);
    }
}
