using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform field, knight, coin, wall;
    public Color fieldColor1, fieldColor2;
    public KeyCode hotswapKeyCode;

    private string symbols = "";
    private int numRows = 0;
    private int numColumns = 0;
    private int coinTotal = 0;
    private Vector3 fieldPosition, figurePosition;

    // Start is called before the first frame update
    void Start()
    {
        GameDirector.inputEnabled = true;
        GetSymbols();
        SetBoard();
    }
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(hotswapKeyCode) && GameDirector.inputEnabled )
        {
            DestroyBoard();
            GetSymbols();
            SetBoard();
        }
    }

    private void DestroyBoard()
    {
        for ( int i = 0; i < this.transform.childCount; i++ )
        {
            Destroy( this.transform.GetChild(i).gameObject );
        }
    }

    private void GetSymbols()
    {
        FileReader fr = new FileReader();
        symbols = fr.ReadString();
        numRows = fr.fileRows;
        numColumns = symbols.Length / numRows;
    }

    private void SetBoard()
    {
        fieldPosition = field.GetComponent<Field>().GetPosition();
        figurePosition = fieldPosition;
        coinTotal = 0;
        int pos = 0;

        for ( int i = 1; i <= numRows; i++ )
        {
            for ( int j = 1; j <= numColumns; j++ )
            {
                Transform newField = Instantiate( field, fieldPosition, Quaternion.identity );
                newField.parent = this.gameObject.transform;

                SetColorToField( newField, ( i + j ), fieldColor1, fieldColor2 );

                SetFigureOnField( newField, pos );
               
                fieldPosition.x += 1;
                pos++;
            }
            fieldPosition.x = field.position.x;
            fieldPosition.z -= 1;
        }
        Coin.total = coinTotal;
    }

    private void SetColorToField( Transform newField, int fieldNum, Color fieldColor1, Color fieldColor2 )
    {
        if ( ( fieldNum ) % 2 == 0 )
        {
            newField.GetComponent<Renderer>().material.color = fieldColor1;
        }
        else
        {
            newField.GetComponent<Renderer>().material.color = fieldColor2;
        }
    }

    private void SetFigureOnField( Transform newField ,int pos )
    {
        figurePosition = fieldPosition;
        figurePosition.y += 0.09f;
        switch ( symbols[pos] )
        {
            case '.': break;
            case '#':
                figurePosition.x -= 0.35f;
                Transform newWall = Instantiate( wall, figurePosition, Quaternion.Euler(-90,0,0) );
                newWall.parent = newField;
                break;
            case 'C':
                Transform newCoin = Instantiate( coin, figurePosition, Quaternion.identity );
                newCoin.parent = newField;
                coinTotal++;
                break;
            case 'K':
                Transform newKnight = Instantiate( knight, figurePosition, Quaternion.Euler(0, 90, 0) );
                newKnight.parent = newField;
                break;
        }
    }
}
