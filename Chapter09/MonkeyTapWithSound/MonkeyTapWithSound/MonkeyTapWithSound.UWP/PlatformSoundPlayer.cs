using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(MonkeyTapWithSound.UWP.PlatformSoundPlayer))]

namespace MonkeyTapWithSound.UWP
{
    public class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        WinRuntimeShared.SharedSoundPlayer sharedSoundPlayer;

        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            if (sharedSoundPlayer == null)
            {
                sharedSoundPlayer = new WinRuntimeShared.SharedSoundPlayer();
            }

            sharedSoundPlayer.PlaySound(samplingRate, pcmData);
        }
    }
}
