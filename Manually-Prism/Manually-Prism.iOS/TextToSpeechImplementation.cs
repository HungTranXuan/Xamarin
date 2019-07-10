﻿using System;
using AVFoundation;
using ManuallyPrism;

namespace Manually_Prism.iOS
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public TextToSpeechImplementation()
        {
        }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };
            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}
