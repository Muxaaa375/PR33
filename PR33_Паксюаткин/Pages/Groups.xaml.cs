using System.Windows.Controls;
using static PR33_Паксюаткин.MainWindow;

namespace PR33_Паксюаткин.Pages
{
    public partial class Groups : Page
    {
        public Groups()
        {
            InitializeComponent();
            LoadData();
        }
        private void FindGroups(object sender, TextChangedEventArgs e)
        {
            string searchText = find.Text.ToLower();
            listView.Items.Clear();
            foreach (GroupsList group in init.groupsLists)
            {
                if (group.name.ToLower().Contains(searchText))
                {
                    listView.Items.Add(group);
                }
            }
        }
        public void LoadData()
        {
            listView.Items.Clear();
            for (int i = 0; i < init.groupsLists.Count; i++)
            {
                listView.Items.Add(init.groupsLists[i]);
            }
        }
    }
}
