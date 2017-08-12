# Aparat-Downloader
A simple c# library which gives the ability to download videos from aparat by video watch link.

# Usage example 

```C#
public Form1()
{
    InitializeComponent();
    CheckForIllegalCrossThreadCalls = false;
}

private void button1_Click(object sender, EventArgs e)
{
    Aparat download = new Aparat(textBox1.Text);
    download.OnDownloadLinkReceived += Download_OnDownloadLinkReceived;
    download.GetVideoDownloadLink();
}

private void Download_OnDownloadLinkReceived(object sender, Aparat.AArgs e)
{
    richTextBox1.Text += e.Quality + " | " + e.DownloadLink + Environment.NewLine;
}
```
