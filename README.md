# Audio Analysis ATR Tool

## **Download and Run**

1. **Download the Latest Release:**
   - Go to the [Releases](https://github.com/YOUR_USERNAME/AudioAnalysisATRTool/releases) section of this repository.
   - Download the file: `AudioAnalysisATRTool.zip`.

2. **Extract the ZIP File:**
   - Right-click the ZIP file and select **Extract All**.
   - Extract the files to a convenient location on your computer.

3. **Run the Application:**
   - Open the extracted folder.
   - Double-click `AudioAnalysisATRTool.exe` to launch the application.

---

## **Usage**

1. **Set Paths:**
   - Click **Browse** next to each field to select:
     - **Working Directory**: Folder where results will be saved.
     - **White Noise File**: Path to the `white_noise.wav` file.
     - **Sine Wave File**: Path to the `sine.wav` file.
     - **Executable Path**: Path to `ATR_Runner.exe`.

2. **Run the Analysis:**
   - Click **Run Analysis** to start the process.
   - Logs will appear in the output area.
   - Results will be saved in a timestamped folder within the working directory.

---

# Build From Source

## **Prerequisites**

Before building or running this application, ensure you have:

1. **Required Files** (Place them in a known location):
   - `ATR_Runner.exe` – The main executable for analysis.
   - `white_noise.wav` – Sample WAV file for testing.
   - `sine.wav` – Sample WAV file for testing.
2. **.NET SDK 9.0 or Later**: Install the [.NET SDK](https://dotnet.microsoft.com/download) if not already installed.

---

## **How to Build the Application**

1. **Clone the Repository:**

   ```pwsh
   git clone https://github.com/YOUR_USERNAME/AudioAnalysisATRTool.git
   cd AudioAnalysisATRTool
   ```

2. **Open the Solution:**
    - Open the `AudioAnalysisATRTool.sln` file in **Visual Studio 2022** or **later**.

3. **Restore NuGet Packages:**
    - Visual Studio should automatically restore NuGet packages when you open the solution.
    - If not, restore then manually via the **Package Manager Console**:
    
    ```pwsh
    dotnet restore
    ```

4. **Build the Solution:**
    - Build the solution in **Release** mode for best performance `Ctrl+Shift+B`

5. **Run the Application:**
    - Once built, the executable will be located in the `bin\Release\net9.0-windows` directory.

---

