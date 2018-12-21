using Core;
using System;
using System.Speech.Recognition;

namespace MinecraftCortana
{
    public class CortanaCommand : CustomCommand
    {
        public override System.String Command => "cortana";
        public static SpeechRecognitionEngine recognizer;
        private static World world;

        public override String[] Usage { get; }

        public CortanaCommand()
        {
            if (recognizer == null)
            {
                Setup();
            }

            Usage = new string[]
                {
                    Command + ""
                };
        }

        public static void Setup(String locale = "en-US")
        {
            if (recognizer != null) recognizer.Dispose();
            // Create an in-process speech recognizer for the en-US locale.  
            recognizer =
              new SpeechRecognitionEngine(
                new System.Globalization.CultureInfo(locale));

            // Create and load a dictation grammar.  
            recognizer.LoadGrammar(new DictationGrammar());

            // Add a handler for the speech recognized event.  
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(Recognizer_SpeechRecognized);

            // Configure input to the speech recognizer.  
            recognizer.SetInputToDefaultAudioDevice();
            Console.WriteLine("Set Recognizer to " + locale);
        }

        public override void Handle(System.String[] args)
        {
            world = ctx.World;
            Start();
        }

        void Start()
        {
            // Start asynchronous, continuous speech recognition.  
            recognizer.RecognizeAsync(RecognizeMode.Single);
        }

        // Handle the SpeechRecognized event.  
        static void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            world.SendCommands("You", "/say " + e.Result.Text);
        }
    }
}