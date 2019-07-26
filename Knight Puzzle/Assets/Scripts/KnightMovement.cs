using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public void MoveToField( Field wantedField )
    {
        if ( IsMoveLikeL( wantedField.GetPosition() ) && IsMovable( wantedField ))
        {
            GameObject.FindGameObjectWithTag("Knight").transform.position = wantedField.GetPosition();
            GameObject.FindGameObjectWithTag("Knight").transform.parent = wantedField.transform;
        }
        else
        {
            GameObject.FindGameObjectWithTag("AudioObject").GetComponent<AudioScript>().CantMove();
        }
    }

    private bool IsMoveLikeL( Vector3 wantedFieldPosition )
    {
        Vector3 currentFieldPosition =this.transform.parent.position;
        Vector3 helperFieldPosition = currentFieldPosition;
        Cartesian cartesian = new Cartesian();
        int x = 1, z = 2;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                currentFieldPosition = helperFieldPosition;
                currentFieldPosition.x += x * cartesian.x[j];
                currentFieldPosition.z += z * cartesian.z[j];
                if (currentFieldPosition == wantedFieldPosition)
                {
                    return true;
                }
            }
            x = 2;
            z = 1;
        }
        return false;
    }

    private bool IsMovable( Field wantedField )
    {
        if ( wantedField.transform.childCount > 0 )
        {
            Transform child = wantedField.transform.GetChild(0);
            if (child.tag == "Wall")
            {
                GameObject.FindGameObjectWithTag("AudioObject").GetComponent<AudioScript>().CantMove();
                return false;
            }
            else if (child.tag == "Coin")
            {
                GameObject.FindGameObjectWithTag("AudioObject").GetComponent<AudioScript>().CoinCollectPlay();
                Destroy(child.gameObject);
                Coin.total--;
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("AudioObject").GetComponent<AudioScript>().KnightMovePlay();
        }
        return true;
    }
}
