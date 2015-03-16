using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClassGenerator.Languages;

namespace ClassGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<IClassGenerator> _generators = new List<IClassGenerator>();

        public MainWindow()
        {
            InitializeComponent();
            LoadGenerators();
        }

        /// <summary>
        /// Loads any language generators that 
        /// implement IClassGenerator
        /// </summary>
        private void LoadGenerators()
        {
            var type = typeof (IClassGenerator);
            var implementers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToList();
            foreach (var imp in implementers)
            {
                var instance = Activator.CreateInstance(imp) as IClassGenerator;
                _generators.Add(instance);
                cmbLanguage.Items.Add(new ComboBoxItem()
                {
                    Content = instance.GeneratorName
                });
            }
            cmbLanguage.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the Generate button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtClassName.Text;
            string scaffoldText = txtScaffold.Text;
            if (cmbLanguage.SelectionBoxItem == String.Empty)
            {
                MessageBox.Show("Please select a language");
                return;
            }

            string language = cmbLanguage.SelectionBoxItem.ToString();
            IClassGenerator generator = _generators.First(g => g.GeneratorName == language);
            txtOutput.Text = generator.GenerateClass(name, scaffoldText);
        }

        /// <summary>
        /// Handles the Click event of the Copy to Clipboard button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
        }

   
    }
}