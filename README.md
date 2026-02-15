# 🎵 Now Playing Widget for OBS

![Status](https://img.shields.io/badge/status-working-success)
![Platform](https://img.shields.io/badge/platform-Windows%2011-blue)
![Python](https://img.shields.io/badge/python-3.14-blue)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)

A real-time "Now Playing" widget for OBS that displays currently playing music from Apple Music (and other media apps) with album artwork.

## ✨ Features

- 🎵 **Real-time updates** - Automatically detects currently playing music
- 🖼️ **Album artwork** - Displays full-resolution album covers
- 🎨 **Modern UI** - Glassmorphism design with smooth transitions
- 🔄 **Background operation** - Works even when the music app isn't the active window
- 🎯 **Multi-app support** - Compatible with Apple Music, Spotify, Chrome, Edge, and more
- 🪟 **Windows Media Control** - Uses native Windows APIs for reliable detection

## 📸 Preview

The widget displays:
- Song title
- Artist name
- Album artwork
- Clean, transparent background for OBS

## 🔧 Requirements

- **Windows 11** (or Windows 10 with Media Control support)
- **Python 3.x** (tested with 3.14)
- **.NET SDK** (6.0 or later) - for compiling the helper executable

## 📦 Installation

### 1. Install .NET SDK

Download and install the .NET SDK from: https://dotnet.microsoft.com/download/dotnet

After installation, restart your terminal/PowerShell.

### 2. Clone the Repository

```bash
git clone https://github.com/yourusername/ViewAppleMusic.git
cd ViewAppleMusic/1.0
```

### 3. Compile the C# Helper

```bash
# On Windows, simply run:
compile.bat

# Or manually:
dotnet publish MediaInfoGetter.csproj -c Release -o .
```

This will create `MediaInfoGetter.exe` in the current directory.

### 4. Run the Backend

```bash
python main.py
```

You should see output like:
```
🎵 Now Playing Tracker démarré (C# Helper)
📁 Fichier de sortie: ...\current_song.json
⏱️  Intervalle de mise à jour: 1.0s
🎧 Compatible avec: Apple Music, Spotify, Chrome, Edge, etc.
```

### 5. Configure OBS

1. In OBS, add a new **Browser** source
2. ☑️ Check "Local file"
3. 📁 Browse and select `index.html` from this project
4. Set dimensions: **Width: 500**, **Height: 140**
5. Click OK

The widget should now display your currently playing music!

## 🎨 Customization

Edit `style.css` to customize:
- Colors and transparency
- Album artwork size
- Widget position
- Animation effects

## 🏗️ How It Works

```
Apple Music/Spotify
    ↓
Windows Media Control API
    ↓
MediaInfoGetter.exe (C# helper)
    ↓
main.py (Python backend)
    ↓
current_song.json
    ↓
index.html (Frontend with polling)
    ↓
OBS Browser Source
```

The C# helper accesses Windows Runtime APIs to retrieve media information, which Python processes and exports as JSON. The HTML interface polls this JSON file every second to update the display.

## 🐛 Troubleshooting

### Widget shows "No music playing"
- Make sure music is actually playing in Apple Music/Spotify
- Verify `python main.py` is running in the background
- Check that `current_song.json` is being generated

### "dotnet" command not found
- Install .NET SDK and restart your terminal
- Verify installation: `dotnet --version`

### No album artwork displayed
- Some tracks may not have artwork available
- Check console output for errors

## 📝 Technical Details

- **Backend**: Python 3.14 + C# (.NET 8.0)
- **API**: Windows `GlobalSystemMediaTransportControlsSessionManager`
- **Frontend**: HTML5 + CSS3 (Vanilla JavaScript)
- **Data Format**: JSON with base64-encoded album artwork

## 🤝 Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## 📄 License

MIT License - feel free to use this project for personal or commercial purposes.

## 🙏 Credits

Created for OBS streamers who want to display their music taste without third-party services.

## ⭐ Support

If this project helps you, consider giving it a star on GitHub!
