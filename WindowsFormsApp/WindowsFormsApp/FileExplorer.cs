using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp
{
    public struct Config
    {
        public string first, second, third;
    };
    class FileExplorer
    {
        private TextBox _textDirectory, _textFileTemplate, _textKeyWords;
        private TreeView _results;
        private Button _trigger;
        private Label _curTime, _curFile, _curNumber;

        public string _filename = "save_config.xml";
        
        private readonly string[] _labels = { "Start", "Continue", "Stop" };
        Thread _processor;
        private bool _stopThread = false;
        int _filesNumber = 0;
        private delegate void AddNodeDelegate();
        private delegate void ChangeTextDelegate();
        private delegate void ChangeCurrentFileDelegate();

        System.Windows.Forms.Timer _timer;
        TimeSpan _procTime, _startTime;
        

        public FileExplorer(TextBox textBoxDirectory, TextBox textBoxFileTemplate, TextBox textBoxKeyWords, 
            TreeView treeView, Button button, Label curFile, Label curTime, Label curNumber)
        {
            _textDirectory = textBoxDirectory;
            _textFileTemplate = textBoxFileTemplate;
            _textKeyWords = textBoxKeyWords;
            _results = treeView;
            _trigger = button;
            _curFile = curFile;
            _curTime = curTime;
            _curNumber = curNumber;

            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Event_Processor;
            _timer.Interval = 800;
            _startTime = DateTime.Now.TimeOfDay;

            Load();
            _trigger.Text = _labels[0];
            _trigger.Click += Show_Result;
            _textDirectory.TextChanged += Restart;
            _textFileTemplate.TextChanged += Restart;
            _textKeyWords.TextChanged += Restart;
        }
        
        private void Restart(object sender, EventArgs e)
        {
            _trigger.Text = _labels[0];
            _stopThread = true;
        }
        public void Finish(object sender, EventArgs e)
        {
            _stopThread = true;
            Save();
        }
        private void Save()
        {
            //_processor.Abort();
            Config config = new Config
            {
                first = _textDirectory.Text,
                second = _textFileTemplate.Text,
                third = _textKeyWords.Text
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            TextWriter writer = new StreamWriter(_filename);
            serializer.Serialize(writer, config);
            writer.Close();
        }
        private void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            try
            {
                TextReader reader = new StreamReader(new FileStream(_filename, FileMode.Open));
                Config config = (Config)serializer.Deserialize(reader);
                reader.Close();
                _textDirectory.Text = config.first;
                _textFileTemplate.Text = config.second;
                _textKeyWords.Text = config.third;
            }
            catch (Exception ) { }
        }
        public void Open_Directory(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fileDialog = new FolderBrowserDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.OK) _textDirectory.Text = fileDialog.SelectedPath;
            }
        }
        public void Show_Result(object sender, EventArgs e)
        {
            if (_trigger.Text == _labels[0])
            {
                _stopThread = false;
                if (!Directory.Exists(_textDirectory.Text))
                {
                    MessageBox.Show(_textDirectory.Text + " does not exist!");
                    return;
                }
                else
                {
                    _trigger.Text = _labels[2];
                    _results.BeginUpdate();
                    _results.Nodes.Clear();
                    _results.Nodes.Add(_textDirectory.Text);
                    _results.EndUpdate();
                    _startTime = DateTime.Now.TimeOfDay;
                    _timer.Start();
                    ThreadPool.QueueUserWorkItem(Process);
                    return;
                }
            }
            else if (_trigger.Text == _labels[1])
            {
                _trigger.Text = _labels[2];
                _timer.Start();
                _processor.Resume();
                return;
            }
            else if (_trigger.Text == _labels[2])
            {
                _trigger.Text = _labels[1];
                _timer.Stop();
                _processor.Suspend();
                return;
            }
        }
        private void Process(object state)
        {
            _processor = Thread.CurrentThread;
            DirectoryInfo current = new DirectoryInfo(_textDirectory.Text),
                source = current.Parent;
            string[] splitter1 = { "." }, splitter2 = { "*" };
            string[] content = _textFileTemplate.Text.Split(splitter1, StringSplitOptions.None);
            string extension = "." + content[1];
            if (extension.IsEmpty()) MessageBox.Show("Wrong input of the file extension!");
            else
            {
                content = content[0].Split(splitter2, StringSplitOptions.None);
                string begin = content[0], end = content[1];

                _filesNumber = 0;
                Search(_results.Nodes[0], current, begin, end, extension);
                Clean_Results(_results.Nodes[0], extension);
            }
            _timer.Stop();
            ChangeTextDelegate change = new ChangeTextDelegate(() => Change_Trigger_Text());
            change += () => Change_Current_File("");
            _trigger.Invoke(change);
        }
        private int Search(TreeNode source, DirectoryInfo current, string begin, string end, string extension)
        {
            if (_stopThread) return 0;
            bool flag = true;
            int filesNumber = 0;
            foreach (FileInfo file in current.GetFiles())
            {
                _filesNumber++;
                ChangeCurrentFileDelegate change = new ChangeCurrentFileDelegate(() => Change_Current_File(file.FullName));
                _curFile.Invoke(change);
                string filename = file.Name;
                if (file.Extension != extension) flag = false;
                else
                {
                    if (!begin.IsEmpty())
                    {
                        for (var index = 0; index < begin.Length; index++)
                        {
                            if (filename[index] != begin[index]) flag = false;
                        }
                    }
                    if (!end.IsEmpty())
                    {
                        string[] splitter = { "." };
                        string name = filename.Split(splitter, StringSplitOptions.None).First();
                        if (name.Length >= end.Length)
                        {
                            for (var index = 0; index < end.Length; index++)
                            {
                                if (name[name.Length - end.Length + index] != end[index]) flag = false;
                            }
                        }
                        else flag = false;
                    }
                    if (flag)
                    {
                        if (!_textKeyWords.Text.IsEmpty())
                        {
                            string text = Read_TextFile(file.FullName);
                            string[] splitter = { " " };
                            foreach (var word in _textKeyWords.Text.Split(splitter, StringSplitOptions.None))
                            {
                                if (!text.Contains(word)) flag = false;
                            }
                        }
                    }
                }
                if (flag)
                {
                    filesNumber++;
                    AddNodeDelegate add = new AddNodeDelegate(() => Add_New_TreeViewNode(source, new TreeNode(file.FullName)));
                    _results.Invoke(add);
                }
            }
            foreach (DirectoryInfo directory in current.GetDirectories())
            {
                TreeNode newNode = new TreeNode(directory.FullName);
                AddNodeDelegate add = new AddNodeDelegate(() => Add_New_TreeViewNode(source, newNode));
                _results.Invoke(add);
                filesNumber += Search(newNode, directory, begin, end, extension);
                if (_stopThread) return 0;
                if (filesNumber == 0)
                {
                    AddNodeDelegate remove = new AddNodeDelegate(() => Delete_TreeViewNode(source, newNode));
                    _results.Invoke(remove);
                }
            }

            return filesNumber;
        }
        private void Clean_Results(TreeNode source, string extension)
        {
            if (_stopThread) return;
            AddNodeDelegate remove = new AddNodeDelegate(() => { return; });
            foreach (TreeNode node in source.Nodes)
            {
                if (!node.Text.Contains(extension) && node.Nodes.Count == 0)
                {
                    remove += () => Delete_TreeViewNode(node.Parent, node);
                }
                Clean_Results(node, extension);
            }
            _results.Invoke(remove);
        }
        private string Read_TextFile(string filename)
        {
            try
            {
                return File.ReadAllText(filename);
            }
            catch(Exception )
            {
                return "";
            }
        }
        private void Change_Trigger_Text()
        {
            _trigger.Text = _labels[0];
            _results.EndUpdate();
        }
        private void Add_New_TreeViewNode(TreeNode source, TreeNode newNode)
        {
            source.Nodes.Add(newNode);
        }
        private void Delete_TreeViewNode(TreeNode source, TreeNode node)
        {
            source.Nodes.Remove(node);
        }
        private void Change_Current_File(string fileName)
        {
            _curFile.Text = "Processing: " + fileName;
            _curNumber.Text = "Processed: " + _filesNumber.ToString();
        }
        
        private void Timer_Event_Processor(Object o, EventArgs e)
        {
            _procTime = DateTime.Now.TimeOfDay;
            TimeSpan deltaTime = _procTime - _startTime;
            _curTime.Text = "Time: " + deltaTime.Hours.ToString() + " : " + deltaTime.Minutes.ToString() + " : " + ((int)deltaTime.Seconds).ToString();
        }
    }
}
