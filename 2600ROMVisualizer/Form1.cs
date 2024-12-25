using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtariROMVisualizer
{
    public partial class Form1 : Form
    {
        private bool _isProcessing = false;
        private readonly Color[] bankColors = new Color[]
        {
            Color.White, Color.Green, Color.Blue, Color.Red,
            Color.Purple, Color.Pink, Color.Orange, Color.Brown,
            Color.Gray, Color.Cyan, Color.SaddleBrown, Color.Indigo,
            Color.Goldenrod, Color.Fuchsia, Color.ForestGreen, Color.CornflowerBlue
        };
        private readonly Random random = new Random();
        private Color[] randomBankColors = new Color[16];

        public Form1()
        {
            InitializeComponent();
            InitializeControls();

            try
            {
                string iconPath = Path.Combine(Application.StartupPath, "atarilogo_Wfh_icon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading icon: {ex.Message}");
            }
        }

        private void InitializeControls()
        {
            // Initialize bank coloring dropdown
            bankColoringDropDown.Items.AddRange(new object[] { "no bank coloring", "bank coloring", "random bank coloring" });
            bankColoringDropDown.SelectedItem = "bank coloring";

            // Initialize other dropdowns
            scaleBitsDropDown.Items.AddRange(new object[] { "1", "2", "4" });
            scaleBitsDropDown.SelectedItem = "4";

            columnSizeDropDown.Items.AddRange(new object[] { "1/2 page", "1 page" });
            columnSizeDropDown.SelectedItem = "1 page";

            banksPerRowDropDown.Items.AddRange(new object[] { "1", "2", "4", "8" });
            banksPerRowDropDown.SelectedItem = "4";

            // Set default checkbox states
            bitShaderCheckBox.Checked = true;
        }

        private void GenerateRandomBankColors()
        {
            for (int i = 0; i < 16; i++)
            {
                randomBankColors[i] = Color.FromArgb(
                    random.Next(256),
                    random.Next(256),
                    random.Next(256));
            }
        }

        private void inputFileBrowseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Atari ROM Files (*.bin;*.a26;*.zip)|*.bin;*.a26;*.zip|All files (*.*)|*.*";
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    inputPathTextBox.Text = dialog.FileName;
                    UpdateOutputPath();
                }
            }
        }

        private void inputFolderBrowseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    inputPathTextBox.Text = dialog.SelectedPath;
                    UpdateOutputPath();
                }
            }
        }

        private void outputBrowseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    outputPathTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void inputPathTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateOutputPath();
        }

        private void UpdateOutputPath()
        {
            if (!string.IsNullOrEmpty(inputPathTextBox.Text))
            {
                string inputPath = inputPathTextBox.Text;
                string baseDirectory;

                if (File.Exists(inputPath))
                {
                    baseDirectory = Path.GetDirectoryName(inputPath);
                }
                else if (Directory.Exists(inputPath))
                {
                    baseDirectory = inputPath;
                }
                else
                {
                    baseDirectory = Path.GetDirectoryName(inputPath);
                }

                if (!string.IsNullOrEmpty(baseDirectory))
                {
                    outputPathTextBox.Text = Path.Combine(baseDirectory, "Visualizations");
                }
            }
        }

        private async void goButton_Click(object sender, EventArgs e)
        {
            if (_isProcessing)
            {
                MessageBox.Show("Already processing files. Please wait.");
                return;
            }

            if (string.IsNullOrEmpty(inputPathTextBox.Text) || string.IsNullOrEmpty(outputPathTextBox.Text))
            {
                MessageBox.Show("Please select input and output paths.");
                return;
            }

            _isProcessing = true;
            goButton.Enabled = false;
            progressBar.Value = 0;

            try
            {
                // Capture UI values before starting background work
                int selectedBanksPerRow = int.Parse(banksPerRowDropDown.SelectedItem.ToString());
                bool isFullPage = columnSizeDropDown.SelectedItem.ToString() == "1 page";
                int scaleFactor = int.Parse(scaleBitsDropDown.SelectedItem.ToString());
                bool useBitShader = bitShaderCheckBox.Checked;
                string bankColoringMode = bankColoringDropDown.SelectedItem.ToString();

                List<string> filesToProcess = new List<string>();

                if (File.Exists(inputPathTextBox.Text))
                {
                    filesToProcess.Add(inputPathTextBox.Text);
                }
                else if (Directory.Exists(inputPathTextBox.Text))
                {
                    filesToProcess.AddRange(Directory.GetFiles(inputPathTextBox.Text, "*.bin"));
                    filesToProcess.AddRange(Directory.GetFiles(inputPathTextBox.Text, "*.a26"));
                    filesToProcess.AddRange(Directory.GetFiles(inputPathTextBox.Text, "*.zip"));
                }
                else
                {
                    MessageBox.Show("Input path is not valid.");
                    return;
                }

                Directory.CreateDirectory(outputPathTextBox.Text);

                // Count total files including those in ZIPs
                int totalFiles = await Task.Run(() => CountTotalFiles(filesToProcess));
                progressBar.Maximum = totalFiles;

                int processedCount = 0;
                foreach (var file in filesToProcess)
                {
                    if (file.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        // Process files in ZIP
                        processedCount += await ProcessZipFile(file, selectedBanksPerRow, isFullPage, scaleFactor, useBitShader, bankColoringMode);
                    }
                    else
                    {
                        await Task.Run(() => ProcessRomFile(file, selectedBanksPerRow, isFullPage, scaleFactor, useBitShader, bankColoringMode));
                        processedCount++;
                        progressBar.Value = processedCount;
                    }
                    Application.DoEvents();
                }

                MessageBox.Show($"Processing complete! {processedCount} file{(processedCount != 1 ? "s" : "")} processed.");
                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing files: {ex.Message}");
            }
            finally
            {
                _isProcessing = false;
                goButton.Enabled = true;
            }
        }

        private int CountTotalFiles(List<string> files)
        {
            int count = 0;
            foreach (var file in files)
            {
                if (file.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    using (var archive = ZipFile.OpenRead(file))
                    {
                        count += archive.Entries.Count(e =>
                            e.Name.EndsWith(".bin", StringComparison.OrdinalIgnoreCase) ||
                            e.Name.EndsWith(".a26", StringComparison.OrdinalIgnoreCase));
                    }
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        private async Task<int> ProcessZipFile(string zipPath, int banksPerRow, bool isFullPage, int scaleFactor, bool useBitShader, string bankColoringMode)
        {
            int processedCount = 0;
            using (var archive = ZipFile.OpenRead(zipPath))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.Name.EndsWith(".bin", StringComparison.OrdinalIgnoreCase) ||
                        entry.Name.EndsWith(".a26", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = entry.Open())
                        using (var ms = new MemoryStream())
                        {
                            await stream.CopyToAsync(ms);
                            byte[] data = ms.ToArray();
                            ProcessRomData(data, entry.Name, banksPerRow, isFullPage, scaleFactor, useBitShader, bankColoringMode);
                            processedCount++;
                            progressBar.Value++;
                            Application.DoEvents();
                        }
                    }
                }
            }
            return processedCount;
        }

        private void ProcessRomFile(string inputFile, int banksPerRow, bool isFullPage, int scaleFactor, bool useBitShader, string bankColoringMode)
        {
            byte[] data = File.ReadAllBytes(inputFile);
            ProcessRomData(data, Path.GetFileName(inputFile), banksPerRow, isFullPage, scaleFactor, useBitShader, bankColoringMode);
        }

        private Color GetBankColor(int bankNumber, string bankColoringMode)
        {
            if (bankColoringMode == "no bank coloring")
                return Color.White;

            if (bankColoringMode == "random bank coloring")
                return randomBankColors[bankNumber % 16];

            // Regular bank coloring
            return bankColors[bankNumber % 16];
        }

        private Color DeterminePixelColor(bool isBitSet, int bitOffset, int byteCount, int bankNumber, bool useBitShader, string bankColoringMode)
        {
            if (!isBitSet)
                return Color.Black;

            Color tempColor = Color.White;

            if (useBitShader)
            {
                // Apply bit offset shading
                int shade = -16 * bitOffset;
                if (byteCount % 2 == 1) // odd byte
                {
                    shade -= 32;
                }

                tempColor = AdjustColorShade(tempColor, shade);
            }

            if (bankColoringMode != "no bank coloring" && tempColor != Color.Black)
            {
                // Mix with bank color (75% tempColor + 25% bankColor)
                Color bankColor = GetBankColor(bankNumber, bankColoringMode);
                tempColor = Color.FromArgb(
                    (tempColor.R * 3 + bankColor.R) / 4,
                    (tempColor.G * 3 + bankColor.G) / 4,
                    (tempColor.B * 3 + bankColor.B) / 4
                );
            }

            return tempColor;
        }

        private Color AdjustColorShade(Color color, int shadeAdjustment)
        {
            return Color.FromArgb(
                Math.Max(0, Math.Min(255, color.R + shadeAdjustment)),
                Math.Max(0, Math.Min(255, color.G + shadeAdjustment)),
                Math.Max(0, Math.Min(255, color.B + shadeAdjustment))
            );
        }

        private void ProcessRomData(byte[] data, string filename, int banksPerRow, bool isFullPage, int scaleFactor, bool useBitShader, string bankColoringMode)
        {
            if (bankColoringMode == "random bank coloring")
            {
                GenerateRandomBankColors();  // Generate new random colors for each file
            }

            var outputFile = Path.Combine(outputPathTextBox.Text,
                Path.GetFileNameWithoutExtension(filename) + ".png");

            int bankSize = 4096;
            int numBanks = (int)Math.Ceiling((double)data.Length / bankSize);

            // If numBanks is less than selected banks per row, adjust accordingly
            int banksHorizontally = (numBanks < banksPerRow) ? numBanks : banksPerRow;
            int banksVertically = (int)Math.Ceiling((double)numBanks / banksHorizontally);

            int bankWidth = isFullPage ? 128 : 256;  // (4096/pageSize)*8
            int bankHeight = isFullPage ? 256 : 128;

            using (var tempBitmap = new Bitmap(
                bankWidth * banksHorizontally,
                bankHeight * banksVertically))
            {
                // Process each byte
                int byteCount = 0;
                while (byteCount < data.Length)
                {
                    int bankNumber = byteCount / bankSize;
                    int bytePerBankCount = byteCount % bankSize;

                    int bankX = (bankNumber % banksHorizontally) * bankWidth;
                    int bankY = (bankNumber / banksHorizontally) * bankHeight;

                    int offsetX = isFullPage ?
                        bytePerBankCount / 256 :
                        bytePerBankCount / 128;
                    int offsetY = isFullPage ?
                        bytePerBankCount % 256 :
                        bytePerBankCount % 128;

                    byte currentByte = data[byteCount];

                    // Process each bit
                    for (int bitOffset = 0; bitOffset < 8; bitOffset++)
                    {
                        bool isBitSet = ((currentByte >> (7 - bitOffset)) & 1) == 1;
                        Color pixelColor = DeterminePixelColor(isBitSet, bitOffset, byteCount, bankNumber, useBitShader, bankColoringMode);

                        tempBitmap.SetPixel(
                            bankX + offsetX * 8 + bitOffset,
                            bankY + offsetY,
                            pixelColor);
                    }

                    byteCount++;
                }

                // Scale the final image
                using (var outputBitmap = new Bitmap(
                    tempBitmap.Width * scaleFactor,
                    tempBitmap.Height * scaleFactor))
                {
                    using (var g = Graphics.FromImage(outputBitmap))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        g.DrawImage(tempBitmap, 0, 0, outputBitmap.Width, outputBitmap.Height);
                    }

                    outputBitmap.Save(outputFile, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
    }
}