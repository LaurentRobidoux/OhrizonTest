using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CardComponent : MonoBehaviour
    {
    public void Start()
    {
        objectToRotate = this.gameObject;
    }
    public void OnMouseDown()
    {
        StartRotation(true);
       
    }
    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public Material GetMaterial()
    {
        return GetComponent<MeshRenderer>().material;
    }
    public void ChangeMaterial(Material mat)
    {
        GetComponent<MeshRenderer>().material = mat;
    }
    public GameObject objectToRotate;
    private bool rotating;

    private IEnumerator Rotate(Vector3 angles, float duration,bool callback)
    {
        rotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        objectToRotate.transform.rotation = endRotation;
        rotating = false;
        if (callback)
        {
            GetComponentInParent<MemoryComponent>().ChildClickedOn(this);
        }
        
    }
    

    public void StartRotation(bool callback)
    {
        if (!rotating)
            StartCoroutine(Rotate(new Vector3(0, 180, 0), 1,callback));
    }
}

