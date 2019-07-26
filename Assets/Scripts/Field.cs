using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Color mouseHoverColor;

    private Color startcolor = new Color();
    private bool mouseEnter = false;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0) && mouseEnter && GameDirector.inputEnabled )
        {
            GameObject.FindGameObjectWithTag("Knight").GetComponent<KnightMovement>().MoveToField( this );
            mouseEnter = false;
        }
    }

    
    public Vector3 GetPosition()
    {
        Vector3 position = new Vector3();
        position.x = this.gameObject.transform.position.x;
        position.y = this.gameObject.transform.position.y;
        position.z = this.gameObject.transform.position.z;
        return position;
    }    

    void OnMouseEnter()
    {
        startcolor = this.GetComponent<Renderer>().material.color;
        this.GetComponent<Renderer>().material.color = mouseHoverColor;
        mouseEnter = true;
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = startcolor;
        mouseEnter = false;
    }
}
