using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Valve.VR;

//Require source to run
[RequireComponent(typeof(AudioSource))]
//Sync audio clips in Unet
public class AudioSync : NetworkBehaviour {

	//Clips to sync
	public AudioClip[] clips;

	public AudioClip[] audioMessages; 
	
	//Use gameobject's audio source
	private AudioSource source;

	// Use this for initialization
	void Start ()
	{
		instance = this;
		source = this.GetComponent<AudioSource> ();
	}

	public static int currentSlideIndex = 0;
	
	public void PlayAudioMessageForSlide(int slideNumber)
	{
		currentSlideIndex = slideNumber;
		PlayLocalSound(slideNumber);
	}

	public static AudioSync instance;

	public bool leftTriggerPressed;
	public bool rightTriggerPressed;
	
	private void Update()
	{
		
		if (SetupLocalPlayer.vrInitialized && !Application.isMobilePlatform)
		{
			
			if (SteamVR_Actions._default.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.RightHand))
			{
				//PlaySound(0);

				//Debug.Log("Right trigger pressed SlideIndex=" + currentSlideIndex + ",AudioTime=" + source.time);

				rightTriggerPressed = true;

				return;
			}

			if (SteamVR_Actions._default.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.LeftHand))
			{
				//PlaySound(1);
				
				//Debug.Log("Left trigger pressed SlideIndex=" + currentSlideIndex + ",AudioTime=" + source.time);

				leftTriggerPressed = false;
				
				return;
			}
		}
	}

	//Play clip from array, sending it to a server
	public void PlaySound(int id){
		if (id >= 0 && id < clips.Length) {
			CmdSendServerSoundID (id);
		}
	}

    //Play clip from array locally
    public void PlayLocalSound(int id) {
        if (id >= 0 && id < clips.Length)
        {
	        source.Stop();
	        source.clip = clips[id];
            source.Play();
        }
    }

	[Command]
	void CmdSendServerSoundID(int id){
		//Play clip on the listeners clients
		RpcSendSoundIDToClients (id);
	}

	[ClientRpc]
	void RpcSendSoundIDToClients(int id){
		//Play clip once per client
		source.PlayOneShot(clips [id]);
	}
}
