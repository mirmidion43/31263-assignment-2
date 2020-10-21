using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherryPrefab;
    private Tween activeTween = null;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCherry", 30.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {


        if(activeTween != null)
        {
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if(distance > 0.1f)
                {
                    float t = (Time.time - activeTween.StartTime) / activeTween.Duration;
                    activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, t);                    
                }
        
                if(distance <= 0.1f)
                {
                    activeTween.Target.position = activeTween.EndPos;
                    activeTween = null;
                } 

        }
        
    }

    private void SpawnCherry()
    {
        GameObject newCherry = Instantiate(cherryPrefab, new Vector3(-29.0f, 0.5f, 0.0f), Quaternion.identity);
        addTween(newCherry.transform, new Vector3(-29.0f, 0.5f, 0.0f), new Vector3(29.0f, 0.5f, 0.0f), 10.0f);
        StartCoroutine(DestroyCherry(newCherry, 10.0f));
    }

    public void addTween(Transform transform,Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null)
        {
            activeTween = new Tween(transform, startPos, endPos, Time.time, duration);
        }
            
    }

    public IEnumerator DestroyCherry(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        GameObject.Destroy(obj);
    }

    public void clearTween()
    {
        activeTween = null;
    }

    public void stopSpawn(){
        CancelInvoke();
    }
}
