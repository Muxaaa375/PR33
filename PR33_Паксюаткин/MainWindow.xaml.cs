using PR33_Паксюаткин.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace PR33_Паксюаткин
{
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();

            init = this;
            LoadData();
            OpenPage(new Groups());
        }

        public class GroupsList
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public List<GroupsList> groupsLists = new List<GroupsList>();

        public string HttpQuery(string url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebResponse.GetResponseStream());
            return strm.ReadToEnd();
        }

        public void LoadData()
        {
            groupsLists.Clear();

            string data = HttpQuery("http://localhost/api/index.php?groups");
            string[] dataGroups = data.Split(';');

            for (int i = 0; i < dataGroups.Length; i++)
            {
                GroupsList newGroupsList = new GroupsList();
                string[] idNameGroups = dataGroups[i].Split(':');

                newGroupsList.id = Convert.ToInt32(idNameGroups[0]);
                newGroupsList.name = idNameGroups[1];

                groupsLists.Add(newGroupsList);
            }
        }

        public void OpenPage(Page _page)
        {
            frame.Navigate(_page);
        }
    }
}
