using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private GameObject ourPlayer;
    [SerializeField] private GameObject ourAnimPlayer;
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        upButton.onClick.AddListener(MoveUp);
        downButton.onClick.AddListener(MoveDown);
        leftButton.onClick.AddListener(MoveLeft);
        rightButton.onClick.AddListener(MoveRight);
    }
    
    
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    private void MoveUp()
    {
        ourAnimPlayer.transform.rotation=Quaternion.Euler(0,0,0);
    }

    private void MoveDown()
    {
        ourAnimPlayer.transform.rotation=Quaternion.Euler(0,-180,0);
    }

    private void MoveLeft()
    {
        ourAnimPlayer.transform.rotation=Quaternion.Euler(0,-90,0);
    }

    private void MoveRight()
    {
        ourAnimPlayer.transform.rotation=Quaternion.Euler(0,90,0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement movementScript = ourPlayer.GetComponent<Movement>();
        ButtonNewController btnMovement = ourPlayer.GetComponent<ButtonNewController>();
        MobileMovement mblMovement = ourPlayer.GetComponent<MobileMovement>();
        
        if (movementScript.animTrigger == true)
        {
            _anim.SetBool("animTrigger",true);
        }
        else
        {
            _anim.SetBool("animTrigger",false);
        }
        
        if (btnMovement.animTrigger == true)
        {
            _anim.SetBool("animTrigger",true);
        }
        else
        {
            _anim.SetBool("animTrigger",false);
        }
        
        
        
        
        
        
        
        

        if (Input.GetButtonDown("right"))
        {
            gameObject.transform.rotation=Quaternion.Euler(0,90,0);
        }
        if (Input.GetButtonDown("left"))
        {
            gameObject.transform.rotation=Quaternion.Euler(0,-90,0);
        }
        if (Input.GetButtonDown("up"))
        {
            gameObject.transform.rotation=Quaternion.Euler(0,0,0);
        }
        if (Input.GetButtonDown("down"))
        {
            gameObject.transform.rotation=Quaternion.Euler(0,-180,0);
        }
    }
}
