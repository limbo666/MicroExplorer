# MicroExplorer




**MicroExplorer** is a robust, all-in-one development environment (IDE) for IoT developers working with **MicroPython**.

Built in VB.NET, it replaces the need for complex command-line tools (like `ampy` or `rshell`) by providing a modern, asynchronous graphical interface. Manage files, execute scripts, monitor REPL output, and flash firmware to ESP32 and ESP8266 devices—all from a single, seamless dashboard.

<img width="991" height="696" alt="image" src="https://github.com/user-attachments/assets/741cb415-593d-4a27-9192-e752d0cc7c3f" />

----------

##  Key Features

###  Smart File Manager

-   **Dual-Pane Interface:** Classic "Norton Commander" style layout with **Local PC** files on the left and **Device (MicroPython)** files on the right.
    
-   **Visual Styling:** Files are color-coded and icon-styler by type (Python scripts, Images, Web files, System configs) for instant recognition.
    
-   **Drag & Drop:** (Planned/Supported) Easily move files between your computer and the microcontroller.
    
-   **Asynchronous Core:** Uploads, downloads, and deletions run on background threads. The UI **never freezes**, even when transferring large libraries.
    

###  Info Terminal (REPL)

-   **Color-Coded Output:** Distinct colors for System Messages (Green), Errors (Red), User Input (Cyan), and Device Output (White).
    
-   **Interactive Mode:** Full support for the MicroPython REPL. Type python commands directly and see immediate results.
    
-   **Friendly vs. Raw:** automatically handles switching between "Friendly REPL" (for humans) and "Raw REPL" (for file operations) transparently.
    

###  Command Center

A detachable, snap-to-window utility for power users.

-   **Snippet Library:** Store your most frequently used Python commands (e.g., toggling GPIO, checking memory).
    
-   **JSON Persistence:** Your custom commands are saved automatically to `settings.json`.
    
-   **History:** Remembers the last 20 commands sent for quick recall.
    

###  Integrated Firmware Flasher

No need to leave the app to update your board. MicroExplorer includes a GUI wrapper for the industry-standard **esptool**.

-   **Auto-Detect:** Automatically identifies chip types (ESP32, ESP32-C3, ESP32-S3, ESP8266).
    
-   **Smart Offsets:** Automatically applies the correct memory offset (`0x0` vs `0x1000`) based on the chip type.
    
-   **Safe Mode:** Includes options to erase flash before writing for a clean installation.
    

###  System Tools & Quick View

-   **One-Click Stats:** Instantly check Disk Usage, Free RAM, Wi-Fi IP/Status, and synchronize the RTC time with your PC.
    
-   **Quick Viewer:** Inspect the contents of a remote file (like `boot.py`) in a popup window without needing to download it to your disk first.
    

----------

##  Installation

1.  Go to the **[Releases](https://github.com/limbo666/MicroExplorer/releases)** page.
    
2.  Download the latest `MicroExplorer`.
    
3.  Extract the zip file to a folder of your choice.
    
4.  **Important:** Ensure `esptool.exe` is present in the same folder as `MicroExplorer.exe` (included in the release package).
    
5.  Run `MicroExplorer.exe`.
    

----------

## 📝 External Editor Integration (Notepad++)

MicroExplorer is designed to work as a "Remote Runner" for your favorite text editor. You can write code in **Notepad++** (or VS Code) and execute it on your ESP32 with a single hotkey.

### How it Works

When you trigger a command from an external app, MicroExplorer will:

1.  Wake up (or launch if closed).
    
2.  **Auto-Connect** to the last used COM port.
    
3.  Upload the file you are editing.
    
4.  (Optional) Immediately run the file on the device.
    

### Setup Guide for Notepad++

1.  Open Notepad++.
    
2.  Go to **Run > Run...**
    
3.  Add the following commands. Replace `C:\Path\To\` with the actual path where you installed MicroExplorer.
    

#### A. Upload & Run (Recommended: F5)

_Uploads the current file and executes it immediately._

Bash

```
"C:\Path\To\MicroExplorer.exe" -uploadrun "$(FULL_CURRENT_PATH)"

```

#### B. Upload Only (Recommended: F6)

_Updates the file on the device but does not run it._

Bash

```
"C:\Path\To\MicroExplorer.exe" -upload "$(FULL_CURRENT_PATH)"

```

#### C. Soft Reset (Recommended: F12)

_Reboots the ESP32._

Bash

```
"C:\Path\To\MicroExplorer.exe" -reset

```

#### D. Run Main (Recommended: Shift+F5)

_Executes the `main.py` currently on the device._

Bash

```
"C:\Path\To\MicroExplorer.exe" -runmain

```

4.  Click **Save...** for each command, assign the suggested Hotkeys, and you now have a fully integrated MicroPython IDE workflow!


#### Flexible Info Commands
A button is present udner `Info` window to help copy to clipboard the `-upload` command 
    

----------

## ⌨️ Command Line Arguments

You can integrate MicroExplorer into other tools (like VS Code tasks or batch scripts) using these switches:

**Argument**

**Parameter**

**Description**

`-upload`

`[filepath]`

Uploads the specified file to the currently active folder on the device.

`-uploadrun`

`[filepath]`

Uploads the file and executes it immediately via REPL.

`-reset`

_(none)_

Sends a Soft Reset signal (`machine.soft_reset()`) to the device.

`-runmain`

_(none)_

Executes `exec(open('main.py').read())`.

_Note: If MicroExplorer is not running, these commands will launch it and attempt to auto-connect to the last known COM port._

----------

## 📜 License & Credits

**MicroExplorer** is open-source software licensed under the **GNU General Public License v3.0 (GPLv3)**.

-   **Copyright:** © 2026 Nikos Georgousis - Hand Water Pump.
    
-   **Third-Party Components:**
    
    -   This software bundles and interacts with **[esptool](https://www.google.com/search?q=https://github.com/espressif/esptool)** (GPLv2) by Espressif Systems for firmware operations.
        
        

See the `LICENSE` file for full legal details.
