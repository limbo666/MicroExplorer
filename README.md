# MicroExplorer


<img width="991" height="696" alt="image" src="https://github.com/user-attachments/assets/741cb415-593d-4a27-9192-e752d0cc7c3f" />


MicroExplorer is a robust, all-in-one toolbox for IoT developers working with MicroPython. Built in VB.NET, it replaces the need for complex command-line tools by providing a modern graphical interface to manage your files, execute scripts, and flash firmware to ESP32 and ESP8266 devices seamlessly.


Key Features:

Smart File Manager: Dual-pane interface (Local vs. Device), multi-selection support, and visual file type styling.

Asynchronous Core: specific file operations (Upload, Download, Delete) run on background threads, ensuring the UI never freezes during large transfers.

Communication Terminal: A rich, color-coded REPL terminal that separates system messages, sent commands, and received data.

Command Center: A snap-to-window utility for storing and firing frequently used Python snippets (saved via JSON).

Integrated Flasher: Built-in GUI wrapper for esptool.exe to auto-detect chip types (ESP32, C3, S3) and flash firmware without leaving the app.

Quick System Tools: One-click access to device stats (Disk Usage, RAM availability, Wi-Fi Status, Time Sync).

Quick Viewer: Instant code inspection for remote files without needing to download them first.
