using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    //get relevent objects
    public CinemachineVirtualCamera thirdPersonCamera; 
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera firstPersonCrouchedCamera;
    public Camera mainCamera;
    Animator animator;
    FirstAndThirdPersonCharacterInputs inputActions; 

    // bools for camera switching logic
    bool isFirstPerson;
    bool isCrouched;
    bool hasSwitchedRecently = false;
    
    void Start()
    {
        inputActions = new FirstAndThirdPersonCharacterInputs();
        inputActions.CharacterControls.Enable();
        animator = GetComponent<Animator>();
        thirdPersonCamera.gameObject.SetActive(true); //default active camera is third person
        isFirstPerson = false; // this is to check if were in first or third person
        firstPersonCamera.gameObject.SetActive(false); //disable first person cameras
        firstPersonCrouchedCamera.gameObject.SetActive(false);
        
    }

    void Update()
    {
        SwitchPersonPerspective();
        SwitchCrouchedPerspective();
    }

    private void SwitchPersonPerspective()
    {
        if (inputActions.CharacterControls.ChangeCamera.triggered)
        {
            hasSwitchedRecently = true;
            isCrouched = animator.GetBool("isCrouched");
            isFirstPerson = !isFirstPerson;
            if (isFirstPerson)
            {
                thirdPersonCamera.gameObject.SetActive(false); // disable third person camera
                firstPersonCrouchedCamera.gameObject.SetActive(isCrouched);
                firstPersonCamera.gameObject.SetActive(!isCrouched);
            }
            else
            {
                thirdPersonCamera.gameObject.SetActive(true);
                firstPersonCrouchedCamera.gameObject.SetActive(false);
                firstPersonCamera.gameObject.SetActive(false);
                mainCamera.cullingMask |= LayerMask.GetMask("FirstPersonHidden"); //restores player character 
            }

        }
        if(hasSwitchedRecently && isFirstPerson)
        {
            if (mainCamera.transform.position == firstPersonCamera.transform.position              //check if camera view has reached target camera view
                || mainCamera.transform.position == firstPersonCrouchedCamera.transform.position)  //gives the effect of the camera zooming into the player
            {
                mainCamera.cullingMask &= ~LayerMask.GetMask("FirstPersonHidden"); //then this culls player character in first person to avoid clipping
                hasSwitchedRecently = false;
            }
        }
    }

    private void SwitchCrouchedPerspective()
    {
        if (inputActions.CharacterControls.Crouch.triggered)
        {
            if (isFirstPerson)
            {
                isCrouched = animator.GetBool("isCrouched");
                firstPersonCrouchedCamera.gameObject.SetActive(!isCrouched); //these appear backwards because when they are called the isCrouched
                firstPersonCamera.gameObject.SetActive(isCrouched);          //variable hasnt changed, not an ideal solution but it works for now
            }
        }
    }
}
