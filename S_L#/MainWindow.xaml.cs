using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace S_L_
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var fileFinder = new FileFinder();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Paradox Interactive");
            string filename = "launcher-v2.sqlite";
            var files = fileFinder.FindFiles(path, filename);

            // Получаем только названия папок
            var folderNames = files.Keys.ToList();

            // Добавляем названия папок в ListBox
            foreach (var folder in folderNames)
            {
                FolderList.Items.Add(folder);
            }
        }

        

        private void FolderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ваш код здесь...
        }
    }

    public class FileFinder
    {
        public Dictionary<string, List<string>> FindFiles(string path, string filename)
        {
            var result = new Dictionary<string, List<string>>();
            foreach (var file in Directory.EnumerateFiles(path, filename, SearchOption.AllDirectories))
            {
                var directory = Path.GetDirectoryName(file);
                if (result.ContainsKey(directory))
                {
                    result[directory].Add(file);
                }
                else
                {
                    result[directory] = new List<string> { file };
                }
            }
            return result;
        }
    }

}
