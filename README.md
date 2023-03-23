# MidiSorcery
Custom Midi player for windows using DryWetMidi

Allows for super simple MIDI file playback using any preferred midi output device.

To change preferred synth edit: `c/:Users/USER/AppData/Roaming/MidiSorcery/Synth.option` enter the name of your preferred Synth here, it defaults to: `Microsoft GS Wavetable Synth` which is included in windows.

To check for synths again, delete the `Synth.option` file and launch the software. The software will pick to the lowest synth in the options document. Comment out any synth you do not want used.

Simply chose "open-with" in windows and select the software to open a `.mid` file

To use with commandline you need to add the software to `PATH`
