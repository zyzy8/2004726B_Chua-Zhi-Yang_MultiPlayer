using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    StartCoroutine(Coroutine_DelayPlayerLoad(1.0f));
  }

  IEnumerator Coroutine_DelayPlayerLoad(float secs)
  {
    yield return new WaitForSeconds(secs);

    CreatePlayer();
  }


  void CreatePlayer()
  {
    Vector3 pos = mSpawnPoints.GetSpawnPoint().position;
    pos.y = 3.0f;

    mPlayerGameObject = PhotonNetwork.Instantiate(mPlayerPrefabName,
        pos,
        mSpawnPoints.GetSpawnPoint().rotation,
        0);

    mPlayerGameObject.GetComponent<PlayerMovement>().mFollowCameraForward = false;
    mThirdPersonCamera = Camera.main.gameObject.AddComponent<ThirdPersonCamera>();
    mThirdPersonCamera.mPlayer = mPlayerGameObject.transform;
    mThirdPersonCamera.mDamping = 5.0f;
    mThirdPersonCamera.mPositionOffset = new Vector3(1.0f, 2.0f, -3.5f);
    mThirdPersonCamera.mCameraType = CameraType.Follow_Track_Pos_Rot;

    textPlayerName.text = PhotonNetwork.NickName;
  }
  public void LeaveRoom()
  {
    //Debug.LogFormat("LeaveRoom");
    //PhotonNetwork.LeaveRoom();
  }

}
