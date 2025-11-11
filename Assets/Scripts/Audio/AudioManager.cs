

using UnityEngine;

using UnityEngine.Audio;


// this manages all the sounds in the game

public class AudioManager : MonoBehaviour
{
   
        public static AudioManager Instance; // so we can call it from anywhere



        // mixer groups for different sound types
        public AudioMixerGroup sfxMixerGroup;

        public AudioMixerGroup uiMixerGroup;



        // sound clips for player actions
        public AudioClip jumpSound;
        public AudioClip walkSound;




        // sound clips for UI buttons

        public AudioClip buttonHoverSound;
        public AudioClip buttonClickSound;



        // pitch randomization values
        public float minPitch = 0.9f;
        public float maxPitch = 1.1f;


        void Awake()
        {
            // make sure only one AudioManager exists
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // dont destroy when changingh scenes
            }
            else
            {
                Destroy(gameObject);
            }
        }


        // this plays any sound with random pitch
        public void PlaySound(AudioClip clip, AudioMixerGroup mixerGroup)
        {


            if (clip == null) return; // if no sound, do nothing





            // create a temporrary object to play the sound
            GameObject tempObject = new GameObject("Sound");




             // make the sound object a child of the AudioManager so it does NOT get destroyed when changing scenes

            tempObject.transform.SetParent(this.transform);




            // add an AudioSource component to the temporary object so it can actually play a sound
           AudioSource tempSource = tempObject.AddComponent<AudioSource>();



                // tell the AudioSource which sound to play
                 tempSource.clip = clip;




                 // tell the AudioSource which mixer channel to use
                     tempSource.outputAudioMixerGroup = mixerGroup;



                // randomize pitch so sounds are not always the same
            tempSource.pitch = Random.Range(minPitch, maxPitch);



            tempSource.Play();


            // destroy after sound finishes playing
            Destroy(tempObject, clip.length);
        }




        // functions to playt specific sounds

        public void PlayJumpSound()

        {
            PlaySound(jumpSound, sfxMixerGroup);

        }


        public void PlayWalkSound()
        {

            PlaySound(walkSound, sfxMixerGroup);
        }


        public void PlayButtonHoverSound()
        {
            PlaySound(buttonHoverSound, uiMixerGroup);
        }

        public void PlayButtonClickSound()
        {
            PlaySound(buttonClickSound, uiMixerGroup);
        }
    }