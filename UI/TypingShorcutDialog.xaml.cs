using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YellowstonePathology.UI
{
    /// <summary>
    /// Interaction logic for TypingShorcut.xaml
    /// </summary>

    public partial class TypingShorcutDialog : System.Windows.Window
    {
        YellowstonePathology.Business.Typing.TypingShortcut m_TypingShortcut;
		YellowstonePathology.Business.User.SystemUserCollection m_SystemUserCollection;
        YellowstonePathology.Business.User.SystemIdentity m_SystemIdentity;
        bool m_IsNewItem = false;                      

        public TypingShorcutDialog(YellowstonePathology.Business.Typing.TypingShortcut typingShortcut, bool isNewShortcut, YellowstonePathology.Business.User.SystemIdentity systemIdentity)
        {
            this.m_TypingShortcut = typingShortcut;
            this.m_IsNewItem = isNewShortcut;
            this.m_SystemIdentity = systemIdentity;

            InitializeComponent();

			this.m_SystemUserCollection = YellowstonePathology.Business.User.SystemUserCollectionInstance.Instance.SystemUserCollection.GetUsersByRole(YellowstonePathology.Business.User.SystemUserRoleDescriptionEnum.Typing, true);

            this.DataContext = this.m_TypingShortcut;
            this.comboBoxTypingUsers.ItemsSource = this.m_SystemUserCollection;         
        }        

        public void GridTyping_KeyUp(object sender, KeyEventArgs args)
        {            
            if (args.Key == Key.F7)
            {
                this.CheckSpelling();
            }
        }

        public void CheckSpelling()
        {
            comboBoxTypingUsers.Focus();
            YellowstonePathology.Business.SpellCheck spellCheck = new YellowstonePathology.Business.SpellCheck();            
            spellCheck.CheckSpelling(this.m_TypingShortcut);            
            MessageBox.Show("Spell check is complete.");
        }

        public void ButtonCancel_Click(object sender, RoutedEventArgs args)
        {
            this.DialogResult = false;
        }

        public void ButtonOk_Click(object sender, RoutedEventArgs args)
        {
            if(this.m_IsNewItem == true)
            {
                YellowstonePathology.Business.Persistence.DocumentGateway.Instance.InsertDocument(this.m_TypingShortcut, this, this.m_SystemIdentity);
            }
            else
            {
                YellowstonePathology.Business.Persistence.DocumentGateway.Instance.Push(this);
            }                      
            this.DialogResult = true;
        }        
    }
}