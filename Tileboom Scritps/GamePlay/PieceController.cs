using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PieceController : MonoBehaviour
{
    public GameController Controller;
    public SlotKillerController skc;
    [SerializeField] 
    private Transform initial, destination,p8;
    public Transform realoc;
    private Vector3 initialPosition;    
    public bool isMove = false;
    public bool isMove2 = false;
    public bool isReturn = false;
    public string _name;
    [SerializeField]
    private SpriteRenderer _spt;
    public bool isP8;
    public int iIndex;

    public GameObject vfx;

    public int layer;

    public bool locked = false;

    private BoxCollider2D bx;

    [SerializeField]
    private List<GameObject> auxList = new List<GameObject>();
    private void Start()
    {
        
        initialPosition = transform.position;
        initial = transform;
        bx = GetComponent<BoxCollider2D>();
       
    }

    private void OnEnable()
    {
        Controller.SetToListBtn(gameObject);
    }

    public void SetSpriteAndName(Sprite sp,string nameAux)
    {
        _spt.sprite = sp;
        _name = nameAux;
    }


    private void OnMouseDown()
    {
        if(!skc.isPlaused && !locked)
        {
            bx.enabled = false;
            SetTimer();
            destination = skc.MoveToDesignedPosition(gameObject);
            isMove = true;
            GetComponent<RemoveFrontList>().RemoveList();
            
        }
             

    }

    public void SetDestination()
    {

    }

    public void SetTimer()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        
        yield return new WaitForSeconds(2f);
        bx.enabled = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<PieceController>().layer > layer)
            {
                auxList.Add(collision.gameObject);
                locked = true;
                _spt.color = new Color(1f, 1f, 1f, 0.5f);
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<PieceController>().layer > layer)
            {
                auxList.Remove(collision.gameObject);

                if(auxList.Count <= 0) 
                {
                    locked = false;
                    _spt.color = new Color(1f, 1f, 1f, 1f);
                  
                }
            }

            
        }
    }

    public void Update()
    {
        if (isMove)
        {
            MoveTowards();
        }

        if (isReturn)
        {
            ReturnCard();
        }

        if (isP8)
        {
            SetToP8();
        }
        
        if(isMove2)
        {
            RealocPositions();
        }
    }

    public void RealocPositions()
    {
        isMove2 = true;
        Vector3 direction = realoc.position - initial.position;
        transform.position += direction * 8f * Time.deltaTime;
        if (transform.position == destination.position)
        {            
            isMove2 = false;
        }
    }

    void MoveTowards()
    {
       
        Vector3 direction = destination.position - initial.position;

        
        transform.position += direction *8f * Time.deltaTime;
        if(transform.position == destination.position)
        {
            skc.check();
            isMove = false;
        }
    }

    public void ReturnCard()
    {
        Vector3 direction = initialPosition - transform.position;

        // Move o objeto nessa direção.
        transform.position += direction * 7f * Time.deltaTime;
       
        if (Vector3.Distance(transform.position,initialPosition)<0.01f)
        {
            isReturn = false;
        }
    }

    public void SetToP8()
    {
        Vector3 direction = p8.position - transform.position;

        // Move o objeto nessa direção.
        transform.position += direction * 7f * Time.deltaTime;
        if (transform.position == p8.position)
        {
            
            isP8 = false;
        }
    }

    public void ActivePS()
    {
       Instantiate(vfx,transform.position,transform.rotation);
    }

    public void RemoveList()
    {
        GetComponent<RemoveFrontList>().RemoveList();
        gameObject.SetActive(false);
    }
}
