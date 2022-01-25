using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobForm : MonoBehaviour
{

    public GameObject blob;
    public GameObject jumpBoots;
    public GameObject speedBoots;
    public GameObject swordLeft;
    public GameObject swordRight;

    public PlayerController controller;
    Animator playerAnimator;
    public Animator swordRightAnimator;
    public Animator swordLeftAnimator;

    bool isBlob;
    bool isJumpBoots;
    bool isSpeedBoots;
    bool isSword;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        playerAnimator = GetComponent<Animator>();
        blob.SetActive(true);
        jumpBoots.SetActive(false);
        speedBoots.SetActive(false);
        swordRight.SetActive(false);
        swordLeft.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 1 = Blob
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Blob();
        }

        // Blob form
        if (isBlob)
        {
            controller.jumpForce = 6;
            controller.speed = 6;
        }

        // 2 = Jump Boots
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            JumpBoots();
        }

        // Jump boots form
        if (isJumpBoots)
        {
            controller.jumpForce = 12;
            controller.speed = 6;
        }

        // 3 = Speed Boots
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpeedBoots();
        }

        // Speed boots form
        if (isSpeedBoots)
        {
            controller.jumpForce = 6;
            controller.speed = 12;
        }

        // 4 = sword
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (playerAnimator.GetFloat("Look X") < 0)
            {
                SwordRight();
                swordRightAnimator.SetTrigger("Idle");
            }
            else
            {
                SwordLeft();
                swordLeftAnimator.SetTrigger("Idle");
            }
        }

        // sword form
        if (isSword) 
        {
            controller.jumpForce = 6;
            controller.speed = 6;

            if (playerAnimator.GetFloat("Look X") < 0)
            {
                swordLeft.SetActive(true);
                swordLeftAnimator.SetTrigger("Idle");
                swordRight.SetActive(false);
            }
            else
            {
                swordLeft.SetActive(false);
                swordRight.SetActive(true);
                swordRightAnimator.SetTrigger("Idle");
            }
        }
    }

    void Blob()
    {
        blob.SetActive(true);
        jumpBoots.SetActive(false);
        speedBoots.SetActive(false);
        swordRight.SetActive(false);
        swordLeft.SetActive(false);
        isBlob = true;
        isJumpBoots = false;
        isSpeedBoots = false;
        isSword = false;
    }

    void JumpBoots()
    {
        blob.SetActive(false);
        jumpBoots.SetActive(true);
        speedBoots.SetActive(false);
        swordRight.SetActive(false);
        swordLeft.SetActive(false);
        isBlob = false;
        isJumpBoots = true;
        isSpeedBoots = false;
        isSword = false;
    }

    void SpeedBoots()
    {
        blob.SetActive(false);
        jumpBoots.SetActive(false);
        speedBoots.SetActive(true);
        swordRight.SetActive(false);
        swordLeft.SetActive(false);
        isBlob = false;
        isJumpBoots = false;
        isSpeedBoots = true;
        isSword = false;
    }

    void SwordRight()
    {
        blob.SetActive(false);
        jumpBoots.SetActive(false);
        speedBoots.SetActive(false);
        swordRight.SetActive(true);
        swordLeft.SetActive(false);
        isBlob = false;
        isJumpBoots = false;
        isSpeedBoots = false;
        isSword = true;
    }

    void SwordLeft()
    {
        blob.SetActive(false);
        jumpBoots.SetActive(false);
        speedBoots.SetActive(false);
        swordRight.SetActive(false);
        swordLeft.SetActive(true);
        isBlob = false;
        isJumpBoots = false;
        isSpeedBoots = false;
        isSword = true;
    }
}
