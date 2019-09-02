using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ExplorerTreeView
{
    public partial class ExplorerTreeView : UserControl, ICommandSource
    {
        #region Constructor

        public ExplorerTreeView()
        {
            InitializeComponent();

            _rootNode = ExplorerService.RootNode;
            tree.Items.Add(_rootNode);

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += dispatcherTimer_Tick; ;
            _dispatcherTimer.Start();

            IsRootNodeExpanded = true;
        }
        
        #endregion//Constructor

        #region Dependency Properties

        public bool? ShowFiles
        {
            get { return (bool?)GetValue(ShowFilesProperty); }
            set { SetValue(ShowFilesProperty, value); }
        }

        public static readonly DependencyProperty ShowFilesProperty =
            DependencyProperty.Register(
                "ShowFiles", 
                typeof(bool?), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null, OnShowFilesChanged));
        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command", 
                typeof(ICommand), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null, OnCommandChanged));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter", 
                typeof(object), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null));

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register(
                "CommandTarget", 
                typeof(IInputElement), 
                typeof(ExplorerTreeView));
        
        public Node SelectedNode
        {
            get { return (Node)GetValue(SelectedNodeProperty); }
            set { SetValue(SelectedNodeProperty, value); }
        }

        public static readonly DependencyProperty SelectedNodeProperty =
            DependencyProperty.Register(
                "SelectedNode", 
                typeof(Node), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null));

        public IEnumerable<string> FoldersNames
        {
            get { return (IEnumerable<string>)GetValue(FoldersNamesProperty); }
            set { SetValue(FoldersNamesProperty, value); }
        }

        public static readonly DependencyProperty FoldersNamesProperty =
            DependencyProperty.Register(
                "FoldersNames", 
                typeof(IEnumerable<string>), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null));
        
        public IEnumerable<string> FoldersFullPath
        {
            get { return (IEnumerable<string>)GetValue(FoldersFullPathProperty); }
            set { SetValue(FoldersFullPathProperty, value); }
        }

        public static readonly DependencyProperty FoldersFullPathProperty =
            DependencyProperty.Register(
                "FoldersFullPath", 
                typeof(IEnumerable<string>), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null));

        public IEnumerable<string> FilesNames
        {
            get { return (IEnumerable<string>)GetValue(FilesNamesProperty); }
            set { SetValue(FilesNamesProperty, value); }
        }

        public static readonly DependencyProperty FilesNamesProperty =
            DependencyProperty.Register(
                "FilesNames", 
                typeof(IEnumerable<string>), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null));

        public IEnumerable<string> FilesFullPath
        {
            get { return (IEnumerable<string>)GetValue(FilesFullPathProperty); }
            set { SetValue(FilesFullPathProperty, value); }
        }

        public static readonly DependencyProperty FilesFullPathProperty =
            DependencyProperty.Register(
                "FilesFullPath", 
                typeof(IEnumerable<string>), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null));

        /// <summary>
        /// Sets path to expand
        /// </summary>
        public string ExpandPath
        {
            get { return (string)GetValue(ExpandPathProperty); }
            set { SetValue(ExpandPathProperty, value); }
        }
        
        public static readonly DependencyProperty ExpandPathProperty =
            DependencyProperty.Register(
                "ExpandPath", 
                typeof(string), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(string.Empty, OnExpandPathChanged));


        /// <summary>
        /// Gets or Sets files filter which will be returned or displayed
        /// </summary>
        public string FilesFilter
        {
            get { return (string)GetValue(FilesFilterProperty); }
            set { SetValue(FilesFilterProperty, value); }
        }
        
        public static readonly DependencyProperty FilesFilterProperty =
            DependencyProperty.Register(
                "FilesFilter", 
                typeof(string), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null, OnFilesFilterChanged));

        public bool? IsRootNodeExpanded
        {
            get { return (bool?)GetValue(IsRootNodeExpandedProperty); }
            set { SetValue(IsRootNodeExpandedProperty, value); }
        }
        
        public static readonly DependencyProperty IsRootNodeExpandedProperty =
            DependencyProperty.Register(
                "IsRootNodeExpanded", 
                typeof(bool?), 
                typeof(ExplorerTreeView), 
                new PropertyMetadata(null, OnIsRootNodeExpandedChanged));

        #endregion//Dependency Properties

        #region Methods

        private static void OnShowFilesChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var tree = d as ExplorerTreeView;
            var newValue = (bool?)e.NewValue;
            if (tree != null && newValue != null)
            {
                tree.ExplorerService.ShowFiles = newValue.Value;
            }  
        }

        private static void OnFilesFilterChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var tree = d as ExplorerTreeView;
            if (tree != null)
            {
                if (!string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                    tree.ExplorerService.FilesFilter = e.NewValue.ToString();
            }
        }

        private static void OnCommandChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var tree = d as ExplorerTreeView;
            if (tree != null)
            {
                ICommand oldCommand = e.OldValue as ICommand;
                if (oldCommand != null)
                {
                    oldCommand.CanExecuteChanged -= tree.CanExecuteChanged;
                }
                ICommand newCommand = e.NewValue as ICommand;
                if (newCommand != null)
                {
                    newCommand.CanExecuteChanged += new EventHandler(tree.CanExecuteChanged);
                }
            }
        }

        private static void OnExpandPathChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var tree = d as ExplorerTreeView;
            if (tree != null)
            {
                tree.ExplorerService.ExpandPath(e.NewValue.ToString());
            }
        }

        private static void OnIsRootNodeExpandedChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var tree = d as ExplorerTreeView;
            var newValue = (bool?)e.NewValue;
            if (tree != null && newValue != null)
            {
                if (tree.IsRootNodeExpanded.Value)
                    tree.ExplorerService.RefreshNode(tree._rootNode);
                tree.ExplorerService.RootNode.IsExpanded = newValue.Value;
            }
        }

        private void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IBaseNode node = null;

            var clickedElement = e.OriginalSource;
            switch (clickedElement)
            {
                case Border border:
                    node = border.DataContext as IBaseNode;
                    break;
                case Image image:
                    node = image.DataContext as IBaseNode;
                    break;
                case TextBlock textBlock:
                    node = textBlock.DataContext as IBaseNode;
                    break;
                case StackPanel stackPanel:
                    node = stackPanel.DataContext as IBaseNode;
                    break;
                case Path path when !((path.DataContext as IExpandable).IsExpanded):
                    node = path.DataContext as IBaseNode;
                    break; 
            }

            if (node != null)
            {
                ExplorerService.RefreshNode(node);
                SelectedNode = CreateExplorerNode(node);
                if (SelectedNode?.FoldersNames?.Count() > 0) FoldersNames = new List<string>(SelectedNode.FoldersNames);
                else FoldersNames = null;
                if (SelectedNode?.FoldersFullPath?.Count() > 0) FoldersFullPath = new List<string>(SelectedNode.FoldersFullPath);
                else FoldersFullPath = null;
                if (SelectedNode?.FilesNames?.Count() > 0) FilesNames = new List<string>(SelectedNode.FilesNames);
                else FilesNames = null;
                if (SelectedNode?.FilesFullPath?.Count() > 0) FilesFullPath = new List<string>(SelectedNode.FilesFullPath);
                else FilesFullPath = null;

                if (NodeLeftButtonMouseClick != null)
                    NodeLeftButtonMouseClick(this, new NodeMouseClickEventArgs(SelectedNode));
                if (Command != null)
                {
                    RoutedCommand command = Command as RoutedCommand;
                    if (command != null)
                    {
                        command.Execute(CommandParameter, CommandTarget);
                    }
                    else Command.Execute(CommandParameter);
                }
            } 
        }

        private Node CreateExplorerNode(IBaseNode node)
        {
            var newNode = new Node(FilesFilter);
            if (node is IRootNode)
                newNode.Path = string.Empty;
            else newNode.Path = (node as IPath).Path;
            return newNode;
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                    {
                        IsEnabled = true;
                    }
                    else
                    {
                        IsEnabled = false;
                    }
                }
                else
                {
                    if (Command.CanExecute(CommandParameter))
                    {
                        IsEnabled = true;
                    }
                    else
                    {
                        IsEnabled = false;
                    }
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ExplorerService.RefreshNode(_rootNode);
            tree.UpdateDefaultStyle();
        }

        #endregion//Methods

        #region Properties

        private ExplorerService ExplorerService { get; } = new ExplorerService();

        #endregion//Properties

        #region Events

        public delegate void NodeLeftButtonMouseClickEventHandler(
            object sender, 
            NodeMouseClickEventArgs e);

        public event NodeLeftButtonMouseClickEventHandler NodeLeftButtonMouseClick;

        #endregion

        #region Fields

        private IRootNode _rootNode;
        private DispatcherTimer _dispatcherTimer;

        #endregion//Fields
    }
}
