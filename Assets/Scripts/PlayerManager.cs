using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is responsible for creating the Player
// at runtime.
public class PlayerManager : MonoBehaviour
{
  [SerializeField]
  Text textPlayerName;

  public string mPlayerPrefabName;
  public PlayerSpawnPoints mSpawnPoints;

  [HideInInspector]
  public GameObject mPlayerGameObject;
  [HideInInspector]
  private ThirdPersonCamera mThirdPersonCamera;

  private void Start()
  {
        //StartCoroutine(Coroutine_DelayPlayerLoad(1.0f));

        //Refactor:
        //A coroutine is useful, but in this case scenario, I believe that instantiating the character at the start of joining
        //the map makes it more fluid and smooth in terms of gameplay. Both methods of instantiating the character are 
        //the same in this case, however, calling the method in Start() improve the readability of the code as it requires less
        //lines of code than a coroutine.
        InstantiateCharacter();
        SetCamera();
        SetPlayerName();
  }

  //IEnumerator Coroutine_DelayPlayerLoad(float secs)
  //{
  //  yield return new WaitForSeconds(secs);

  //  CreatePlayer();
  //}


  //Refactor: Breaking up into smaller functions
  //Instantiates the character at the various spawn locations,
  //Then sets the TPC camera
  //And then set the name of the player
  void InstantiateCharacter()
   {
        Vector3 pos = mSpawnPoints.GetSpawnPoint().position;
        pos.y = 2.0f;

        mPlayerGameObject = PhotonNetwork.Instantiate(mPlayerPrefabName,
            pos,
            mSpawnPoints.GetSpawnPoint().rotation,
            0);
  }
  void SetCamera()
  {
    mPlayerGameObject.GetComponent<PlayerMovement>().mFollowCameraForward = false;
    mThirdPersonCamera = Camera.main.gameObject.AddComponent<ThirdPersonCamera>();
    mThirdPersonCamera.mPlayer = mPlayerGameObject.transform;
    mThirdPersonCamera.mDamping = 5.0f;
    mThirdPersonCamera.mPositionOffset = new Vector3(1.0f, 2.0f, -3.5f);
    mThirdPersonCamera.mCameraType = CameraType.Follow_Track_Pos_Rot;
  }
  //Set the name of the player 
  void SetPlayerName()
   {
        textPlayerName.text = PhotonNetwork.NickName;
   }
  
  public void LeaveRoom()
  {
        Debug.LogFormat("LeaveRoom");
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Menu");
    }

}
