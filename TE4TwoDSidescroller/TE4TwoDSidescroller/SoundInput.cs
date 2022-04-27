using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Media;
using System.Text;
using System.IO;
using System;

namespace TE4TwoDSidescroller
{
    class SoundInput : Game1
    {
        //hej där harry du ska ladda in alla filer här och sätta in dom  i sound players
        //sedan ska ddu skicak dem till en array i varje karakträ. 
        //sedam ska jag spela upp dem med metoden play array.sound skiut

        #region FilePaths

        public static string songPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Sound" + "/Song.wav";

        #endregion


        public static SoundEffect knigthWalk;
        public static SoundEffect mainCharacterJump;
        public static SoundEffect swordSwoosh;
        public static SoundEffect evilLaugh;
        public static SoundEffect startFireBall;
        public static SoundEffect activeFireBall;
        public static SoundEffect knigthSwosh;
        public static SoundEffect preBossMusic;
        public static SoundEffect ominousMusic;

        public static SoundEffectInstance soundEffectInstance;
        public static SoundEffectInstance soundEffectknigthWalkInstance;
        public static SoundEffectInstance soundEffectmainCharacterJumpInstance;
        public static SoundEffectInstance soundEffectswordSwooshInstance;
        public static SoundEffectInstance soundEffectevilLaughInstance;
        public static SoundEffectInstance soundEffectstartFireBallInstance;
        public static SoundEffectInstance soundEffectactiveFireBallInstance;
        public static SoundEffectInstance soundEffectknigthSwoshInstance;
        public static SoundEffectInstance preBossMusicInstance;
        public static SoundEffectInstance ominousMusicInstance;
        public static SoundEffectInstance lastSongInstance;

       
        public SoundInput()
        {

        }

        public static void ContentLoad(ContentManager content)
        {

            knigthWalk = content.Load<SoundEffect>("Audio/ChainmailWalk");
            mainCharacterJump = content.Load<SoundEffect>("Audio/ShadowJump");
            swordSwoosh = content.Load<SoundEffect>("Audio/swoosh");
            evilLaugh = content.Load<SoundEffect>("Audio/EvilLaugh");
            startFireBall = content.Load<SoundEffect>("Audio/Fireball");
            activeFireBall = content.Load<SoundEffect>("Audio/FireballFire");
            knigthSwosh = content.Load<SoundEffect>("Audio/KnightSwordSwoosh");
            preBossMusic = content.Load<SoundEffect>("Audio/PreBossLevelMusic");
            ominousMusic = content.Load<SoundEffect>("Audio/CreepyBGMusic");

            soundEffectInstance = evilLaugh.CreateInstance();

            soundEffectknigthWalkInstance = knigthWalk.CreateInstance();
            soundEffectmainCharacterJumpInstance = mainCharacterJump.CreateInstance();
            soundEffectswordSwooshInstance = swordSwoosh.CreateInstance();
            soundEffectevilLaughInstance = evilLaugh.CreateInstance();
            soundEffectstartFireBallInstance = startFireBall.CreateInstance();
            soundEffectactiveFireBallInstance = activeFireBall.CreateInstance();
            soundEffectknigthSwoshInstance = knigthSwosh.CreateInstance();
            preBossMusicInstance = preBossMusic.CreateInstance();
            ominousMusicInstance = ominousMusic.CreateInstance();

    }



        public static void SoundEffectPlayed(SoundEffect fileBeingPlayed, float fileVolume, float filePitch, float filePan)
        {
            
            fileBeingPlayed.Play(volume: fileVolume, pitch: filePitch, pan: filePan);
           
        }

        public static void SongPlay(SoundEffectInstance songFileBeingPlayed, float fileVolume, float filePitch, float filePan)
        {
            if (lastSongInstance != null)
            {

                lastSongInstance.Stop();

            }

            if (songFileBeingPlayed.IsLooped == false)
            {

                songFileBeingPlayed.IsLooped = true;

            }

            songFileBeingPlayed.Volume = fileVolume;
            songFileBeingPlayed.Pitch = filePitch;
            songFileBeingPlayed.Pan = filePan;
            
            songFileBeingPlayed.Play();

            lastSongInstance = songFileBeingPlayed;

        }

        public static void SoundEffectInstance(SoundEffectInstance fileBeingPlayed, float fileVolume, float filePitch, float filePan)
        {
            fileBeingPlayed.Volume = fileVolume;
            fileBeingPlayed.Pitch = filePitch;
            fileBeingPlayed.Pan = filePan;
            fileBeingPlayed.Play();
        }


        //public void MusicPlayer(SoundPlayer playingMusicFile)
        //{
        //    playingMusicFile.Stop();
        //    playingMusicFile.PlayLooping();
        //}
    }
}
